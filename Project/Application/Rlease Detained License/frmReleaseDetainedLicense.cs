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
    public partial class frmReleaseDetainedLicense : Form
    {

        int _LicenseID = -1;
        public frmReleaseDetainedLicense(int LicenseID)
        {
            InitializeComponent();
            _LicenseID = LicenseID;
        }

        public frmReleaseDetainedLicense()
        {
            InitializeComponent();
        }

        
        void _SetDefuatValues()
        {
            lblCreatedByUser.Text = "[???]";
            lblDetainDate.Text = "[dd/mm/yyyy]";
            lblDetainID.Text = "[???]";
            lblLicenseID.Text = "[???]";
            lblApplicationID.Text = "[???]";
            lblTotalFees.Text = "[???]";
            lblFineFees.Text = "[$$$]";
            lblApplicationFees.Text = "[$$$]";

            llShowLicenseHistory.Enabled = false;
            llShowLicenseInfo.Enabled = false;

        }



        private void btnDetain_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Are You Sure you want to Release this License?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
            {
                _SetDefuatValues();
                ctrlDrivingLicenseInfoWithFiltering1.ResetDrivingLicenseWithFiltering();
                return;
            }


            int ApplicationID = -1;

            bool IsRelease = ctrlDrivingLicenseInfoWithFiltering1.SelectedLicenseInfo.ReleaseDetainedLicense(GlobalSettings.CurrenctUser.UserID, ref ApplicationID);

            if (!IsRelease)
            {
                MessageBox.Show("Detained License Does not Released", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            lblApplicationID.Text = ApplicationID.ToString();

            btnRelease.Enabled = false;
            llShowLicenseInfo.Enabled = true;

            MessageBox.Show("Detained License Released Successfully", "Detained license Release", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void llShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowLicenseInfo frm = new frmShowLicenseInfo(ctrlDrivingLicenseInfoWithFiltering1.SelectedLicenseInfo.LicenseID);
            frm.ShowDialog();
        }

        private void llShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowPersonLicenseHistory frm = new frmShowPersonLicenseHistory(ctrlDrivingLicenseInfoWithFiltering1.SelectedLicenseInfo.DriverInfo.PersonID);
            frm.ShowDialog();
        }

        private void frmReleaseDetainedLicense_Load(object sender, EventArgs e)
        {
            if(_LicenseID!=-1)
            ctrlDrivingLicenseInfoWithFiltering1.LoadLicenseInfo(_LicenseID);

        }

        private void ctrlDrivingLicenseInfoWithFiltering1_OnLicenseSelected(int obj)
        {

            if (obj == -1)
            {
                _SetDefuatValues();
                return;
            }


            if (!ctrlDrivingLicenseInfoWithFiltering1.SelectedLicenseInfo.IsDetained)
            {
                MessageBox.Show("Select License is Not Detained choose another one : ", "No Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            btnRelease.Enabled = true;
            llShowLicenseHistory.Enabled = true;
            

            lblCreatedByUser.Text = GlobalSettings.CurrenctUser.UserName;
           lblDetainDate.Text = DateTime.Now.ToShortDateString();
           lblLicenseID.Text = ctrlDrivingLicenseInfoWithFiltering1.SelectedLicenseInfo.LicenseID.ToString();
           lblApplicationFees.Text = clsApplicationTypes.Find((int)clsApplication.enApplicationType.ReleaseDetainedDriving).ApplicationFees.ToString();

           lblFineFees.Text = ctrlDrivingLicenseInfoWithFiltering1.SelectedLicenseInfo.DetainedLicenseInfo.FineFees.ToString();
           lblDetainID.Text = ctrlDrivingLicenseInfoWithFiltering1.SelectedLicenseInfo.DetainedLicenseInfo.DetainID.ToString();
          
           lblTotalFees.Text = (Convert.ToSingle(lblFineFees.Text) + Convert.ToSingle(lblApplicationFees.Text)).ToString();
          

        }
    }
}
