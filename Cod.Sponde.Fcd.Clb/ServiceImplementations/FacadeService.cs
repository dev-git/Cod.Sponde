using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Cod.Sponde.Fcd.Clb.ServiceContracts;
using Cod.Sponde.Fcd.Clb.DataTransferObjectMapper;
using Cod.Sponde.Blt.Clb;
using Cod.Sponde.Dat.Clb;

namespace Cod.Sponde.Fcd.Clb.ServiceImplementations
{
    public class FacadeService : IFacadeService
    {
        private IDatabaseInstanceDao databaseInstanceDao = DataAccess.DatabaseInstanceDao;
        private ITableDao tableDao = DataAccess.TableDao;

        public IEnumerable<SqlServerInstanceDto> GetSqlServerInstances(bool getLocalOnly)
        {
            IEnumerable<SqlServerInstance> sqlServerInstances = databaseInstanceDao.GetSqlServerInstances(getLocalOnly);
            return sqlServerInstances.Select(c => Mapper.ToDataTransferObject(c)).ToList();

            /*IList<SqlServerInstance> sqlServerInstances = databaseInstanceDao.GetSqlServerInstances();
            foreach (SqlServerInstance ssi in sqlServerInstances)
            {

            }*/

        }

        public Array GetDatabases(string instanceName)
        {
            return databaseInstanceDao.GetDatabases(instanceName);
        }

        public Array GetDatabasesExtended(string instanceName)
        {
            return databaseInstanceDao.GetDatabasesExtended(instanceName);
        }
        /*public IList<SqlServerInstance> GetSqlServerInstances()
        {
            return databaseInstanceDao.GetSqlServerInstances();
        }*/

        public Array GetTables(string instanceName, string database)
        {
            return databaseInstanceDao.GetTables(instanceName, database);
        }

        public IEnumerable<TableDto> GetTableDetails(string connectionString)
        {
            IEnumerable<Table> tables = tableDao.GetTableDetails(connectionString);
            
            return tables.Select(t => Mapper.ToDataTransferObject(t)).ToList();
            
        }

        public IEnumerable<TableDto> GetExceptionsTableDetails(string connectionString1, string connectionString2)
        {
            IEnumerable<Table> tables = tableDao.GetExceptionsTableDetails(connectionString1, connectionString2);

            return tables.Select(t => Mapper.ToDataTransferObject(t)).ToList();

        }
    }
}
