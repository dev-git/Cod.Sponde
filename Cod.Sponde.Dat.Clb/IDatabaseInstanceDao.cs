using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Cod.Sponde.Blt.Clb;

namespace Cod.Sponde.Dat.Clb
{
    public interface IDatabaseInstanceDao
    {
        IList<SqlServerInstance> GetSqlServerInstances(bool getLocalOnly);

        Array GetDatabases(string instanceName);

        Array GetDatabasesExtended(string instanceName);

        Array GetTables(string instanceName, string database);
    }
}
