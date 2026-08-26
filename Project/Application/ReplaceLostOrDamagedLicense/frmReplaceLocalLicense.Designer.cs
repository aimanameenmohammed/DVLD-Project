namespace FullRealLifeProject19
{
    partial class frmReplaceLocalLicense
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReplaceLocalLicense));
            this.lbltitle = new System.Windows.Forms.Label();
            this.ctrlDrivingLicenseInfoWithFiltering1 = new FullRealLifeProject19.ctrlDrivingLicenseInfoWithFiltering();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lb7 = new System.Windows.Forms.Label();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.lblCreatedByUser = new System.Windows.Forms.Label();
            this.lblApplicationFees = new System.Windows.Forms.Label();
            this.lb3 = new System.Windows.Forms.Label();
            this.lb5 = new System.Windows.Forms.Label();
            this.lblReplacedLicenseID = new System.Windows.Forms.Label();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.pictureBox10 = new System.Windows.Forms.PictureBox();
            this.lb1 = new System.Windows.Forms.Label();
            this.pictureBox9 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.lb4 = new System.Windows.Forms.Label();
            this.lblApplicationDate = new System.Windows.Forms.Label();
            this.lblReplacementApplicationID = new System.Windows.Forms.Label();
            this.lb = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.lblOldLicenseID = new System.Windows.Forms.Label();
            this.llShowLicenseInfo = new System.Windows.Forms.LinkLabel();
            this.llShowLicenseHistory = new System.Windows.Forms.LinkLabel();
            this.btnReplace = new Guna.UI2.WinForms.Guna2Button();
            this.btnClose = new Guna.UI2.WinForms.Guna2Button();
            this.gbReplacementFor = new System.Windows.Forms.GroupBox();
            this.rdbReplacementForLost = new System.Windows.Forms.RadioButton();
            this.rdbReplacementForDamaged = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.gbReplacementFor.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbltitle
            // 
            this.lbltitle.AutoSize = true;
            this.lbltitle.Font = new System.Drawing.Font("Segoe UI", 25.8F, System.Drawing.FontStyle.Bold);
            this.lbltitle.ForeColor = System.Drawing.Color.Firebrick;
            this.lbltitle.Location = new System.Drawing.Point(163, 5);
            this.lbltitle.Name = "lbltitle";
            this.lbltitle.Size = new System.Drawing.Size(721, 59);
            this.lbltitle.TabIndex = 104;
            this.lbltitle.Text = "Replacement for Damaged License";
            // 
            // ctrlDrivingLicenseInfoWithFiltering1
            // 
            this.ctrlDrivingLicenseInfoWithFiltering1.BackColor = System.Drawing.Color.White;
            this.ctrlDrivingLicenseInfoWithFiltering1.FilterEnable = true;
            this.ctrlDrivingLicenseInfoWithFiltering1.Location = new System.Drawing.Point(11, 79);
            this.ctrlDrivingLicenseInfoWithFiltering1.Name = "ctrlDrivingLicenseInfoWithFiltering1";
            this.ctrlDrivingLicenseInfoWithFiltering1.Size = new System.Drawing.Size(1051, 441);
            this.ctrlDrivingLicenseInfoWithFiltering1.TabIndex = 105;
            this.ctrlDrivingLicenseInfoWithFiltering1.OnLicenseSelected += new System.Action<int>(this.ctrlDrivingLicenseInfoWithFiltering1_OnLicenseSelected);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lb7);
            this.groupBox1.Controls.Add(this.pictureBox5);
            this.groupBox1.Controls.Add(this.lblCreatedByUser);
            this.groupBox1.Controls.Add(this.lblApplicationFees);
            this.groupBox1.Controls.Add(this.lb3);
            this.groupBox1.Controls.Add(this.lb5);
            this.groupBox1.Controls.Add(this.lblReplacedLicenseID);
            this.groupBox1.Controls.Add(this.pictureBox8);
            this.groupBox1.Controls.Add(this.pictureBox10);
            this.groupBox1.Controls.Add(this.lb1);
            this.groupBox1.Controls.Add(this.pictureBox9);
            this.groupBox1.Controls.Add(this.pictureBox3);
            this.groupBox1.Controls.Add(this.lb4);
            this.groupBox1.Controls.Add(this.lblApplicationDate);
            this.groupBox1.Controls.Add(this.lblReplacementApplicationID);
            this.groupBox1.Controls.Add(this.lb);
            this.groupBox1.Controls.Add(this.pictureBox4);
            this.groupBox1.Controls.Add(this.lblOldLicenseID);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.8F);
            this.groupBox1.Location = new System.Drawing.Point(11, 590);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1040, 167);
            this.groupBox1.TabIndex = 106;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Application Info for License Replacement";
            // 
            // lb7
            // 
            this.lb7.AutoSize = true;
            this.lb7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb7.Location = new System.Drawing.Point(509, 125);
            this.lb7.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lb7.Name = "lb7";
            this.lb7.Size = new System.Drawing.Size(127, 25);
            this.lb7.TabIndex = 256;
            this.lb7.Text = "Created By:";
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::FullRealLifeProject19.Properties.Resources.User_32__21;
            this.pictureBox5.Location = new System.Drawing.Point(737, 124);
            this.pictureBox5.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(31, 26);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 258;
            this.pictureBox5.TabStop = false;
            // 
            // lblCreatedByUser
            // 
            this.lblCreatedByUser.AutoSize = true;
            this.lblCreatedByUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreatedByUser.Location = new System.Drawing.Point(777, 124);
            this.lblCreatedByUser.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblCreatedByUser.Name = "lblCreatedByUser";
            this.lblCreatedByUser.Size = new System.Drawing.Size(68, 25);
            this.lblCreatedByUser.TabIndex = 257;
            this.lblCreatedByUser.Text = "[????]";
            // 
            // lblApplicationFees
            // 
            this.lblApplicationFees.AutoSize = true;
            this.lblApplicationFees.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApplicationFees.Location = new System.Drawing.Point(254, 124);
            this.lblApplicationFees.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblApplicationFees.Name = "lblApplicationFees";
            this.lblApplicationFees.Size = new System.Drawing.Size(68, 25);
            this.lblApplicationFees.TabIndex = 244;
            this.lblApplicationFees.Text = "[????]";
            // 
            // lb3
            // 
            this.lb3.AutoSize = true;
            this.lb3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb3.Location = new System.Drawing.Point(16, 124);
            this.lb3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lb3.Name = "lb3";
            this.lb3.Size = new System.Drawing.Size(180, 25);
            this.lb3.TabIndex = 234;
            this.lb3.Text = "Application Fees:";
            // 
            // lb5
            // 
            this.lb5.AutoSize = true;
            this.lb5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb5.Location = new System.Drawing.Point(509, 87);
            this.lb5.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lb5.Name = "lb5";
            this.lb5.Size = new System.Drawing.Size(161, 25);
            this.lb5.TabIndex = 235;
            this.lb5.Text = "Old License ID:";
            // 
            // lblReplacedLicenseID
            // 
            this.lblReplacedLicenseID.AutoSize = true;
            this.lblReplacedLicenseID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReplacedLicenseID.Location = new System.Drawing.Point(777, 52);
            this.lblReplacedLicenseID.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblReplacedLicenseID.Name = "lblReplacedLicenseID";
            this.lblReplacedLicenseID.Size = new System.Drawing.Size(68, 25);
            this.lblReplacedLicenseID.TabIndex = 255;
            this.lblReplacedLicenseID.Text = "[????]";
            // 
            // pictureBox8
            // 
            this.pictureBox8.Image = global::FullRealLifeProject19.Properties.Resources.Calendar_32;
            this.pictureBox8.Location = new System.Drawing.Point(214, 90);
            this.pictureBox8.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(31, 26);
            this.pictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox8.TabIndex = 240;
            this.pictureBox8.TabStop = false;
            // 
            // pictureBox10
            // 
            this.pictureBox10.Image = global::FullRealLifeProject19.Properties.Resources.International_32;
            this.pictureBox10.Location = new System.Drawing.Point(737, 52);
            this.pictureBox10.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox10.Name = "pictureBox10";
            this.pictureBox10.Size = new System.Drawing.Size(31, 26);
            this.pictureBox10.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox10.TabIndex = 254;
            this.pictureBox10.TabStop = false;
            // 
            // lb1
            // 
            this.lb1.AutoSize = true;
            this.lb1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb1.Location = new System.Drawing.Point(17, 90);
            this.lb1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lb1.Name = "lb1";
            this.lb1.Size = new System.Drawing.Size(177, 25);
            this.lb1.TabIndex = 233;
            this.lb1.Text = "Application Date:";
            // 
            // pictureBox9
            // 
            this.pictureBox9.Image = global::FullRealLifeProject19.Properties.Resources.Number_32;
            this.pictureBox9.Location = new System.Drawing.Point(214, 54);
            this.pictureBox9.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox9.Name = "pictureBox9";
            this.pictureBox9.Size = new System.Drawing.Size(31, 26);
            this.pictureBox9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox9.TabIndex = 252;
            this.pictureBox9.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::FullRealLifeProject19.Properties.Resources.money_32;
            this.pictureBox3.Location = new System.Drawing.Point(214, 124);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(31, 26);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 237;
            this.pictureBox3.TabStop = false;
            // 
            // lb4
            // 
            this.lb4.AutoSize = true;
            this.lb4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb4.Location = new System.Drawing.Point(509, 55);
            this.lb4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lb4.Name = "lb4";
            this.lb4.Size = new System.Drawing.Size(217, 25);
            this.lb4.TabIndex = 253;
            this.lb4.Text = "Replaced License ID:";
            // 
            // lblApplicationDate
            // 
            this.lblApplicationDate.AutoSize = true;
            this.lblApplicationDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApplicationDate.ForeColor = System.Drawing.Color.Black;
            this.lblApplicationDate.Location = new System.Drawing.Point(254, 90);
            this.lblApplicationDate.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblApplicationDate.Name = "lblApplicationDate";
            this.lblApplicationDate.Size = new System.Drawing.Size(62, 25);
            this.lblApplicationDate.TabIndex = 243;
            this.lblApplicationDate.Text = "[???]";
            // 
            // lblReplacementApplicationID
            // 
            this.lblReplacementApplicationID.AutoSize = true;
            this.lblReplacementApplicationID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReplacementApplicationID.Location = new System.Drawing.Point(254, 54);
            this.lblReplacementApplicationID.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblReplacementApplicationID.Name = "lblReplacementApplicationID";
            this.lblReplacementApplicationID.Size = new System.Drawing.Size(62, 25);
            this.lblReplacementApplicationID.TabIndex = 251;
            this.lblReplacementApplicationID.Text = "[???]";
            // 
            // lb
            // 
            this.lb.AutoSize = true;
            this.lb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb.Location = new System.Drawing.Point(15, 55);
            this.lb.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lb.Name = "lb";
            this.lb.Size = new System.Drawing.Size(191, 25);
            this.lb.TabIndex = 250;
            this.lb.Text = "L.R.Application ID:";
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::FullRealLifeProject19.Properties.Resources.LocalDriving_License;
            this.pictureBox4.Location = new System.Drawing.Point(737, 87);
            this.pictureBox4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(31, 26);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 238;
            this.pictureBox4.TabStop = false;
            // 
            // lblOldLicenseID
            // 
            this.lblOldLicenseID.AutoSize = true;
            this.lblOldLicenseID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOldLicenseID.Location = new System.Drawing.Point(777, 87);
            this.lblOldLicenseID.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblOldLicenseID.Name = "lblOldLicenseID";
            this.lblOldLicenseID.Size = new System.Drawing.Size(68, 25);
            this.lblOldLicenseID.TabIndex = 246;
            this.lblOldLicenseID.Text = "[????]";
            // 
            // llShowLicenseInfo
            // 
            this.llShowLicenseInfo.AutoSize = true;
            this.llShowLicenseInfo.Enabled = false;
            this.llShowLicenseInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.8F);
            this.llShowLicenseInfo.Location = new System.Drawing.Point(255, 806);
            this.llShowLicenseInfo.Name = "llShowLicenseInfo";
            this.llShowLicenseInfo.Size = new System.Drawing.Size(201, 26);
            this.llShowLicenseInfo.TabIndex = 228;
            this.llShowLicenseInfo.TabStop = true;
            this.llShowLicenseInfo.Text = "Show Licenses Info";
            this.llShowLicenseInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llShowLicenseInfo_LinkClicked);
            // 
            // llShowLicenseHistory
            // 
            this.llShowLicenseHistory.AutoSize = true;
            this.llShowLicenseHistory.Enabled = false;
            this.llShowLicenseHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.8F);
            this.llShowLicenseHistory.Location = new System.Drawing.Point(6, 805);
            this.llShowLicenseHistory.Name = "llShowLicenseHistory";
            this.llShowLicenseHistory.Size = new System.Drawing.Size(233, 26);
            this.llShowLicenseHistory.TabIndex = 227;
            this.llShowLicenseHistory.TabStop = true;
            this.llShowLicenseHistory.Text = "Show Licenses History";
            this.llShowLicenseHistory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llShowLicenseHistory_LinkClicked);
            // 
            // btnReplace
            // 
            this.btnReplace.BorderColor = System.Drawing.Color.Gainsboro;
            this.btnReplace.BorderRadius = 5;
            this.btnReplace.BorderThickness = 1;
            this.btnReplace.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnReplace.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnReplace.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnReplace.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnReplace.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnReplace.Enabled = false;
            this.btnReplace.FillColor = System.Drawing.Color.Transparent;
            this.btnReplace.Font = new System.Drawing.Font("Segoe UI Emoji", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnReplace.ForeColor = System.Drawing.Color.Black;
            this.btnReplace.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnReplace.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnReplace.Image = global::FullRealLifeProject19.Properties.Resources.Renew_Driving_License_32;
            this.btnReplace.ImageOffset = new System.Drawing.Point(-5, 0);
            this.btnReplace.ImageSize = new System.Drawing.Size(30, 30);
            this.btnReplace.Location = new System.Drawing.Point(846, 781);
            this.btnReplace.Name = "btnReplace";
            this.btnReplace.Size = new System.Drawing.Size(216, 45);
            this.btnReplace.TabIndex = 226;
            this.btnReplace.Text = "Issue Replacement";
            this.btnReplace.Click += new System.EventHandler(this.btnReplace_Click);
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
            this.btnClose.ImageSize = new System.Drawing.Size(30, 30);
            this.btnClose.Location = new System.Drawing.Point(653, 781);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(177, 45);
            this.btnClose.TabIndex = 225;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // gbReplacementFor
            // 
            this.gbReplacementFor.Controls.Add(this.rdbReplacementForLost);
            this.gbReplacementFor.Controls.Add(this.rdbReplacementForDamaged);
            this.gbReplacementFor.Enabled = false;
            this.gbReplacementFor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.8F);
            this.gbReplacementFor.Location = new System.Drawing.Point(13, 517);
            this.gbReplacementFor.Name = "gbReplacementFor";
            this.gbReplacementFor.Size = new System.Drawing.Size(548, 65);
            this.gbReplacementFor.TabIndex = 229;
            this.gbReplacementFor.TabStop = false;
            this.gbReplacementFor.Text = "Replacement For";
            // 
            // rdbReplacementForLost
            // 
            this.rdbReplacementForLost.AutoSize = true;
            this.rdbReplacementForLost.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.rdbReplacementForLost.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.rdbReplacementForLost.Location = new System.Drawing.Point(328, 31);
            this.rdbReplacementForLost.Name = "rdbReplacementForLost";
            this.rdbReplacementForLost.Size = new System.Drawing.Size(136, 28);
            this.rdbReplacementForLost.TabIndex = 1;
            this.rdbReplacementForLost.Text = "Lost License";
            this.rdbReplacementForLost.UseVisualStyleBackColor = true;
            this.rdbReplacementForLost.CheckedChanged += new System.EventHandler(this.ChangeApplicationType);
            // 
            // rdbReplacementForDamaged
            // 
            this.rdbReplacementForDamaged.AutoSize = true;
            this.rdbReplacementForDamaged.Checked = true;
            this.rdbReplacementForDamaged.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.rdbReplacementForDamaged.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.rdbReplacementForDamaged.Location = new System.Drawing.Point(14, 33);
            this.rdbReplacementForDamaged.Name = "rdbReplacementForDamaged";
            this.rdbReplacementForDamaged.Size = new System.Drawing.Size(184, 28);
            this.rdbReplacementForDamaged.TabIndex = 0;
            this.rdbReplacementForDamaged.TabStop = true;
            this.rdbReplacementForDamaged.Text = "Damaged License";
            this.rdbReplacementForDamaged.UseVisualStyleBackColor = true;
            this.rdbReplacementForDamaged.CheckedChanged += new System.EventHandler(this.ChangeApplicationType);
            // 
            // frmReplaceLocalLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1074, 836);
            this.Controls.Add(this.gbReplacementFor);
            this.Controls.Add(this.llShowLicenseInfo);
            this.Controls.Add(this.llShowLicenseHistory);
            this.Controls.Add(this.btnReplace);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ctrlDrivingLicenseInfoWithFiltering1);
            this.Controls.Add(this.lbltitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "frmReplaceLocalLicense";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Replacement for Damaged License";
            this.Load += new System.EventHandler(this.frmReplaceLocalLicenseForDamagedOrLost_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.gbReplacementFor.ResumeLayout(false);
            this.gbReplacementFor.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbltitle;
        private ctrlDrivingLicenseInfoWithFiltering ctrlDrivingLicenseInfoWithFiltering1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lb7;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Label lblCreatedByUser;
        private System.Windows.Forms.Label lblApplicationFees;
        private System.Windows.Forms.Label lb3;
        private System.Windows.Forms.Label lb5;
        private System.Windows.Forms.Label lblReplacedLicenseID;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.PictureBox pictureBox10;
        private System.Windows.Forms.Label lb1;
        private System.Windows.Forms.PictureBox pictureBox9;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label lb4;
        private System.Windows.Forms.Label lblApplicationDate;
        private System.Windows.Forms.Label lblReplacementApplicationID;
        private System.Windows.Forms.Label lb;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label lblOldLicenseID;
        private System.Windows.Forms.LinkLabel llShowLicenseInfo;
        private System.Windows.Forms.LinkLabel llShowLicenseHistory;
        private Guna.UI2.WinForms.Guna2Button btnReplace;
        private Guna.UI2.WinForms.Guna2Button btnClose;
        private System.Windows.Forms.GroupBox gbReplacementFor;
        private System.Windows.Forms.RadioButton rdbReplacementForDamaged;
        private System.Windows.Forms.RadioButton rdbReplacementForLost;
    }
}