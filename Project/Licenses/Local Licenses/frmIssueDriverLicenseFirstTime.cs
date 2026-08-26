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
using System.Xml.Serialization;

namespace FullRealLifeProject19
{
    public partial class frmIssueDriverLicenseFirstTime : Form
    {
        int _LocalDrivingLicenseID;

        clsLocalDrivingLicenseApplication LocalDrivingLicenseApplication;

        public frmIssueDriverLicenseFirstTime(int LcoalDrivingLicenseID)
        {
            InitializeComponent();
            _LocalDrivingLicenseID = LcoalDrivingLicenseID;
        }


      
        private void btnSave_Click(object sender, EventArgs e)
        {


            int LicenseID = LocalDrivingLicenseApplication.IssueLicenseForFirstTime(GlobalSettings.CurrenctUser.UserID, txtNotes.Text.Trim());


            if (LicenseID!=-1)
            {
                MessageBox.Show("License Issued  successfully with License ID =" + LicenseID, "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
            }
            else
                MessageBox.Show("Faild Saved Data ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


        }

        private void frmIssueDriverLicenseFirstTime_Load(object sender, EventArgs e)
        {


            LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.FindByLocalDrivingLIcenseID(_LocalDrivingLicenseID);


            if (LocalDrivingLicenseApplication == null)
            {

                MessageBox.Show("No Applicaiton with ID=" + _LocalDrivingLicenseID.ToString(), "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }



            if(!LocalDrivingLicenseApplication.PassedAllTest())
            {


                MessageBox.Show("Person Should Pass All Tests First.", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;

            }

            int LicenseID = LocalDrivingLicenseApplication.GetActiveLicenseIDByPersonID();

            if (LicenseID!=-1)
            {
                MessageBox.Show("Person already has License before with License ID=" + LicenseID.ToString(), "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }


            txtNotes.Focus();

            ctrlDrivingLicenseApplicationInfo1.LoadApplicationInfoByLocalDrivingLicenseAppID(_LocalDrivingLicenseID);




        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
