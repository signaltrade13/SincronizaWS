namespace SincronizaApp
{
    partial class FormMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.fswServerB = new System.IO.FileSystemWatcher();
            this.fswServerC = new System.IO.FileSystemWatcher();
            this.panel1 = new System.Windows.Forms.Panel();
            this.bUpdate = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.gvServidorB = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.gvServidorC = new System.Windows.Forms.DataGridView();
            this.tmrLoop = new System.Windows.Forms.Timer(this.components);
            this.niApp = new System.Windows.Forms.NotifyIcon(this.components);
            this.TableName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Accion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tabla1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Accion2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.fswServerB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fswServerC)).BeginInit();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvServidorB)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvServidorC)).BeginInit();
            this.SuspendLayout();
            // 
            // fswServerB
            // 
            this.fswServerB.EnableRaisingEvents = true;
            this.fswServerB.Filter = "*.sync";
            this.fswServerB.SynchronizingObject = this;
            this.fswServerB.Created += new System.IO.FileSystemEventHandler(this.fswServerB_Created);
            // 
            // fswServerC
            // 
            this.fswServerC.EnableRaisingEvents = true;
            this.fswServerC.Filter = "*.sync";
            this.fswServerC.SynchronizingObject = this;
            this.fswServerC.Created += new System.IO.FileSystemEventHandler(this.fswServerC_Created);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.bUpdate);
            this.panel1.Controls.Add(this.lblStatus);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(10, 10);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(3);
            this.panel1.Size = new System.Drawing.Size(742, 34);
            this.panel1.TabIndex = 0;
            // 
            // bUpdate
            // 
            this.bUpdate.Dock = System.Windows.Forms.DockStyle.Left;
            this.bUpdate.Enabled = false;
            this.bUpdate.Location = new System.Drawing.Point(3, 3);
            this.bUpdate.Name = "bUpdate";
            this.bUpdate.Size = new System.Drawing.Size(124, 28);
            this.bUpdate.TabIndex = 1;
            this.bUpdate.Text = "Actualizar";
            this.bUpdate.UseVisualStyleBackColor = true;
            // 
            // lblStatus
            // 
            this.lblStatus.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(404, 3);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(335, 28);
            this.lblStatus.TabIndex = 0;
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(10, 44);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(742, 428);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.gvServidorB);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(734, 402);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Servidor 1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // gvServidorB
            // 
            this.gvServidorB.AllowUserToAddRows = false;
            this.gvServidorB.AllowUserToDeleteRows = false;
            this.gvServidorB.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvServidorB.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TableName,
            this.Accion,
            this.Fecha});
            this.gvServidorB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvServidorB.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gvServidorB.Location = new System.Drawing.Point(3, 3);
            this.gvServidorB.Name = "gvServidorB";
            this.gvServidorB.Size = new System.Drawing.Size(728, 396);
            this.gvServidorB.TabIndex = 0;
            this.gvServidorB.SelectionChanged += new System.EventHandler(this.gvServidor_SelectionChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.gvServidorC);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(734, 402);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Servidor 2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // gvServidorC
            // 
            this.gvServidorC.AllowUserToAddRows = false;
            this.gvServidorC.AllowUserToDeleteRows = false;
            this.gvServidorC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvServidorC.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Tabla1,
            this.Accion2,
            this.Fecha2});
            this.gvServidorC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvServidorC.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gvServidorC.Location = new System.Drawing.Point(3, 3);
            this.gvServidorC.Name = "gvServidorC";
            this.gvServidorC.Size = new System.Drawing.Size(728, 396);
            this.gvServidorC.TabIndex = 0;
            this.gvServidorC.SelectionChanged += new System.EventHandler(this.gvServidor_SelectionChanged);
            // 
            // tmrLoop
            // 
            this.tmrLoop.Enabled = true;
            this.tmrLoop.Interval = 3000;
            this.tmrLoop.Tick += new System.EventHandler(this.tmrLoop_Tick);
            // 
            // niApp
            // 
            this.niApp.Icon = ((System.Drawing.Icon)(resources.GetObject("niApp.Icon")));
            this.niApp.Text = "Sincroniza";
            this.niApp.Visible = true;
            this.niApp.BalloonTipClicked += new System.EventHandler(this.niApp_BalloonTipClicked);
            this.niApp.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.niApp_MouseDoubleClick);
            // 
            // TableName
            // 
            this.TableName.DataPropertyName = "TableName";
            this.TableName.HeaderText = "Tabla";
            this.TableName.Name = "TableName";
            this.TableName.Width = 300;
            // 
            // Accion
            // 
            this.Accion.DataPropertyName = "ActionName";
            this.Accion.HeaderText = "Accion";
            this.Accion.Name = "Accion";
            this.Accion.Width = 150;
            // 
            // Fecha
            // 
            this.Fecha.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Fecha.DataPropertyName = "Fecha";
            this.Fecha.HeaderText = "Fecha";
            this.Fecha.Name = "Fecha";
            // 
            // Tabla1
            // 
            this.Tabla1.DataPropertyName = "TableName";
            this.Tabla1.HeaderText = "Tabla";
            this.Tabla1.Name = "Tabla1";
            this.Tabla1.Width = 300;
            // 
            // Accion2
            // 
            this.Accion2.DataPropertyName = "ActionName";
            this.Accion2.HeaderText = "Accion";
            this.Accion2.Name = "Accion2";
            this.Accion2.Width = 150;
            // 
            // Fecha2
            // 
            this.Fecha2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Fecha2.DataPropertyName = "Fecha";
            this.Fecha2.HeaderText = "Fecha";
            this.Fecha2.Name = "Fecha2";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(762, 482);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMain";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Text = "Sincroniza v18.10";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.Resize += new System.EventHandler(this.FormMain_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.fswServerB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fswServerC)).EndInit();
            this.panel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvServidorB)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvServidorC)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.IO.FileSystemWatcher fswServerB;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView gvServidorB;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel1;
        private System.IO.FileSystemWatcher fswServerC;
        private System.Windows.Forms.DataGridView gvServidorC;
        private System.Windows.Forms.Timer tmrLoop;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button bUpdate;
        private System.Windows.Forms.NotifyIcon niApp;
        private System.Windows.Forms.DataGridViewTextBoxColumn TableName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Accion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tabla1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Accion2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha2;
    }
}