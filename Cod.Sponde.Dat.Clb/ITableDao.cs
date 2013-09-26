using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Cod.Sponde.Blt.Clb;

namespace Cod.Sponde.Dat.Clb
{
    public interface ITableDao
    {
        IList<Table> GetTables(string server, string database, bool trustedConnection);

        IList<Table> GetTablesExtended(string server, string database, bool trustedConnection);

        IList<Table> GetMissingTables(string server, string database, bool trustedConnection);

        IList<Table> GetMissingTablesExtended(string server, string database, bool trustedConnection);

        IList<Table> GetTableDetails(string connectionString);

        /// <summary>
        /// Compares two databases and returns a list of missing tables with field information
        /// </summary>
        /// <param name="connectionString1"></param>
        /// <param name="connectionString2"></param>
        /// <returns></returns>
        IList<Table> GetExceptionsTableDetails(string connectionString1, string connectionString2);
    }
}
