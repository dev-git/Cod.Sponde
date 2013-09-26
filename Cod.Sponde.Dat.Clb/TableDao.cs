using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Cod.Sponde.Blt.Clb;
using System.Data;
using System.Data.SqlClient;

namespace Cod.Sponde.Dat.Clb
{
    public class TableDao :ITableDao
    {
        List<Table> listResult = new List<Table>();

        #region ITableDao Members

        public IList<Table> GetTables(string server, string database, bool trustedConnection)
        {
            throw new NotImplementedException();
        }

        public IList<Table> GetTablesExtended(string server, string database, bool trustedConnection)
        {
            throw new NotImplementedException();
        }

        public IList<Table> GetMissingTables(string server, string database, bool trustedConnection)
        {
            throw new NotImplementedException();
        }

        public IList<Table> GetMissingTablesExtended(string server, string database, bool trustedConnection)
        {
            throw new NotImplementedException();
        }

        public IList<Table> GetTableDetails(string connectionString)
        {
                    
            SqlConnection conn = null;
            IList<Table> tableList = new List<Table>();

            try
            {
                using (conn = new SqlConnection(connectionString))
                {
                    // Open the connection
                    conn.Open();

                    // Get the table and field list
                    StringBuilder sqlString = new StringBuilder("use {0};");
                    sqlString.Append("select sysobjects.name as 'Table', sys.syscolumns.name as 'Field', sys.syscolumns.type as 'Type',  ");
                    sqlString.Append("isnull(sys.syscolumns.prec, 0) as 'Precision', isnull(sys.syscolumns.scale, 0) as 'Scale', sys.syscolumns.isnullable as 'IsNullable' ");
                    sqlString.Append(" from sys.sysobjects inner join sys.syscolumns on (sysobjects.id = sys.syscolumns.id) ");
                    sqlString.Append(" where sys.sysobjects.xtype='u' order by 1;" );
                  
                    using (SqlCommand cmd = new SqlCommand(String.Format(sqlString.ToString(), conn.Database), conn))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Table tab = new Table(reader["Table"].ToString());
                                tab.DatabaseName = conn.Database;

                                tab.Fields.Name = reader["Field"].ToString();
                                tab.Fields.Type = reader["Type"].ToString();
                                tab.Fields.Precision = Int32.Parse(reader["Precision"].ToString());
                                tab.Fields.Scale = Int32.Parse(reader["Scale"].ToString());
                                tab.Fields.IsNullable = reader["IsNullable"].ToString() == "1" ? true : false;
                                tab.Fields.Table = tab;

                                tableList.Add(tab);
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
     

        public IList<Table> GetExceptionsTableDetails(string connectionString1, string connectionString2)
        {
            IList<Table> leftTable = GetTableDetails(connectionString1);
            IList<Table> rightTable = GetTableDetails(connectionString2);

            Compare(leftTable, rightTable);
            Compare(rightTable, leftTable);

            return listResult;
        }

        private void Compare(IList<Table> table1, IList<Table> table2)
        {
            foreach (Table t1 in table1)
            {
                bool isThere = table2.Any(t2 => t2.Name == t1.Name 
                    && t2.Fields.Name == t1.Fields.Name
                    && t2.Fields.Precision == t1.Fields.Precision
                    && t2.Fields.Scale == t1.Fields.Scale
                    && t2.Fields.IsNullable == t1.Fields.IsNullable);

                 if (!isThere)
                {
                    listResult.Add(t1);
                }
            }
            //IEnumerable<Table> differenceQuery = leftTable.Union(rightTable).Except(leftTable.Intersect(rightTable));

            //List<Table> listRes = new List<Table>();
            //leftList.Except<string>(rightList)
            /* foreach (Table item in leftTable)
             {
                 var exist = rightTable
                     .Select(x => x.Name)
                     .Contains(item.Name );

                 if (!exist)
                 {
                     listRes.Add(item);
                 }
                 else
                 {
                     var inOther = rightTable
                         .Where(l => l.Fields.Name == item.Fields.Name 
                                 || l.Fields.Type == item.Fields.Type
                                 || l.Fields.Precision == item.Fields.Precision 
                                 || l.Fields.Scale == item.Fields.Scale
                                 || l.Fields.IsNullable == item.Fields.IsNullable);

                     if (!inOther)
                     {
                         listRes.Add(item);
                     }
                 }

                     /*if (item.HourBy != totalFromOther)
                     {
                         item.HourBy = item.HourBy - totalFromOther;
                         listRes.Add(item);
                     }*/




            /*var result = from l in leftTable
                         from r in rightTable
                         where l.Fields.Name != r.Fields.Name 
                         || l.Fields.Type != r.Fields.Type 
                         || l.Fields.Precision != r.Fields.Precision 
                         || l.Fields.Scale != r.Fields.Scale
                         || l.Fields.IsNullable != r.Fields.IsNullable
                         select l.Fields.Name;*/



            //names1.Union(names2).Except(names1.Intersect(names2));
            //var query = from table in leftTable where table.Fields.Equals(
            //tableList = leftTable.Except<Table>(rightTable);
            // Get the list of tables for connection 1

            // Get the list of tables for connection 2

            // Compare
            /*
            IEnumerable<string> leftList = leftTables.Cast<string>();
            IEnumerable<string> rightList = rightTables.Cast<string>();

            IEnumerable<string> fulllList = leftList.Except<string>(rightList);
            IEnumerable<string> fulllList2 = rightList.Except<string>(leftList);
            fulllList.Concat<string>(fulllList2);

            foreach (string tab in fulllList)
            {
                Console.WriteLine(tab);
            }

            
           //var list = Enumerable.SequenceEqual(tables1, tables2);
            IEnumerable<string> lt = rightTables.Cast<string>();

            foreach (string tab in leftTables)
            {
                if (lt.Contains<string>(tab) == false)
                {
                    Console.WriteLine(tab);
                }
            }*/
        }

        #endregion
    }
}
