namespace SincronizaApp
{
    partial class _MainForm
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(_MainForm));
            this.fswSvrA = new System.IO.FileSystemWatcher();
            this.niApp = new System.Windows.Forms.NotifyIcon(this.components);
            this.cmNI = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mostrarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gvServerB = new System.Windows.Forms.DataGridView();
            this.Tabla = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Accion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bSyncNow = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.gvServerC = new System.Windows.Forms.DataGridView();
            this.fswSvrC = new System.IO.FileSystemWatcher();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.fswSvrA)).BeginInit();
            this.cmNI.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvServerB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvServerC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fswSvrC)).BeginInit();
            this.SuspendLayout();
            // 
            // fswSvrA
            // 
            this.fswSvrA.EnableRaisingEvents = true;
            this.fswSvrA.Filter = "*.sync";
            this.fswSvrA.SynchronizingObject = this;
            this.fswSvrA.Created += new System.IO.FileSystemEventHandler(this.fswSvrA_Created);
            // 
            // niApp
            // 
            this.niApp.Icon = ((System.Drawing.Icon)(resources.GetObject("niApp.Icon")));
            this.niApp.Text = "SincronizaApp";
            this.niApp.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.niApp_MouseDoubleClick);
            this.niApp.MouseUp += new System.Windows.Forms.MouseEventHandler(this.niApp_MouseUp);
            // 
            // cmNI
            // 
            this.cmNI.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mostrarToolStripMenuItem});
            this.cmNI.Name = "cmNI";
            this.cmNI.Size = new System.Drawing.Size(116, 26);
            // 
            // mostrarToolStripMenuItem
            // 
            this.mostrarToolStripMenuItem.Name = "mostrarToolStripMenuItem";
            this.mostrarToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.mostrarToolStripMenuItem.Text = "Mostrar";
            this.mostrarToolStripMenuItem.Click += new System.EventHandler(this.mostrarToolStripMenuItem_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(676, 374);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.gvServerB);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(668, 348);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Servidor B";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.gvServerC);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(668, 348);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Servidor C";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblStatus);
            this.panel1.Controls.Add(this.bSyncNow);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 374);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(676, 37);
            this.panel1.TabIndex = 2;
            // 
            // gvServerB
            // 
            this.gvServerB.AllowUserToAddRows = false;
            this.gvServerB.AllowUserToDeleteRows = false;
            this.gvServerB.AllowUserToResizeRows = false;
            this.gvServerB.BackgroundColor = System.Drawing.SystemColors.Window;
            this.gvServerB.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvServerB.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Tabla,
            this.Accion,
            this.Fecha});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gvServerB.DefaultCellStyle = dataGridViewCellStyle1;
            this.gvServerB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvServerB.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gvServerB.Location = new System.Drawing.Point(3, 3);
            this.gvServerB.MultiSelect = false;
            this.gvServerB.Name = "gvServerB";
            this.gvServerB.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.gvServerB.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvServerB.ShowCellErrors = false;
            this.gvServerB.Size = new System.Drawing.Size(662, 342);
            this.gvServerB.TabIndex = 0;
            this.gvServerB.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.gvServerB_CellFormatting);
            this.gvServerB.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.gvServerB_RowPrePaint);
            this.gvServerB.SelectionChanged += new System.EventHandler(this.gvServerB_SelectionChanged);
            // 
            // Tabla
            // 
            this.Tabla.DataPropertyName = "TableName";
            this.Tabla.Frozen = true;
            this.Tabla.HeaderText = "Tabla";
            this.Tabla.Name = "Tabla";
            this.Tabla.Width = 200;
            // 
            // Accion
            // 
            this.Accion.DataPropertyName = "ActionName";
            this.Accion.Frozen = true;
            this.Accion.HeaderText = "Acción";
            this.Accion.Name = "Accion";
            this.Accion.Width = 200;
            // 
            // Fecha
            // 
            this.Fecha.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Fecha.DataPropertyName = "Fecha";
            this.Fecha.HeaderText = "Fecha";
            this.Fecha.Name = "Fecha";
            // 
            // bSyncNow
            // 
            this.bSyncNow.Location = new System.Drawing.Point(576, 5);
            this.bSyncNow.Name = "bSyncNow";
            this.bSyncNow.Size = new System.Drawing.Size(88, 29);
            this.bSyncNow.TabIndex = 0;
            this.bSyncNow.Text = "Sync Now";
            this.bSyncNow.UseVisualStyleBackColor = true;
            this.bSyncNow.Click += new System.EventHandler(this.bSyncNow_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(12, 5);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(35, 13);
            this.lblStatus.TabIndex = 1;
            this.lblStatus.Text = "label1";
            // 
            // gvServerC
            // 
            this.gvServerC.AllowUserToAddRows = false;
            this.gvServerC.AllowUserToDeleteRows = false;
            this.gvServerC.AllowUserToResizeRows = false;
            this.gvServerC.BackgroundColor = System.Drawing.SystemColors.Window;
            this.gvServerC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvServerC.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gvServerC.DefaultCellStyle = dataGridViewCellStyle2;
            this.gvServerC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvServerC.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gvServerC.Location = new System.Drawing.Point(3, 3);
            this.gvServerC.MultiSelect = false;
            this.gvServerC.Name = "gvServerC";
            this.gvServerC.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.gvServerC.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvServerC.ShowCellErrors = false;
            this.gvServerC.Size = new System.Drawing.Size(662, 342);
            this.gvServerC.TabIndex = 1;
            // 
            // fswSvrC
            // 
            this.fswSvrC.EnableRaisingEvents = true;
            this.fswSvrC.Filter = "*.sync";
            this.fswSvrC.SynchronizingObject = this;
            this.fswSvrC.Created += new System.IO.FileSystemEventHandler(this.fswSvrC_Created);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "TableName";
            this.dataGridViewTextBoxColumn1.Frozen = true;
            this.dataGridViewTextBoxColumn1.HeaderText = "Tabla";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 200;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "ActionName";
            this.dataGridViewTextBoxColumn2.Frozen = true;
            this.dataGridViewTextBoxColumn2.HeaderText = "Acción";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 200;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Fecha";
            this.dataGridViewTextBoxColumn3.HeaderText = "Fecha";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(676, 411);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Sincroniza App";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.fswSvrA)).EndInit();
            this.cmNI.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvServerB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvServerC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fswSvrC)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.IO.FileSystemWatcher fswSvrA;
        private System.Windows.Forms.NotifyIcon niApp;
        private System.Windows.Forms.ContextMenuStrip cmNI;
        private System.Windows.Forms.ToolStripMenuItem mostrarToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView gvServerB;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tabla;
        private System.Windows.Forms.DataGridViewTextBoxColumn Accion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.Button bSyncNow;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.DataGridView gvServerC;
        private System.IO.FileSystemWatcher fswSvrC;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
    }
}

