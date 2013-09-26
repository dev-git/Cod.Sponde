using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cod.Sponde.Fcd.Clb.ServiceContracts
{
    public interface IFacadeService
    {
         IEnumerable<SqlServerInstanceDto> GetSqlServerInstances(bool getLocalOnly);

         Array GetDatabases(string instanceName);

         Array GetDatabasesExtended(string instanceName);

        Array GetTables(string instanceName, string databaseName);

        IEnumerable<TableDto> GetTableDetails(string connectionString);

        IEnumerable<TableDto> GetExceptionsTableDetails(string connectionString1, string connectionString2);
    }
}
