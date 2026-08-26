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
    public partial class frmRenewLocalDrivingLicense : Form
    {


        int _LicenseID=-1;

        public frmRenewLocalDrivingLicense()
        {
            InitializeComponent();
        }


        void _SetDefuatValues()
        {

            lblOldLicenseID.Text = "[???]";
            txtNotes.Text = "";
            lblLicenseFees.Text = "[$$$]";
            lblApplicationDate.Text = "[???]";
            lblApplicationFees.Text = "[$$$]";
            lblCreatedByUser.Text = "[???]";
            lblExpirationDate.Text = "[???]";
            lblRenewLApplicationID.Text = "[???]";
            lblRenewLicenseID.Text = "[???]";
            lblTotalFees.Text = "[$$$]";
            lbIssueDate.Text = "[???]";
            btnRenew.Enabled = false;
            llShowLicenseHistory.Enabled = false;
            llShowLicenseInfo.Enabled = false;

        }

     
       

        private void frmRenewLocalDrivingLicense_Load(object sender, EventArgs e)
        {

        }

       

        private void btnRenew_Click(object sender, EventArgs e)
        {


            if (MessageBox.Show("Are You Sure you want to Renew this License?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
            {
                _SetDefuatValues();
                ctrlDrivingLicenseInfoWithFiltering1.ResetDrivingLicenseWithFiltering();
                return;
            }


            clsLicense License = ctrlDrivingLicenseInfoWithFiltering1.SelectedLicenseInfo.
                RenewLicense(txtNotes.Text.Trim(), GlobalSettings.CurrenctUser.UserID);


            if (License == null)
            {

                MessageBox.Show("Date Does not Save ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }



            _LicenseID = License.LicenseID;
            lblRenewLApplicationID.Text = License.ApplicationID.ToString();
            lblRenewLicenseID.Text = License.LicenseID.ToString();
            btnRenew.Enabled = false;
            llShowLicenseInfo.Enabled = true;

            MessageBox.Show("License Renewed  Successfully with ID=" + License.LicenseID, "Savad", MessageBoxButtons.OK, MessageBoxIcon.Information);
          

        }

        private void llShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowLicenseInfo frm = new frmShowLicenseInfo(_LicenseID);
            frm.ShowDialog();
        }

        private void llShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowPersonLicenseHistory frm = new frmShowPersonLicenseHistory(ctrlDrivingLicenseInfoWithFiltering1
                .SelectedLicenseInfo.DriverInfo.PersonID);
            frm.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ctrlDrivingLicenseInfoWithFiltering1_OnLicenseSelected(int obj)
        {


            int LicenseID = obj;


            if (LicenseID == -1)
            {
                _SetDefuatValues();
                return;
            }


            if (!ctrlDrivingLicenseInfoWithFiltering1.SelectedLicenseInfo.IsLicenseExpired())
            {
                MessageBox.Show("Select License is not yet expired , it will expire on : " + ctrlDrivingLicenseInfoWithFiltering1.SelectedLicenseInfo.ExpirationDate, "No Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return ;
            }

            if (!ctrlDrivingLicenseInfoWithFiltering1.SelectedLicenseInfo.IsActive)
            {
                MessageBox.Show("Selected license is Not active , choose an active license.", "No Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return ;
            }


            btnRenew.Enabled = true;
            llShowLicenseHistory.Enabled = true;

            lblOldLicenseID.Text = ctrlDrivingLicenseInfoWithFiltering1.SelectedLicenseInfo.LicenseID.ToString();
            lblApplicationDate.Text = DateTime.Now.ToShortDateString();
            lbIssueDate.Text = DateTime.Now.ToShortDateString();
            lblCreatedByUser.Text = GlobalSettings.CurrenctUser.UserName;

            lblApplicationFees.Text = clsApplicationTypes.Find((int)clsApplication.enApplicationType.RenewDrivingLicense).ApplicationFees.ToString();

            lblLicenseFees.Text = ctrlDrivingLicenseInfoWithFiltering1.SelectedLicenseInfo.LicenseClassesInfo.ClassFees.ToString();
            lblExpirationDate.Text = DateTime.Now.AddYears(ctrlDrivingLicenseInfoWithFiltering1.SelectedLicenseInfo.LicenseClassesInfo.DefaultValidityLength).ToShortDateString();
            lblTotalFees.Text = (Convert.ToSingle(lblApplicationFees.Text) + Convert.ToSingle(lblLicenseFees.Text)).ToString();






        }
    }
}
