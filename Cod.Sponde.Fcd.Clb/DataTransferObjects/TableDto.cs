using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cod.Sponde.Fcd.Clb
{
    public class TableDto
    {
        public string DatabaseName { get; set; }

        public string TableName { get; set; }

        public string FieldName { get; set; }

        public string FieldType { get; set; }

        public int FieldPrecision { get; set; }

        public int FieldScale { get; set; }

        public bool FieldIsNullable { get; set; }
    }
}
