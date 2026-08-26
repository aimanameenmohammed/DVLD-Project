using DVLDDataBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FullRealLifeProject19
{
    public partial class ctrlDrivingLicenseInfoWithFiltering : UserControl
    {
        public ctrlDrivingLicenseInfoWithFiltering()
        {
            InitializeComponent();
        }

        public event Action<int> OnLicenseSelected;
        // Create a protected method to raise the event 
        protected virtual void LicenseSelected(int LicenseID)
        {
            Action<int> handler = OnLicenseSelected;
            if (handler != null)
            {
                handler(LicenseID); // Raise the event with the parameter
            }
        }



        bool _FilterEnable = true;

        public bool FilterEnable
        {

            get
            {

                return _FilterEnable;

            }
            set
            {

                _FilterEnable = value;
                txtFilterValue.Enabled = _FilterEnable;

            }

        }


        public clsLicense SelectedLicenseInfo
        {
            get
            {
                return ctrlDrivingLicenseInfo1.SelectedLicenseInfo;
            }
        }
        public void LoadLicenseInfo(int LicenseID)
        {

            txtFilterValue.Text = LicenseID.ToString();
            ctrlDrivingLicenseInfo1.LoadDriverLicenseInfoByLicenseID(LicenseID);

            if (OnLicenseSelected != null)
                LicenseSelected(ctrlDrivingLicenseInfo1.LicenseID);

        }

       
       
        public void ResetDrivingLicenseWithFiltering()
        {
            txtFilterValue.Text = "";
            txtFilterValue.Focus();
            ctrlDrivingLicenseInfo1.ResetDrivingLicenseInfo();  
        }
        void _Find()
        {

            if(!this.ValidateChildren())
            {
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            LoadLicenseInfo(Convert.ToInt32(txtFilterValue.Text.Trim()));
            
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
           
          
        }

        private void guna2TextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar==(char)13)
            {
                btnsearch.PerformClick();
            }

            e.Handled=(!char.IsNumber(e.KeyChar)&&!char.IsControl(e.KeyChar));
        }

        private void guna2TextBox1_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtFilterValue.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFilterValue, "This field is required!");
            }
            else
            {
                //e.Cancel = false;
                errorProvider1.SetError(txtFilterValue, null);
            }
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            _Find();
        }

        private void ctrlDrivingLicenseInfoWithFiltering_Load(object sender, EventArgs e)
        {
            txtFilterValue.Focus();
        }
    }
}
