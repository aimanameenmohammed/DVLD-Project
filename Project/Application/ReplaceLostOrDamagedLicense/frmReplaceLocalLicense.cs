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
    public partial class frmReplaceLocalLicense : Form
    {


        int _NewLicenseID=-1;

        public frmReplaceLocalLicense()
        {
            InitializeComponent();
        }

        private void frmReplaceLocalLicenseForDamagedOrLost_Load(object sender, EventArgs e)
        {

        }



        void _SetDefuatValues()
        {
            
            lblApplicationFees.Text = "[$$$]";
            lblApplicationDate.Text = "[???]";
            lblApplicationFees.Text = "[$$$]";
            lblCreatedByUser.Text = "[???]";
            lblReplacedLicenseID.Text = "[???]";
            lblOldLicenseID.Text = "[???]";          
            btnReplace.Enabled = false;
            llShowLicenseHistory.Enabled = false;
            gbReplacementFor.Enabled = false;   
            llShowLicenseInfo.Enabled = false;
        }


        private void btnReplace_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Are You Sure you want to Issue a Replacement for this License?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
            {
                _SetDefuatValues();
                ctrlDrivingLicenseInfoWithFiltering1.ResetDrivingLicenseWithFiltering();
                return;
            }


            clsLicense NewLicense = 
                ctrlDrivingLicenseInfoWithFiltering1.SelectedLicenseInfo.Replace(GlobalSettings.CurrenctUser.UserID, _GetIssueReason());

            if (NewLicense == null)
            {

                MessageBox.Show("Faild to Issue a replacemnet for this  License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _NewLicenseID = NewLicense.LicenseID;
            
            lblReplacementApplicationID.Text = NewLicense.ApplicationID.ToString();
            lblReplacedLicenseID.Text = NewLicense.LicenseID.ToString();

            btnReplace.Enabled = false;
            gbReplacementFor.Enabled = false;
            llShowLicenseInfo.Enabled = true;

            MessageBox.Show("License Replaced Successfully with ID=" + NewLicense.LicenseID, "Savad", MessageBoxButtons.OK, MessageBoxIcon.Information);
         
        }


        private clsLicense.enIssueReason _GetIssueReason()
        {

            if (rdbReplacementForDamaged.Checked)
                return clsLicense.enIssueReason.ReplacementForDamaged;
            else
                return clsLicense.enIssueReason.ReplacementForLost;

        }


        void _ChangeApplicationType()
        {
            if (!gbReplacementFor.Enabled)
                return;

            if (rdbReplacementForDamaged.Checked)
            {
                lblApplicationFees.Text = clsApplicationTypes.Find((int)clsApplication.enApplicationType.ReplacementForADamagedDriving).ApplicationFees.ToString();

                this.Text = "Replacement for Damaged License";
                lbltitle.Text = "Replacement for Damaged License";
            }
            else
            {
                lblApplicationFees.Text = clsApplicationTypes.Find((int)clsApplication.enApplicationType.ReplacementForALostDriving).ApplicationFees.ToString();

                this.Text = "Replacement for Lost License";
                lbltitle.Text = "Replacement for Lost License";
            }

        }

        private void ChangeApplicationType(object sender, EventArgs e)
        {
            _ChangeApplicationType();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void llShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowLicenseInfo frm = new frmShowLicenseInfo(_NewLicenseID);
            frm.ShowDialog();
        }

        private void llShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            frmShowPersonLicenseHistory frm = new frmShowPersonLicenseHistory(ctrlDrivingLicenseInfoWithFiltering1.SelectedLicenseInfo.DriverInfo.PersonID);
            frm.ShowDialog();

        }

        private void ctrlDrivingLicenseInfoWithFiltering1_OnLicenseSelected(int obj)
        {


            int LicenseID = obj;

            if(LicenseID==-1)
            {
                _SetDefuatValues();
                return;
            }



            if (!ctrlDrivingLicenseInfoWithFiltering1.SelectedLicenseInfo.IsActive)
            {
                MessageBox.Show("Selected license is Not active , choose an active license.", "No Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            btnReplace.Enabled = true;
            llShowLicenseHistory.Enabled = true;
            gbReplacementFor.Enabled = true;

            lblApplicationDate.Text = DateTime.Now.ToShortDateString();
            lblCreatedByUser.Text = GlobalSettings.CurrenctUser.UserName;
            lblOldLicenseID.Text = ctrlDrivingLicenseInfoWithFiltering1.SelectedLicenseInfo.LicenseID.ToString();

        }
    }
}
