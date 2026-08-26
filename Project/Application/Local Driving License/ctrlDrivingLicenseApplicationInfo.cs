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
    public partial class ctrlDrivingLicenseApplicationInfo : UserControl
    {
        public ctrlDrivingLicenseApplicationInfo()
        {
            InitializeComponent();
        }
        clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication;
        int _LicenseID=-1;
        public clsLocalDrivingLicenseApplication SelectedLDLApplictionInfo
        {
            get
            {
                return _LocalDrivingLicenseApplication;
            }
        }

        void _RestLocalDrivingLicenseApplicationInfo()
        {

            ctrlApplicationBasicInfo1._ResetBaseApplicationInfo();
            lblAppliedFor.Text = "[???]";
            lblLocalDrivingLicenseApplicationID.Text = "[???]";
            lblPassedTests.Text = "0/3";

            llShowLicenceInfo.Enabled= false;

        }
        void _FillValues()
        {

            ctrlApplicationBasicInfo1.LoadBaseApplicationInfo(_LocalDrivingLicenseApplication.ApplicationID);
            //
            _LicenseID = _LocalDrivingLicenseApplication.GetActiveLicenseIDByPersonID();
            llShowLicenceInfo.Enabled = (_LicenseID != -1);//we check for Showing License Info
            //        
            lblPassedTests.Text =_LocalDrivingLicenseApplication.GetPassedTestCount().ToString()+"/3";
            lblLocalDrivingLicenseApplicationID.Text = _LocalDrivingLicenseApplication.LocalDrivingLicenseID.ToString();
            lblAppliedFor.Text = _LocalDrivingLicenseApplication.LicenseClassInfo.ClassName;

        }

        public void LoadApplicationInfoByLocalDrivingLicenseAppID(int LocalDrivingLicenseApplicationID)
        {

            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.FindByLocalDrivingLIcenseID(LocalDrivingLicenseApplicationID);
            if(_LocalDrivingLicenseApplication == null)
            {
                _RestLocalDrivingLicenseApplicationInfo();
                MessageBox.Show("No LocalDrivingLicenseApplicant with LDLApplicationID = " + LocalDrivingLicenseApplicationID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            _FillValues();

        }



        private void ctrlDrivingLicenseApplicationInfo_Load(object sender, EventArgs e)
        {
        }

        private void llShowLicenceInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            frmShowLicenseInfo frm = new frmShowLicenseInfo(_LicenseID);
                frm.ShowDialog();
            
        }
    }
}
