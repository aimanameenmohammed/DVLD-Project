using DVLDDataBusinessLayer;
using FullRealLifeProject19.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FullRealLifeProject19
{
    public partial class ctrlDrivingLicenseInfo : UserControl
    {
        public ctrlDrivingLicenseInfo()
        {
            InitializeComponent();
        }

        clsLicense _License;

        int _LicenseID = -1;
       
   public int LicenseID
        {
            get
            { return _LicenseID; }
        }

        public clsLicense SelectedLicenseInfo
        {
          
            get
                { return _License; }
        }


        public void ResetDrivingLicenseInfo()
        {
            _SetDefaultValues();
        }
     
       

        public void ReSetValues()
        {
            _SetDefaultValues();
        }

        void _SetDefaultValues()
        {


            lblClass.Text = "[???]";
            lblFullName.Text = "[????]";
            lblDriverID.Text = "[???]";
            lblGendor.Text = "[???]";
            lblIsActive.Text = "[???]";
            lblLicenseID.Text = "[???]";
            lblNationalNo.Text = "[???]";
            lblNotes.Text = "[???]";
            lblIssueReason.Text = "[???]";
            lblIssueDate.Text = "[???]";
            lblIsDetained.Text = "[???]";
            lblExpirationDate.Text = "[???]";
            lblDateOfBirth.Text = "[???]";

            pbPersonImage.Image = Resources.Male_512;

        }

        void _LoadPersonImage()
        {

            pbPersonImage.Image = _License.DriverInfo.PersonInfo.Gender == 0 ? Resources.Male_512 : Resources.Female_512;

            if (_License.DriverInfo.PersonInfo.ImagePath != "")
            {
                if (File.Exists(_License.DriverInfo.PersonInfo.ImagePath))
                {

                    pbPersonImage.ImageLocation = _License.DriverInfo.PersonInfo.ImagePath;

                }
                else
                {
                    MessageBox.Show("Could not find this image: = " + _License.DriverInfo.PersonInfo.ImagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }

        }
        void _FillValues()
        {

            _LicenseID = _License.LicenseID;

            lblClass.Text = _License.LicenseClassesInfo.ClassName;

            lblDateOfBirth.Text = _License.DriverInfo.PersonInfo.DateOfBirth.ToShortDateString();
            lblFullName.Text = _License.DriverInfo.PersonInfo.FullName;
            lblNationalNo.Text = _License.DriverInfo.PersonInfo.NationalNo;
            lblIssueDate.Text = _License.IssueDate.ToShortDateString();
            lblExpirationDate.Text = _License.ExpirationDate.ToShortDateString();
            lblDriverID.Text = _License.DriverID.ToString();

            lblGendor.Text = _License.DriverInfo.PersonInfo.Gender == 0 ? "Male" : "Female";
            
            lblIsDetained.Text = _License.IsDetained.ToString();
            lblIsActive.Text = _License.IsActive.ToString();
            lblIssueReason.Text = _License.IssueReasonText;
            lblLicenseID.Text = _License.LicenseID.ToString();
            lblNotes.Text= (_License.Notes=="")?"No Notes":_License.Notes;


            _LoadPersonImage();

        }

        public void LoadDriverLicenseInfoByLicenseID(int LicenseID)
        {

            _License=clsLicense.FindLicenseByLicenseID(LicenseID);
            if (_License == null)
            {
                _LicenseID = -1;
                _SetDefaultValues();
                MessageBox.Show("No License with License ID = " + LicenseID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
                
            }

            _FillValues();

        }
        



       

        private void ctrlDrivingLicenseInfo_Load(object sender, EventArgs e)
        {

        }
    }
}
