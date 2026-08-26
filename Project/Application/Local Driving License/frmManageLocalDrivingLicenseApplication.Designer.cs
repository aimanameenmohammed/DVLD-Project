namespace FullRealLifeProject19
{
    partial class frmManageLocalDrivingLicenseApplication
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManageLocalDrivingLicenseApplication));
            this.txtFilteValue = new Guna.UI2.WinForms.Guna2TextBox();
            this.cmFitering = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showApplicationDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.editApplicationTSM = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteApplicationTSM = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.cancelApplicationTSM = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.sechduleTestsTSM = new System.Windows.Forms.ToolStripMenuItem();
            this.scheduleVisionTestTSM = new System.Windows.Forms.ToolStripMenuItem();
            this.scheduleWrittenTestTSM = new System.Windows.Forms.ToolStripMenuItem();
            this.scheduleStreetTestTSM = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.issueDrivingLicenseFirstTimeTSM = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.showLicenseTSM = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
            this.showPersonLicenseHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.lbRecords = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvLDLApplicationList = new Guna.UI2.WinForms.Guna2DataGridView();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CountryName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CurrencyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.currencyCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnClose = new Guna.UI2.WinForms.Guna2Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnAddUser = new Guna.UI2.WinForms.Guna2Button();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLDLApplicationList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtFilteValue
            // 
            this.txtFilteValue.BackColor = System.Drawing.Color.Transparent;
            this.txtFilteValue.BorderRadius = 5;
            this.txtFilteValue.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtFilteValue.DefaultText = "";
            this.txtFilteValue.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtFilteValue.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtFilteValue.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtFilteValue.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtFilteValue.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtFilteValue.Font = new System.Drawing.Font("Segoe UI Emoji", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFilteValue.ForeColor = System.Drawing.Color.Black;
            this.txtFilteValue.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtFilteValue.Location = new System.Drawing.Point(465, 393);
            this.txtFilteValue.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtFilteValue.Name = "txtFilteValue";
            this.txtFilteValue.PlaceholderText = "Search...";
            this.txtFilteValue.SelectedText = "";
            this.txtFilteValue.Size = new System.Drawing.Size(371, 41);
            this.txtFilteValue.TabIndex = 98;
            this.txtFilteValue.Visible = false;
            this.txtFilteValue.TextChanged += new System.EventHandler(this.txtFilteValue_TextChanged);
            this.txtFilteValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFilteValue_KeyPress);
            // 
            // cmFitering
            // 
            this.cmFitering.BackColor = System.Drawing.Color.Transparent;
            this.cmFitering.BorderRadius = 5;
            this.cmFitering.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmFitering.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmFitering.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmFitering.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmFitering.Font = new System.Drawing.Font("Segoe UI Emoji", 10.2F, System.Drawing.FontStyle.Bold);
            this.cmFitering.ForeColor = System.Drawing.Color.Black;
            this.cmFitering.ItemHeight = 30;
            this.cmFitering.Items.AddRange(new object[] {
            "None",
            "L.D.L.AppID",
            "National No.",
            "Full Name",
            "Status"});
            this.cmFitering.Location = new System.Drawing.Point(119, 396);
            this.cmFitering.Name = "cmFitering";
            this.cmFitering.Size = new System.Drawing.Size(303, 36);
            this.cmFitering.StartIndex = 0;
            this.cmFitering.TabIndex = 97;
            this.cmFitering.SelectedIndexChanged += new System.EventHandler(this.cmFitering_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(17, 401);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(91, 22);
            this.label9.TabIndex = 96;
            this.label9.Text = "Filter By:";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showApplicationDetailsToolStripMenuItem,
            this.toolStripMenuItem1,
            this.editApplicationTSM,
            this.deleteApplicationTSM,
            this.toolStripMenuItem2,
            this.cancelApplicationTSM,
            this.toolStripMenuItem3,
            this.sechduleTestsTSM,
            this.toolStripMenuItem4,
            this.issueDrivingLicenseFirstTimeTSM,
            this.toolStripMenuItem5,
            this.showLicenseTSM,
            this.toolStripMenuItem6,
            this.showPersonLicenseHistoryToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(309, 372);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // showApplicationDetailsToolStripMenuItem
            // 
            this.showApplicationDetailsToolStripMenuItem.Image = global::FullRealLifeProject19.Properties.Resources.PersonDetails_32;
            this.showApplicationDetailsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.showApplicationDetailsToolStripMenuItem.Name = "showApplicationDetailsToolStripMenuItem";
            this.showApplicationDetailsToolStripMenuItem.Size = new System.Drawing.Size(308, 38);
            this.showApplicationDetailsToolStripMenuItem.Text = "&Show Application Details";
            this.showApplicationDetailsToolStripMenuItem.Click += new System.EventHandler(this.showApplicationDetailsToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(305, 6);
            // 
            // editApplicationTSM
            // 
            this.editApplicationTSM.Image = global::FullRealLifeProject19.Properties.Resources.edit_321;
            this.editApplicationTSM.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.editApplicationTSM.Name = "editApplicationTSM";
            this.editApplicationTSM.Size = new System.Drawing.Size(308, 38);
            this.editApplicationTSM.Text = "&Edit Application";
            this.editApplicationTSM.Click += new System.EventHandler(this.editApplicationToolStripMenuItem_Click);
            // 
            // deleteApplicationTSM
            // 
            this.deleteApplicationTSM.Image = global::FullRealLifeProject19.Properties.Resources.Delete_32_2;
            this.deleteApplicationTSM.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.deleteApplicationTSM.Name = "deleteApplicationTSM";
            this.deleteApplicationTSM.Size = new System.Drawing.Size(308, 38);
            this.deleteApplicationTSM.Text = "&Delete Application";
            this.deleteApplicationTSM.Click += new System.EventHandler(this.deleteApplicationToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(305, 6);
            // 
            // cancelApplicationTSM
            // 
            this.cancelApplicationTSM.Image = global::FullRealLifeProject19.Properties.Resources.Delete_32;
            this.cancelApplicationTSM.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cancelApplicationTSM.Name = "cancelApplicationTSM";
            this.cancelApplicationTSM.Size = new System.Drawing.Size(308, 38);
            this.cancelApplicationTSM.Text = "&Cancel Application";
            this.cancelApplicationTSM.Click += new System.EventHandler(this.cancelApplicationTSM_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(305, 6);
            // 
            // sechduleTestsTSM
            // 
            this.sechduleTestsTSM.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.scheduleVisionTestTSM,
            this.scheduleWrittenTestTSM,
            this.scheduleStreetTestTSM});
            this.sechduleTestsTSM.Image = global::FullRealLifeProject19.Properties.Resources.TestType_321;
            this.sechduleTestsTSM.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.sechduleTestsTSM.Name = "sechduleTestsTSM";
            this.sechduleTestsTSM.Size = new System.Drawing.Size(308, 38);
            this.sechduleTestsTSM.Text = "Schedule &Tests";
            // 
            // scheduleVisionTestTSM
            // 
            this.scheduleVisionTestTSM.Image = global::FullRealLifeProject19.Properties.Resources.Vision_Test_32;
            this.scheduleVisionTestTSM.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.scheduleVisionTestTSM.Name = "scheduleVisionTestTSM";
            this.scheduleVisionTestTSM.Size = new System.Drawing.Size(247, 38);
            this.scheduleVisionTestTSM.Text = "Schedule Vision Test";
            this.scheduleVisionTestTSM.Click += new System.EventHandler(this.scheduleVisionTestTSM_Click);
            // 
            // scheduleWrittenTestTSM
            // 
            this.scheduleWrittenTestTSM.Image = global::FullRealLifeProject19.Properties.Resources.Written_Test_32;
            this.scheduleWrittenTestTSM.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.scheduleWrittenTestTSM.Name = "scheduleWrittenTestTSM";
            this.scheduleWrittenTestTSM.Size = new System.Drawing.Size(247, 38);
            this.scheduleWrittenTestTSM.Text = "Schedule Written Test";
            this.scheduleWrittenTestTSM.Click += new System.EventHandler(this.scheduleWrittenTestTSM_Click);
            // 
            // scheduleStreetTestTSM
            // 
            this.scheduleStreetTestTSM.Image = global::FullRealLifeProject19.Properties.Resources.Street_Test_32;
            this.scheduleStreetTestTSM.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.scheduleStreetTestTSM.Name = "scheduleStreetTestTSM";
            this.scheduleStreetTestTSM.Size = new System.Drawing.Size(247, 38);
            this.scheduleStreetTestTSM.Text = "Schedule Street Test";
            this.scheduleStreetTestTSM.Click += new System.EventHandler(this.scheduleStreetTestTSM_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(305, 6);
            // 
            // issueDrivingLicenseFirstTimeTSM
            // 
            this.issueDrivingLicenseFirstTimeTSM.Image = global::FullRealLifeProject19.Properties.Resources.IssueDrivingLicense_32;
            this.issueDrivingLicenseFirstTimeTSM.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.issueDrivingLicenseFirstTimeTSM.Name = "issueDrivingLicenseFirstTimeTSM";
            this.issueDrivingLicenseFirstTimeTSM.Size = new System.Drawing.Size(308, 38);
            this.issueDrivingLicenseFirstTimeTSM.Text = "&Issue Driving License (First Time)";
            this.issueDrivingLicenseFirstTimeTSM.Click += new System.EventHandler(this.issueDrivingLicenseFirstTimeTSM_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(305, 6);
            // 
            // showLicenseTSM
            // 
            this.showLicenseTSM.Image = global::FullRealLifeProject19.Properties.Resources.License_View_32;
            this.showLicenseTSM.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.showLicenseTSM.Name = "showLicenseTSM";
            this.showLicenseTSM.Size = new System.Drawing.Size(308, 38);
            this.showLicenseTSM.Text = "Show &License";
            this.showLicenseTSM.Click += new System.EventHandler(this.showLicenseTSM_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(305, 6);
            // 
            // showPersonLicenseHistoryToolStripMenuItem
            // 
            this.showPersonLicenseHistoryToolStripMenuItem.Image = global::FullRealLifeProject19.Properties.Resources.PersonLicenseHistory_32;
            this.showPersonLicenseHistoryToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.showPersonLicenseHistoryToolStripMenuItem.Name = "showPersonLicenseHistoryToolStripMenuItem";
            this.showPersonLicenseHistoryToolStripMenuItem.Size = new System.Drawing.Size(308, 38);
            this.showPersonLicenseHistoryToolStripMenuItem.Text = "Show Person License History";
            this.showPersonLicenseHistoryToolStripMenuItem.Click += new System.EventHandler(this.showPersonLicenseHistoryToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 27.8F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Firebrick;
            this.label1.Location = new System.Drawing.Point(611, 249);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(754, 62);
            this.label1.TabIndex = 100;
            this.label1.Text = "Local Driving License Application";
            // 
            // lbRecords
            // 
            this.lbRecords.AutoSize = true;
            this.lbRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.8F, System.Drawing.FontStyle.Bold);
            this.lbRecords.Location = new System.Drawing.Point(133, 1001);
            this.lbRecords.Name = "lbRecords";
            this.lbRecords.Size = new System.Drawing.Size(52, 26);
            this.lbRecords.TabIndex = 104;
            this.lbRecords.Text = "N/A";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.8F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(13, 1000);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 26);
            this.label2.TabIndex = 103;
            this.label2.Text = "#Records:";
            // 
            // dgvLDLApplicationList
            // 
            this.dgvLDLApplicationList.AllowUserToAddRows = false;
            this.dgvLDLApplicationList.AllowUserToDeleteRows = false;
            this.dgvLDLApplicationList.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvLDLApplicationList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvLDLApplicationList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Single;
            this.dgvLDLApplicationList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLDLApplicationList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvLDLApplicationList.ColumnHeadersHeight = 35;
            this.dgvLDLApplicationList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvLDLApplicationList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column4,
            this.clnID,
            this.CountryName,
            this.CurrencyName,
            this.currencyCode,
            this.Rate,
            this.Column1,
            this.dataGridViewTextBoxColumn1});
            this.dgvLDLApplicationList.ContextMenuStrip = this.contextMenuStrip1;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvLDLApplicationList.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvLDLApplicationList.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvLDLApplicationList.Location = new System.Drawing.Point(12, 442);
            this.dgvLDLApplicationList.Name = "dgvLDLApplicationList";
            this.dgvLDLApplicationList.ReadOnly = true;
            this.dgvLDLApplicationList.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLDLApplicationList.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvLDLApplicationList.RowHeadersVisible = false;
            this.dgvLDLApplicationList.RowHeadersWidth = 65;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.LightSkyBlue;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvLDLApplicationList.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvLDLApplicationList.RowTemplate.Height = 35;
            this.dgvLDLApplicationList.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLDLApplicationList.Size = new System.Drawing.Size(1900, 524);
            this.dgvLDLApplicationList.TabIndex = 107;
            this.dgvLDLApplicationList.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvLDLApplicationList.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.dgvLDLApplicationList.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvLDLApplicationList.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvLDLApplicationList.ThemeStyle.HeaderStyle.Height = 35;
            this.dgvLDLApplicationList.ThemeStyle.ReadOnly = true;
            this.dgvLDLApplicationList.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Single;
            this.dgvLDLApplicationList.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvLDLApplicationList.ThemeStyle.RowsStyle.Height = 35;
            this.dgvLDLApplicationList.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.LightSteelBlue;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column4.HeaderText = "";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 34;
            // 
            // clnID
            // 
            this.clnID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.clnID.DataPropertyName = "LocalDrivingLicenseApplicationID";
            this.clnID.HeaderText = "L.D.L.Application";
            this.clnID.MinimumWidth = 3;
            this.clnID.Name = "clnID";
            this.clnID.ReadOnly = true;
            this.clnID.Width = 200;
            // 
            // CountryName
            // 
            this.CountryName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.CountryName.DataPropertyName = "ClassName";
            this.CountryName.HeaderText = "Driving Class";
            this.CountryName.MinimumWidth = 6;
            this.CountryName.Name = "CountryName";
            this.CountryName.ReadOnly = true;
            this.CountryName.Width = 460;
            // 
            // CurrencyName
            // 
            this.CurrencyName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.CurrencyName.DataPropertyName = "NationalNo";
            this.CurrencyName.HeaderText = "National No.";
            this.CurrencyName.MinimumWidth = 6;
            this.CurrencyName.Name = "CurrencyName";
            this.CurrencyName.ReadOnly = true;
            this.CurrencyName.Width = 200;
            // 
            // currencyCode
            // 
            this.currencyCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.currencyCode.DataPropertyName = "FullName";
            this.currencyCode.HeaderText = "Full Name";
            this.currencyCode.MinimumWidth = 6;
            this.currencyCode.Name = "currencyCode";
            this.currencyCode.ReadOnly = true;
            this.currencyCode.Width = 430;
            // 
            // Rate
            // 
            this.Rate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Rate.DataPropertyName = "ApplicationDate";
            this.Rate.HeaderText = "Application Date";
            this.Rate.MinimumWidth = 6;
            this.Rate.Name = "Rate";
            this.Rate.ReadOnly = true;
            this.Rate.Width = 250;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column1.DataPropertyName = "PassedTestCount";
            this.Column1.HeaderText = "Passed Test";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 200;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Status";
            this.dataGridViewTextBoxColumn1.HeaderText = "Status";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 125;
            // 
            // btnClose
            // 
            this.btnClose.BorderColor = System.Drawing.Color.Gainsboro;
            this.btnClose.BorderRadius = 5;
            this.btnClose.BorderThickness = 1;
            this.btnClose.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnClose.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnClose.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnClose.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnClose.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnClose.FillColor = System.Drawing.Color.Transparent;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI Emoji", 11.2F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.Black;
            this.btnClose.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageOffset = new System.Drawing.Point(-10, 1);
            this.btnClose.ImageSize = new System.Drawing.Size(25, 25);
            this.btnClose.Location = new System.Drawing.Point(1701, 988);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(211, 47);
            this.btnClose.TabIndex = 105;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::FullRealLifeProject19.Properties.Resources.Local_321;
            this.pictureBox2.Location = new System.Drawing.Point(1084, 102);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(102, 92);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 102;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::FullRealLifeProject19.Properties.Resources.Applications;
            this.pictureBox1.Location = new System.Drawing.Point(732, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(468, 243);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 101;
            this.pictureBox1.TabStop = false;
            // 
            // btnAddUser
            // 
            this.btnAddUser.BorderColor = System.Drawing.Color.Gainsboro;
            this.btnAddUser.BorderRadius = 5;
            this.btnAddUser.BorderThickness = 1;
            this.btnAddUser.CheckedState.FillColor = System.Drawing.Color.LightSkyBlue;
            this.btnAddUser.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAddUser.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAddUser.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAddUser.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAddUser.FillColor = System.Drawing.Color.Transparent;
            this.btnAddUser.Font = new System.Drawing.Font("Segoe UI Emoji", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddUser.ForeColor = System.Drawing.Color.Black;
            this.btnAddUser.HoverState.FillColor = System.Drawing.Color.LightBlue;
            this.btnAddUser.Image = global::FullRealLifeProject19.Properties.Resources.New_Application_64;
            this.btnAddUser.ImageOffset = new System.Drawing.Point(1, 1);
            this.btnAddUser.ImageSize = new System.Drawing.Size(60, 60);
            this.btnAddUser.Location = new System.Drawing.Point(1772, 370);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new System.Drawing.Size(140, 62);
            this.btnAddUser.TabIndex = 99;
            this.btnAddUser.Click += new System.EventHandler(this.btnAddUser_Click);
            // 
            // frmManageLocalDrivingLicenseApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1924, 1055);
            this.Controls.Add(this.dgvLDLApplicationList);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lbRecords);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAddUser);
            this.Controls.Add(this.txtFilteValue);
            this.Controls.Add(this.cmFitering);
            this.Controls.Add(this.label9);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "frmManageLocalDrivingLicenseApplication";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manage Local Driving License Application";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmManageLocalDrivingLicenseApplication_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLDLApplicationList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Guna.UI2.WinForms.Guna2Button btnAddUser;
        private Guna.UI2.WinForms.Guna2TextBox txtFilteValue;
        private Guna.UI2.WinForms.Guna2ComboBox cmFitering;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private Guna.UI2.WinForms.Guna2Button btnClose;
        private System.Windows.Forms.Label lbRecords;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem showApplicationDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem editApplicationTSM;
        private System.Windows.Forms.ToolStripMenuItem deleteApplicationTSM;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem cancelApplicationTSM;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem sechduleTestsTSM;
        private System.Windows.Forms.ToolStripMenuItem scheduleVisionTestTSM;
        private System.Windows.Forms.ToolStripMenuItem scheduleWrittenTestTSM;
        private System.Windows.Forms.ToolStripMenuItem scheduleStreetTestTSM;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem issueDrivingLicenseFirstTimeTSM;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem showLicenseTSM;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem showPersonLicenseHistoryToolStripMenuItem;
        private Guna.UI2.WinForms.Guna2DataGridView dgvLDLApplicationList;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnID;
        private System.Windows.Forms.DataGridViewTextBoxColumn CountryName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CurrencyName;
        private System.Windows.Forms.DataGridViewTextBoxColumn currencyCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
    }
}