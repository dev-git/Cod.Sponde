using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Cod.Sponde.Blt.Clb;

namespace Cod.Sponde.Dat.Clb
{
    public class DatabaseInstanceDao : IDatabaseInstanceDao
    {
        public IList<SqlServerInstance> GetSqlServerInstances(bool getLocalOnly)
        {
            SqlServerInstance sqlServerInstance = new SqlServerInstance();
            return sqlServerInstance.GetSqlServerInstances(getLocalOnly);
        }

        public Array GetDatabases(string instanceName)
        {
            return SqlServerInstance.GetDatabases(instanceName);
        }

        public Array GetDatabasesExtended(string instanceName)
        {
            return SqlServerInstance.GetDatabasesExtended(instanceName);
        }


        public Array GetTables(string instanceName, string databaseName)
        {
            return SqlServerInstance.GetTables(instanceName, databaseName);
        }
    }
}
