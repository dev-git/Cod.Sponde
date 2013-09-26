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
    public partial class MainForm : Form
    {
        private FacadeService facadeService = new FacadeService();
        private SqlServerInstanceDto sqlServerInstanceDto = new SqlServerInstanceDto();
        private TableDto tableDto = new TableDto();
        private const string masterConnString = "server={0};initial catalog={1};user id=sa;password=sa123;";


        public MainForm()
        {
            InitializeComponent();

            InitialiseGrid();
           
        }

        private void InitialiseGrid()
        {
            DataGridViewCheckBoxColumn cbCol = new DataGridViewCheckBoxColumn();
            {
                cbCol.Name = "select";
                cbCol.HeaderText = "Select";
                cbCol.Width = 60;
            }

            grdLeftDatabase.Columns.Add(cbCol);

            grdLeftDatabase.Columns.Add("databases", "Database");
            grdLeftDatabase.Columns["databases"].Width = 207;

            DataGridViewCheckBoxColumn cbCol2 = new DataGridViewCheckBoxColumn();
            {
                cbCol2.Name = "select";
                cbCol2.HeaderText = "Select";
                cbCol2.Width = 60;
            }

            grdRightDatabase.Columns.Add(cbCol2);

            grdRightDatabase.Columns.Add("databases", "Database");
            grdRightDatabase.Columns["databases"].Width = 207;


            /*grdDatabase.Columns.Add("tables", "Tables");
            grdDatabase.Columns["tables"].Width = 80;
            
            grdDatabase.Columns.Add("fields", "Fields");
            grdDatabase.Columns["fields"].Width = 80;*/
            ;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        public IEnumerable<SqlServerInstanceDto> GetSqlServerInstances(FacadeService facade, bool localOnly)
        {
            IEnumerable<SqlServerInstanceDto> sqlServerInstances = null;
            try
            {
                sqlServerInstances = facade.GetSqlServerInstances(localOnly);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Failed", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            return sqlServerInstances;
         }

        public void PopulateServerList(IEnumerable<SqlServerInstanceDto> sqlServerList)
        {
            cmbLeftSqlServer.Items.Clear();
            cmbRightSqlServer.Items.Clear();
            
            if (chkLocalOnly.CheckState == CheckState.Checked)
            {
                if (sqlServerList != null)
                {
                    foreach (SqlServerInstanceDto sid in sqlServerList)
                    {
                        //cmbSqlServer.Items.Add(String.Format("{0};{1};{2}", sid.Machine.ToUpper(), sid.Name, sid.Version));
                        cmbLeftSqlServer.Items.Add(sid.Name);
                        cmbRightSqlServer.Items.Add(sid.Name);
                    }
                    // Populate the left hand side.
                    cmbLeftSqlServer.SelectedItem = cmbLeftSqlServer.Items[0];
                    GetDatabases(cmbLeftSqlServer.SelectedItem.ToString(), grdLeftDatabase);
                    // Now the right hand side.
                    cmbRightSqlServer.SelectedItem = cmbRightSqlServer.Items[0];
                    GetDatabases(cmbRightSqlServer.SelectedItem.ToString(), grdRightDatabase);
                }
            }
            else
            {
                cmbLeftSqlServer.Items.Add("(None)");
                cmbRightSqlServer.Items.Add("(None)");

                foreach (SqlServerInstanceDto sid in sqlServerList)
                {
                    //cmbSqlServer.Items.Add(String.Format("{0};{1};{2}", sid.Machine.ToUpper(), sid.Name, sid.Version));
                    cmbLeftSqlServer.Items.Add(sid.Name);
                    cmbRightSqlServer.Items.Add(sid.Name);
                }
                cmbLeftSqlServer.SelectedItem = cmbLeftSqlServer.Items[0];
                GetDatabases(cmbLeftSqlServer.SelectedItem.ToString(), grdLeftDatabase);
                cmbRightSqlServer.SelectedItem = cmbRightSqlServer.Items[0];
                GetDatabases(cmbRightSqlServer.SelectedItem.ToString(), grdRightDatabase);
            }

        }

        public void GetDatabases(string instanceName, DataGridView dgv)
        {
            dgv.Rows.Clear();
            try
            {
                if (instanceName != "(None)")
                {
                    Array databases = facadeService.GetDatabases(instanceName);
                    foreach (string db in databases)
                    {
                        dgv.Rows.Add(false, db);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Failed", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        public void GetDatabasesExtended(string instanceName, DataGridView dgv)
        {
            grdLeftDatabase.Rows.Clear();
            try
            {
                  /*

                Array databases = facadeService.GetDatabasesExtended(instanceName);
                if (databases != null)
                {
                    for (int xx = 0; xx < databases.Length / 3; xx++)
                    {
                        grdDatabase.Rows.Add(false, databases.GetValue(xx, 0));
                        grdDatabase.Rows[xx].Cells["tables"].Value = databases.GetValue(xx, 1);
                        grdDatabase.Rows[xx].Cells["fields"].Value = databases.GetValue(xx, 2);
                    }

                   
                }*/
            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message, "Failed", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void cmbSqlServer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbLeftSqlServer.SelectedIndex != 0)
            {
                GetDatabases(cmbLeftSqlServer.SelectedItem.ToString(), grdLeftDatabase);
            }
        }

        private void cmbSqlServer2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbRightSqlServer.SelectedIndex != 0)
            {
                GetDatabases(cmbRightSqlServer.SelectedItem.ToString(), grdRightDatabase);
            }
        }

        private void GetTables(string database)
        {
            //MessageBox.Show(database);
            Array tables = facadeService.GetTables(cmbLeftSqlServer.SelectedItem.ToString(), database);
            TableList tableList = new TableList(tables);
            tableList.Show(this);
        }

        private void grdDatabase_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                String database = (String)grdLeftDatabase.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                GetTables(database);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Failed", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            statusLabel.Text = "Retrieving SQL Servers...";
            progressBar.Visible = true;
            progressBar.MarqueeAnimationSpeed = 40;
            
            backgroundWorker1.RunWorkerAsync(facadeService);
        }

        private void btnCompare_Click(object sender, EventArgs e)
        {
            CompareDatabases();
 
        }

        private void CompareDatabases()
        {
            string leftDatabase = String.Format(masterConnString, cmbLeftSqlServer.SelectedItem.ToString(), GetSelectedDatabase(grdLeftDatabase));
            string rightDatabase = String.Format(masterConnString, cmbRightSqlServer.SelectedItem.ToString(), GetSelectedDatabase(grdRightDatabase));
  
            IEnumerable<TableDto> tables = facadeService.GetExceptionsTableDetails(leftDatabase, rightDatabase);
            TableList tableList = new TableList(tables);
            tableList.Show(this);

          

            //MessageBox.Show(String.Format("Comparing database {0} and {1}.", database1, database2));
        }

        private string GetSelectedDatabase(DataGridView grdDatabase)
        {
            string database = String.Empty;
            foreach (DataGridViewRow dgvr in grdDatabase.Rows)
            {
                bool selected = (bool)dgvr.Cells[0].Value;
                if (selected == true)
                {
                    database = (string)(dgvr.Cells[1].Value);
                    break;
                }
            }
            return database;
        }

        private void grd2ndDatabase_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            String database = (String)grdRightDatabase.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
            IEnumerable<TableDto> tables = facadeService.GetTableDetails(String.Format(masterConnString, cmbRightSqlServer.SelectedItem.ToString(), database));
            TableList tableList = new TableList(tables);
            tableList.Show(this);
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            e.Result = GetSqlServerInstances((FacadeService)e.Argument, chkLocalOnly.Checked);

        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
           
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            PopulateServerList(e.Result as IEnumerable<SqlServerInstanceDto>);
            statusLabel.Text = "SQL Server list retrieved.";
            progressBar.Visible = false;
           
        }
    }
}
