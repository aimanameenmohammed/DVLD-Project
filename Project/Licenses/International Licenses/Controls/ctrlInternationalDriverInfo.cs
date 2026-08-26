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
    public partial class ctrlInternationalDriverInfo : UserControl
    {
        public ctrlInternationalDriverInfo()
        {
            InitializeComponent();
        }

        clsInternationalLicense _InternationalLicense;

        private void _LoadPersonImage()
        {
            pbPersonImage.Image = _InternationalLicense.DriverInfo.PersonInfo.Gender == 0 ? Resources.Male_512 : Resources.Female_512;
              

            string ImagePath = _InternationalLicense.DriverInfo.PersonInfo.ImagePath;

            if (ImagePath != "")
                if (File.Exists(ImagePath))
                    pbPersonImage.ImageLocation = ImagePath;
                else
                    MessageBox.Show("Could not find this image: = " + ImagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        void _LoadData()
        {

            lblInternationalLicenseID.Text = _InternationalLicense.InternationalLicenseID.ToString();
            lblExpirationDate.Text = _InternationalLicense.ExpirationDate.ToShortDateString();
            lblIssueDate.Text = _InternationalLicense.IssueDate.ToShortDateString();
            lblLocalLicenseID.Text = _InternationalLicense.IssuedUsingLocalLicenseID.ToString();
            lblIsActive.Text = _InternationalLicense.IsActive.ToString();
            lblDriverID.Text = _InternationalLicense.DriverID.ToString();
            lblApplicationID.Text = _InternationalLicense.ApplicationID.ToString();

            lblFullName.Text = _InternationalLicense.DriverInfo.PersonInfo.FullName;

            lblGendor.Text = _InternationalLicense.DriverInfo.PersonInfo.Gender == 0 ? "Male" : "Female";
            lblNationalNo.Text = _InternationalLicense.DriverInfo.PersonInfo.NationalNo;
            lblDateOfBirth.Text = _InternationalLicense.DriverInfo.PersonInfo.DateOfBirth.ToShortDateString();

            _LoadPersonImage();

        }


        public void LoadInternationalLicenseInfo(int InternationalLicenseID)
        {
            _InternationalLicense = clsInternationalLicense.Find(InternationalLicenseID);

            if (_InternationalLicense == null)
            {
               // _SetDefaultValues();
                MessageBox.Show("No International License with InternationalLicense ID = " + InternationalLicenseID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            _LoadData();

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void ctrlInternationalDriverInfo_Load(object sender, EventArgs e)
        {

        }

      
    }
}
