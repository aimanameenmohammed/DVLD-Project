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
    public partial class frmNewInternationalLicense : Form
    {
        public frmNewInternationalLicense()
        {
            InitializeComponent();
        }


        int _InternationalLicenseID = -1;

        enum enLicenseClass { Class3_OrdinarydrivingLicense=3}
      

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void _SetDefuatValues()
        {

            lblApplicationDate.Text = "[???]";
            lblApplicationFees.Text = "[$$$]";
            lblCreatedByUser.Text = "[???]";
            lblExpirationDate.Text = "[???]";
            lblInternationalLApplicationID.Text = "[???]";
            lblInternationalLLicenseID.Text = "[???]";
            lblLocalLicenseID.Text = "[???]";
            lbIssueDate.Text = "[???]";
            btnSave.Enabled = false;
            llShowLicenseHistory.Enabled=false;
            llShowLicenseInfo.Enabled=false;
            
        }

   

        void _FillValues()
        {

            lblApplicationDate.Text = DateTime.Now.ToShortDateString();
            lblApplicationFees.Text = clsApplicationTypes.Find((int)clsApplication.enApplicationType.NewInternationalLicense).ApplicationFees.ToString();
            lblCreatedByUser.Text = GlobalSettings.CurrenctUser.UserName;
            lblExpirationDate.Text = DateTime.Now.AddYears(1).ToString();
            lbIssueDate.Text = DateTime.Now.ToString();
            lblLocalLicenseID.Text = ctrlDrivingLicenseInfoWithFiltering1.SelectedLicenseInfo.LicenseID.ToString();

        }

        bool HandleInternationalException()
        {


            _InternationalLicenseID = clsInternationalLicense.GetAnActiveInternationalLicenseIDByDriverID(ctrlDrivingLicenseInfoWithFiltering1.SelectedLicenseInfo.DriverID);
            if (_InternationalLicenseID != -1)
            {
                MessageBox.Show("this person already has an active international license with ID=" + _InternationalLicenseID, "No Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (ctrlDrivingLicenseInfoWithFiltering1.SelectedLicenseInfo.ExpirationDate <= DateTime.Now || !(ctrlDrivingLicenseInfoWithFiltering1.SelectedLicenseInfo.IsActive))
            {
                MessageBox.Show("Only active and valid driving licenses are eligible for an International Driving License.", "No Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (ctrlDrivingLicenseInfoWithFiltering1.SelectedLicenseInfo.LicenseClassID != (byte)enLicenseClass.Class3_OrdinarydrivingLicense)
            {
                MessageBox.Show("Selected License should be Class3,Select another one", "No Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }


            return true;

        }

      


        private void frmNewInternationalLicense_Load(object sender, EventArgs e)
        {
           
        }

        private void btnSave_Click(object sender, EventArgs e)
        {


            if (MessageBox.Show("Are you sure you want to issue the International license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }



            clsInternationalLicense InternationalLicense = new clsInternationalLicense();

            InternationalLicense.ExpirationDate = DateTime.Now.AddYears(1);
            InternationalLicense.IssueDate = DateTime.Now;
            InternationalLicense.CreatedByUserID = GlobalSettings.CurrenctUser.UserID;
            InternationalLicense.DriverID = ctrlDrivingLicenseInfoWithFiltering1.SelectedLicenseInfo.DriverID;
            InternationalLicense.IssuedUsingLocalLicenseID = ctrlDrivingLicenseInfoWithFiltering1.SelectedLicenseInfo.LicenseID;
            InternationalLicense.IsActive = true;

            InternationalLicense.LastStatusDate = DateTime.Now;
            InternationalLicense.PaidFees = Convert.ToSingle(lblApplicationFees.Text.Trim());
            InternationalLicense.ApplicantPersonID = ctrlDrivingLicenseInfoWithFiltering1.SelectedLicenseInfo.DriverInfo.PersonID;
            InternationalLicense.ApplicationStatus = clsApplication.enApplicationStatus.Completed;
            InternationalLicense.ApplicationDate = DateTime.Now;
            InternationalLicense.ApplicationTypeID = (int)clsApplication.enApplicationType.NewInternationalLicense;


            if (InternationalLicense.Save())
            {

                MessageBox.Show("International License Issued Successfully with ID=" + InternationalLicense.InternationalLicenseID.ToString(), "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);

                lblInternationalLLicenseID.Text = InternationalLicense.InternationalLicenseID.ToString();
                lblInternationalLApplicationID.Text = InternationalLicense.ApplicationID.ToString();
                _InternationalLicenseID = InternationalLicense.InternationalLicenseID;

                btnSave.Enabled = false;
                llShowLicenseInfo.Enabled = true;

            }
            else
            {
                MessageBox.Show("Faild to Issue International License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

     

        private void llShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowPersonLicenseHistory frm = new frmShowPersonLicenseHistory(ctrlDrivingLicenseInfoWithFiltering1.SelectedLicenseInfo.DriverInfo.PersonID);
            frm.ShowDialog();
        }

        private void llShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowInternationalLicenseInfo frm = new frmShowInternationalLicenseInfo(_InternationalLicenseID);
            frm.ShowDialog();
        }

        private void ctrlDrivingLicenseInfoWithFiltering1_OnLicenseSelected(int obj)
        {
        }

        private void ctrlDrivingLicenseInfoWithFiltering1_OnLicenseSelected_1(int obj)
        {

            int LicenseID = obj;

            if (LicenseID == -1)
            {
                _SetDefuatValues();
                return;
            }


           if(!HandleInternationalException())
            {
                _SetDefuatValues();
                return;
            }

            btnSave.Enabled = true;
            llShowLicenseHistory.Enabled = true;

            _FillValues();

        }
    }
}
