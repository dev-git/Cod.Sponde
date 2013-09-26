namespace Cod.Sponde.Uit.Win
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnExit = new System.Windows.Forms.Button();
            this.cmbLeftSqlServer = new System.Windows.Forms.ComboBox();
            this.grdLeftDatabase = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnCompare = new System.Windows.Forms.Button();
            this.grdRightDatabase = new System.Windows.Forms.DataGridView();
            this.cmbRightSqlServer = new System.Windows.Forms.ComboBox();
            this.chkLocalOnly = new System.Windows.Forms.CheckBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.progressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.grdLeftDatabase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdRightDatabase)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(522, 398);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(82, 23);
            this.btnExit.TabIndex = 0;
            this.btnExit.Text = "&Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // cmbLeftSqlServer
            // 
            this.cmbLeftSqlServer.FormattingEnabled = true;
            this.cmbLeftSqlServer.Location = new System.Drawing.Point(21, 47);
            this.cmbLeftSqlServer.Name = "cmbLeftSqlServer";
            this.cmbLeftSqlServer.Size = new System.Drawing.Size(205, 23);
            this.cmbLeftSqlServer.TabIndex = 1;
            this.cmbLeftSqlServer.SelectedIndexChanged += new System.EventHandler(this.cmbSqlServer_SelectedIndexChanged);
            // 
            // grdLeftDatabase
            // 
            this.grdLeftDatabase.AllowUserToAddRows = false;
            this.grdLeftDatabase.AllowUserToDeleteRows = false;
            this.grdLeftDatabase.AllowUserToOrderColumns = true;
            this.grdLeftDatabase.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdLeftDatabase.Location = new System.Drawing.Point(21, 98);
            this.grdLeftDatabase.Name = "grdLeftDatabase";
            this.grdLeftDatabase.RowHeadersVisible = false;
            this.grdLeftDatabase.Size = new System.Drawing.Size(270, 282);
            this.grdLeftDatabase.TabIndex = 2;
            this.grdLeftDatabase.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdDatabase_CellDoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "SQL Server";
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(232, 48);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(66, 23);
            this.btnLoad.TabIndex = 4;
            this.btnLoad.Text = "&Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnCompare
            // 
            this.btnCompare.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCompare.Location = new System.Drawing.Point(422, 398);
            this.btnCompare.Name = "btnCompare";
            this.btnCompare.Size = new System.Drawing.Size(82, 23);
            this.btnCompare.TabIndex = 5;
            this.btnCompare.Text = "&Compare...";
            this.btnCompare.UseVisualStyleBackColor = true;
            this.btnCompare.Click += new System.EventHandler(this.btnCompare_Click);
            // 
            // grdRightDatabase
            // 
            this.grdRightDatabase.AllowUserToAddRows = false;
            this.grdRightDatabase.AllowUserToDeleteRows = false;
            this.grdRightDatabase.AllowUserToOrderColumns = true;
            this.grdRightDatabase.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdRightDatabase.Location = new System.Drawing.Point(335, 98);
            this.grdRightDatabase.Name = "grdRightDatabase";
            this.grdRightDatabase.RowHeadersVisible = false;
            this.grdRightDatabase.Size = new System.Drawing.Size(270, 282);
            this.grdRightDatabase.TabIndex = 6;
            this.grdRightDatabase.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grd2ndDatabase_CellDoubleClick);
            // 
            // cmbRightSqlServer
            // 
            this.cmbRightSqlServer.FormattingEnabled = true;
            this.cmbRightSqlServer.Location = new System.Drawing.Point(335, 48);
            this.cmbRightSqlServer.Name = "cmbRightSqlServer";
            this.cmbRightSqlServer.Size = new System.Drawing.Size(216, 23);
            this.cmbRightSqlServer.TabIndex = 7;
            this.cmbRightSqlServer.SelectedIndexChanged += new System.EventHandler(this.cmbSqlServer2_SelectedIndexChanged);
            // 
            // chkLocalOnly
            // 
            this.chkLocalOnly.AutoSize = true;
            this.chkLocalOnly.Checked = true;
            this.chkLocalOnly.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkLocalOnly.Location = new System.Drawing.Point(21, 403);
            this.chkLocalOnly.Name = "chkLocalOnly";
            this.chkLocalOnly.Size = new System.Drawing.Size(138, 19);
            this.chkLocalOnly.TabIndex = 8;
            this.chkLocalOnly.Text = "Local Only Databases";
            this.chkLocalOnly.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel,
            this.progressBar});
            this.statusStrip1.Location = new System.Drawing.Point(0, 436);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(641, 22);
            this.statusStrip1.TabIndex = 9;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // progressBar
            // 
            this.progressBar.MarqueeAnimationSpeed = 0;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(400, 16);
            this.progressBar.Step = 0;
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar.Visible = false;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(641, 458);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.chkLocalOnly);
            this.Controls.Add(this.cmbRightSqlServer);
            this.Controls.Add(this.grdRightDatabase);
            this.Controls.Add(this.btnCompare);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.grdLeftDatabase);
            this.Controls.Add(this.cmbLeftSqlServer);
            this.Controls.Add(this.btnExit);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "MainForm";
            this.Text = "Main Form";
            ((System.ComponentModel.ISupportInitialize)(this.grdLeftDatabase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdRightDatabase)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.ComboBox cmbLeftSqlServer;
        private System.Windows.Forms.DataGridView grdLeftDatabase;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnCompare;
        private System.Windows.Forms.DataGridView grdRightDatabase;
        private System.Windows.Forms.ComboBox cmbRightSqlServer;
        private System.Windows.Forms.CheckBox chkLocalOnly;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.ToolStripProgressBar progressBar;
    }
}

