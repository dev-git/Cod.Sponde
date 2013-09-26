using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.SqlServer.Management.Common;
using Microsoft.Win32;
using System.Data;
using System.Data.SqlClient;

namespace Cod.Sponde.Blt.Clb
{
    public class SqlServerInstance : BusinessObject
    {
        public SqlServerInstance()
        {
            WhenCreated = DateTime.Now;
            WhenModified = WhenCreated;
        }

        public SqlServerInstance(string name, string server, string instance, bool isClustered, string version, bool isLocal)
            : this()
        {
            Name = name;
            Machine = server;
            Instance = instance;
            IsClustered = isClustered;
            Version = version;
            IsLocal = isLocal;
        }

        public string Name { get; set; }

        public string Machine { get; set; }

        public string Instance { get; set; }

        public bool IsClustered { get; set; }

        public string Version { get; set; }

        public bool IsLocal { get; set; }

        private static ServerConnection connection = null;
        private static Microsoft.SqlServer.Management.Smo.Server svr;
        private static SqlConnection conn = null;
        //private const string masterConnString = "server={0};initial catalog=master;Trusted_Connection=True;";
        private const string masterConnString = "server={0};initial catalog=master;user id=sa;password=sa123;";

        public IList<SqlServerInstance> GetSqlServerInstances(bool getLocalOnly)
        {
            DataTable dt = GetSqlServers(getLocalOnly);
            IList<SqlServerInstance> sqlServerList = new List<SqlServerInstance>();

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    sqlServerList.Add(new SqlServerInstance(dr.Field<string>(0), dr.Field<string>(1), dr.Field<string>(2), dr.Field<bool>(3), dr.Field<string>(4),
                        dr.Field<bool>(5)));
                }
            }
            return sqlServerList;
        }

        private DataTable GetSqlServers(bool getLocalOnly)
        {
            bool found = false;
            DataTable dt = new DataTable();

            try
            {
                dt = Microsoft.SqlServer.Management.Smo.SmoApplication.EnumAvailableSqlServers(getLocalOnly);

                //Search Registry for local server then add then to server list
                RegistryKey rk = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Microsoft SQL Server");

                String[] instances = (String[])rk.GetValue("InstalledInstances");

                if (instances != null && instances.Length > 0)
                {
                    foreach (String element in instances)
                    {
                        found = false;

                        String name = "";

                        //only add if it doesn't exist
                        if (element == "MSSQLSERVER")
                        {
                            name = System.Environment.MachineName;
                        }
                        else
                        {
                            name = System.Environment.MachineName + @"\" + element;
                        }

                        for (int ndx = 0; ndx < dt.Rows.Count; ndx++)
                        {
                            if (dt.Rows[ndx].ItemArray.GetValue(0).ToString() == name)
                            {
                                found = true;
                                break;
                            }
                        }

                        if (!found)
                        {
                            dt.Rows.Add(name, String.Empty, String.Empty, false, String.Empty, true);
                            dt.AcceptChanges();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
               throw new ApplicationException(ex.Message);
            }
            return dt;
        }

        public static Array GetDatabases(string instance)
        {
            string[] databaseList = null;
            if (connection == null)
            {
                try
                {
                    InitialiseServer(instance);
                    
                    databaseList = new string[svr.Databases.Count];
                    int xx = 0;
                    foreach (Microsoft.SqlServer.Management.Smo.Database db in svr.Databases)
                    {
                        databaseList.SetValue(db.Name, xx);
                        xx++;
                    }
                    //connection.Disconnect();
                    
                    
                }
                catch (Exception ex)
                {
                    throw new ApplicationException(ex.Message);
                }
                finally
                {
                    connection.Disconnect();
                    connection = null;
                }

                
            }
            return databaseList;
        }

        public static Array GetDatabasesExtended(string instance)
        {
            string[,] databaseList = null;
            if (connection == null)
            {
                try
                {
                    InitialiseServer(instance);

                    databaseList = new string[svr.Databases.Count, 3];
                    int xx = 0;
                    foreach (Microsoft.SqlServer.Management.Smo.Database db in svr.Databases)
                    {
                        int tableCount = GetTables(instance, db.Name).Length;
                        int fieldCount = GetFields(instance, db.Name).Length;
                        databaseList.SetValue(db.Name, xx, 0);
                        databaseList.SetValue(tableCount.ToString(), xx, 1);
                        databaseList.SetValue(fieldCount.ToString(), xx, 2);
                        xx++;
                    }
                    //connection.Disconnect();


                }
                catch (Exception ex)
                {
                    throw new ApplicationException(ex.Message);
                }
                finally
                {
                    connection.Disconnect();
                    connection = null;
                }


            }
            return databaseList;
        }

        private static void InitialiseServer(string serverInstanceName)
        {
            try
            {
                connection = new ServerConnection();
                connection.LoginSecure = true;
                connection.ServerInstance = serverInstanceName;
                svr = new Microsoft.SqlServer.Management.Smo.Server(connection);

            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }


        public static Array GetTables(string instanceName, string databaseName)
        {
            string[] tableList = null;
           
            try
            {
                string connectionString = String.Format(masterConnString, instanceName);

                using (conn = new SqlConnection(connectionString))
                {
                    // Open the connection
                    conn.Open();

                    // Get the number of tables
                    string sqlString = String.Format("use {0};select count(*) as 'Count' from sysobjects where xtype='u';", databaseName);
                    using (SqlCommand cmd = new SqlCommand(sqlString, conn))
                    {
                        int tableCount = Int32.Parse(cmd.ExecuteScalar().ToString());
                        tableList = new string[tableCount];

                        // Get the list of tables
                        string sqlTableString = String.Format("use {0};select name as 'Name' from sysobjects where xtype='u' order by name;", databaseName);
                        cmd.CommandText = sqlTableString;

                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            int xx = 0;
                            while (reader.Read())
                            {
                                tableList.SetValue(reader["Name"], xx);
                                xx++;
                            }
                        }
                        reader.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
            finally
            {
                if (conn.State != ConnectionState.Closed)
                {
                    conn.Close();
                }
            }

            return tableList;
        }

        public static Array GetFields(string instanceName, string databaseName)
        {
            string[] fieldList = null;

            try
            {
                string connectionString = String.Format(masterConnString, instanceName);
                using (conn = new SqlConnection(connectionString))
                {
                    // Open the connection
                    conn.Open();

                    // Get the number of tables
                    string sqlString = String.Format("use {0};select count(*) as 'Count' from syscolumns;", databaseName);
                    using (SqlCommand cmd = new SqlCommand(sqlString, conn))
                    {
                        int tableCount = Int32.Parse(cmd.ExecuteScalar().ToString());
                        fieldList = new string[tableCount];

                        // Get the list of tables
                        string sqlColumnString = String.Format("use {0};select name as 'Name' from syscolumns;", databaseName);
                        cmd.CommandText = sqlColumnString;

                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            int xx = 0;
                            while (reader.Read())
                            {
                                fieldList.SetValue(reader["Name"], xx);
                                xx++;
                            }
                        }
                        reader.Close();
                    }   
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
            finally
            {
                if (conn.State != ConnectionState.Closed)
                {
                    conn.Close();
                }
            }

            return fieldList;
        }
    }
  
}
