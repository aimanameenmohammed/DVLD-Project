namespace FullRealLifeProject19
{
    partial class ctrlShowPersonCardWithfiltering
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.grbFilter = new Guna.UI2.WinForms.Guna2GroupBox();
            this.btnAddNewPerson = new Guna.UI2.WinForms.Guna2Button();
            this.btnSearch = new Guna.UI2.WinForms.Guna2Button();
            this.txtFilterValue = new Guna.UI2.WinForms.Guna2TextBox();
            this.cmFilterType = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.ctrlPersonCard1 = new FullRealLifeProject19.ctrlPersonCard();
            this.grbFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // grbFilter
            // 
            this.grbFilter.BorderColor = System.Drawing.Color.Gainsboro;
            this.grbFilter.BorderRadius = 5;
            this.grbFilter.Controls.Add(this.btnAddNewPerson);
            this.grbFilter.Controls.Add(this.btnSearch);
            this.grbFilter.Controls.Add(this.txtFilterValue);
            this.grbFilter.Controls.Add(this.cmFilterType);
            this.grbFilter.Controls.Add(this.label9);
            this.grbFilter.CustomBorderColor = System.Drawing.Color.Transparent;
            this.grbFilter.Font = new System.Drawing.Font("Segoe UI Emoji", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbFilter.ForeColor = System.Drawing.Color.Black;
            this.grbFilter.Location = new System.Drawing.Point(14, 6);
            this.grbFilter.Name = "grbFilter";
            this.grbFilter.Size = new System.Drawing.Size(1075, 102);
            this.grbFilter.TabIndex = 1;
            this.grbFilter.Text = "Filter";
            this.grbFilter.Click += new System.EventHandler(this.grbFilter_Click);
            // 
            // btnAddNewPerson
            // 
            this.btnAddNewPerson.BorderColor = System.Drawing.Color.Gainsboro;
            this.btnAddNewPerson.BorderRadius = 5;
            this.btnAddNewPerson.BorderThickness = 1;
            this.btnAddNewPerson.CheckedState.FillColor = System.Drawing.Color.Transparent;
            this.btnAddNewPerson.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAddNewPerson.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAddNewPerson.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAddNewPerson.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAddNewPerson.FillColor = System.Drawing.Color.Transparent;
            this.btnAddNewPerson.Font = new System.Drawing.Font("Segoe UI Emoji", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddNewPerson.ForeColor = System.Drawing.Color.Black;
            this.btnAddNewPerson.HoverState.FillColor = System.Drawing.Color.Transparent;
            this.btnAddNewPerson.Image = global::FullRealLifeProject19.Properties.Resources.AddPerson_32;
            this.btnAddNewPerson.ImageOffset = new System.Drawing.Point(1, 1);
            this.btnAddNewPerson.ImageSize = new System.Drawing.Size(40, 40);
            this.btnAddNewPerson.Location = new System.Drawing.Point(854, 53);
            this.btnAddNewPerson.Name = "btnAddNewPerson";
            this.btnAddNewPerson.Size = new System.Drawing.Size(77, 36);
            this.btnAddNewPerson.TabIndex = 89;
            this.btnAddNewPerson.Click += new System.EventHandler(this.btnAddNewPerson_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.BorderColor = System.Drawing.Color.Gainsboro;
            this.btnSearch.BorderRadius = 5;
            this.btnSearch.BorderThickness = 1;
            this.btnSearch.CheckedState.FillColor = System.Drawing.Color.Transparent;
            this.btnSearch.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSearch.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSearch.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSearch.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSearch.FillColor = System.Drawing.Color.Transparent;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI Emoji", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.Black;
            this.btnSearch.HoverState.FillColor = System.Drawing.Color.Transparent;
            this.btnSearch.Image = global::FullRealLifeProject19.Properties.Resources.SearchPerson;
            this.btnSearch.ImageOffset = new System.Drawing.Point(1, 1);
            this.btnSearch.ImageSize = new System.Drawing.Size(35, 35);
            this.btnSearch.Location = new System.Drawing.Point(755, 53);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(77, 36);
            this.btnSearch.TabIndex = 88;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtFilterValue
            // 
            this.txtFilterValue.BackColor = System.Drawing.Color.Transparent;
            this.txtFilterValue.BorderRadius = 5;
            this.txtFilterValue.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtFilterValue.DefaultText = "";
            this.txtFilterValue.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtFilterValue.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtFilterValue.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtFilterValue.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtFilterValue.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtFilterValue.Font = new System.Drawing.Font("Segoe UI Emoji", 10.2F, System.Drawing.FontStyle.Bold);
            this.txtFilterValue.ForeColor = System.Drawing.Color.Black;
            this.txtFilterValue.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtFilterValue.Location = new System.Drawing.Point(389, 53);
            this.txtFilterValue.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.txtFilterValue.Name = "txtFilterValue";
            this.txtFilterValue.PlaceholderText = "Search...";
            this.txtFilterValue.SelectedText = "";
            this.txtFilterValue.Size = new System.Drawing.Size(320, 36);
            this.txtFilterValue.TabIndex = 87;
            this.txtFilterValue.TextChanged += new System.EventHandler(this.txtFiltering_TextChanged);
            this.txtFilterValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFiltering_KeyPress);
            this.txtFilterValue.Validating += new System.ComponentModel.CancelEventHandler(this.txtFilterValue_Validating);
            // 
            // cmFilterType
            // 
            this.cmFilterType.BackColor = System.Drawing.Color.Transparent;
            this.cmFilterType.BorderRadius = 5;
            this.cmFilterType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmFilterType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmFilterType.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmFilterType.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmFilterType.Font = new System.Drawing.Font("Segoe UI Emoji", 10.2F, System.Drawing.FontStyle.Bold);
            this.cmFilterType.ForeColor = System.Drawing.Color.Black;
            this.cmFilterType.ItemHeight = 30;
            this.cmFilterType.Items.AddRange(new object[] {
            "National No.",
            "Person ID"});
            this.cmFilterType.Location = new System.Drawing.Point(120, 53);
            this.cmFilterType.Name = "cmFilterType";
            this.cmFilterType.Size = new System.Drawing.Size(249, 36);
            this.cmFilterType.StartIndex = 0;
            this.cmFilterType.TabIndex = 86;
            this.cmFilterType.SelectedIndexChanged += new System.EventHandler(this.cmSearchType_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(14, 59);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(78, 22);
            this.label9.TabIndex = 85;
            this.label9.Text = "FindBy:";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // ctrlPersonCard1
            // 
            this.ctrlPersonCard1.BackColor = System.Drawing.Color.White;
            this.ctrlPersonCard1.Location = new System.Drawing.Point(3, 112);
            this.ctrlPersonCard1.Name = "ctrlPersonCard1";
            this.ctrlPersonCard1.Size = new System.Drawing.Size(1102, 395);
            this.ctrlPersonCard1.TabIndex = 0;
            this.ctrlPersonCard1.Load += new System.EventHandler(this.ctrlPersonCard1_Load);
            // 
            // ctrlShowPersonCardWithfiltering
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.grbFilter);
            this.Controls.Add(this.ctrlPersonCard1);
            this.Name = "ctrlShowPersonCardWithfiltering";
            this.Size = new System.Drawing.Size(1106, 510);
            this.Load += new System.EventHandler(this.ctrlShowPersonCardWithfiltering_Load);
            this.grbFilter.ResumeLayout(false);
            this.grbFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlPersonCard ctrlPersonCard1;
        private Guna.UI2.WinForms.Guna2GroupBox grbFilter;
        private Guna.UI2.WinForms.Guna2TextBox txtFilterValue;
        private Guna.UI2.WinForms.Guna2ComboBox cmFilterType;
        private System.Windows.Forms.Label label9;
        private Guna.UI2.WinForms.Guna2Button btnSearch;
        private Guna.UI2.WinForms.Guna2Button btnAddNewPerson;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}
