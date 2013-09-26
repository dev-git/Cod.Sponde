using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cod.Sponde.Dat.Clb
{
    public class DataAccess
    {
        public static IDatabaseInstanceDao DatabaseInstanceDao
        {
            get { return new DatabaseInstanceDao(); }
        }

        public static ITableDao TableDao
        {
            get { return new TableDao(); }
        }
    }
}
