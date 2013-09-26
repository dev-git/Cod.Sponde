using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Cod.Sponde.Fcd.Clb;
using Cod.Sponde.Fcd.Clb.ServiceImplementations;

namespace Cod.Sponde.Uit.Win
{
    public partial class TableList : Form
    {
        public TableList()
        {
            InitializeComponent();

            grdTable.Columns.Add("database", "Database");
            grdTable.Columns["database"].Width = 150;

            grdTable.Columns.Add("tables", "Table");
            grdTable.Columns["tables"].Width = 150;
        }

        public TableList(Array tableList)
            : this()
        {
            PopulateTableList(tableList);
            txtTotal.Text = (tableList.Length + 1).ToString();
        }

        public TableList(IEnumerable<TableDto> tableList)
            : this()
        {
            ExpandGrid();
            PopulateExpandedGrid(tableList);
        }

        private void PopulateExpandedGrid(IEnumerable<TableDto> tableList)
        {
            foreach (TableDto table in tableList)
            {
                grdTable.Rows.Add(table.DatabaseName, table.TableName, table.FieldName, table.FieldType, table.FieldPrecision, table.FieldScale, table.FieldIsNullable);
            }
        }

        private void ExpandGrid()
        {
            grdTable.Columns.Add("field", "Field");
            grdTable.Columns["field"].Width = 150;
            
            grdTable.Columns.Add("type", "Type");
            grdTable.Columns["type"].Width = 70;

            grdTable.Columns.Add("precision", "Precision");
            grdTable.Columns["precision"].Width = 70;

            grdTable.Columns.Add("scale", "Scale");
            grdTable.Columns["scale"].Width = 70;

            grdTable.Columns.Add("isnullable", "IsNullable");
            grdTable.Columns["isnullable"].Width = 70;

        }

        private void PopulateTableList(Array tableList)
        {
            grdTable.Rows.Clear();
            if (tableList != null)
            {
                foreach (string table in tableList)
                {
                    grdTable.Rows.Add(table);
                }
            }
        }
    }
}
