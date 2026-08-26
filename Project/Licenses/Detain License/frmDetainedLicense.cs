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
    public partial class frmDetainedLicense : Form
    {
        public frmDetainedLicense()
        {
            InitializeComponent();
        }
        


        
        private void txtDetainedFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (!char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar));
        }


       
        void _SetDefuatValues()
        {
            lblCreatedByUser.Text = "[???]";
            lblDetainDate.Text = "[???]";
            lblDetainID.Text = "[???]";
            lblLicenseID.Text = "[???]";
            txtDetainedFees.Text = "";
            llShowLicenseHistory.Enabled= false;
            llShowLicenseInfo.Enabled= false;

        }

      
       
      

        private void btnDetain_Click(object sender, EventArgs e)
        {


            if (!this.ValidateChildren())
            {

                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }


            if (MessageBox.Show("Are You Sure you want to Detain this License?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
            {
                _SetDefuatValues();
                ctrlDrivingLicenseInfoWithFiltering1.ResetDrivingLicenseWithFiltering();
                return;
            }


            int DetainID = ctrlDrivingLicenseInfoWithFiltering1.SelectedLicenseInfo.Detain(
                Convert.ToSingle(txtDetainedFees.Text.Trim()), GlobalSettings.CurrenctUser.UserID);


            if (DetainID == -1)
            {
                MessageBox.Show("Date Does not Save ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lblDetainID.Text = DetainID.ToString();
            txtDetainedFees.Enabled = false;
            btnDetain.Enabled = false;
            llShowLicenseInfo.Enabled = true;

            MessageBox.Show("License Detained  Successfully with ID=" + DetainID, "Savad", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
          
        }

        private void txtDetainedFees_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrEmpty(txtDetainedFees.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtDetainedFees, "This Field is required!");
            }
            else
                errorProvider1.SetError(txtDetainedFees, null);
        }

        private void frmDetainedLicense_Load(object sender, EventArgs e)
        {

        }

        private void llShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowLicenseInfo frm = new frmShowLicenseInfo(ctrlDrivingLicenseInfoWithFiltering1.SelectedLicenseInfo.LicenseID);
            frm.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void llShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowPersonLicenseHistory frm = new frmShowPersonLicenseHistory(ctrlDrivingLicenseInfoWithFiltering1.SelectedLicenseInfo.DriverInfo.PersonID);
            frm.ShowDialog();
        }

        private void ctrlDrivingLicenseInfoWithFiltering1_OnLicenseSelected(int obj)
        {


            if(obj==-1)
            {
                _SetDefuatValues();

                return;
            }


            if (ctrlDrivingLicenseInfoWithFiltering1.SelectedLicenseInfo.IsDetained)
            {
                MessageBox.Show("Select License is already Detained choose another one : ", "No Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return ;
            }

            if (!ctrlDrivingLicenseInfoWithFiltering1.SelectedLicenseInfo.IsActive)
            {
                MessageBox.Show("Selected license is Not active , choose an active license.", "No Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            btnDetain.Enabled = true;
            llShowLicenseHistory.Enabled = true;
            txtDetainedFees.Enabled = true;

            lblCreatedByUser.Text = GlobalSettings.CurrenctUser.UserName;
            lblDetainDate.Text = DateTime.Now.ToShortDateString();
            lblLicenseID.Text = ctrlDrivingLicenseInfoWithFiltering1.SelectedLicenseInfo.LicenseID.ToString();

        }
    }
}
