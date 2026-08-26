using DVLDDataBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FullRealLifeProject19
{
    public partial class frmAddEditLocalDrivingLicenseApplication : Form
    {



        int _LocalDrivingLicenseID;
        enum enMode { Addnew = 1, Update = 2 };
        enMode _Mode=enMode.Addnew;

        int _SelectedPersonID;

        clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication;


        public frmAddEditLocalDrivingLicenseApplication()
        {
            InitializeComponent();
        }
        public frmAddEditLocalDrivingLicenseApplication(int LocalDrivingLicenseID)
        {
            InitializeComponent();
            _LocalDrivingLicenseID = LocalDrivingLicenseID;
            _Mode = enMode.Update;
        }


        private void frmNewLocalDrivingLicenseApplication_Load(object sender, EventArgs e)
        {
            _SetDefaultValues();
            if (_Mode == enMode.Update)
                _LoadDate();

        }


        void _SetDefaultValues()
        {


            cbLicenseClasses.DataSource = clsLicenseClasses.GetAlllicenseClasses();
            cbLicenseClasses.DisplayMember = "ClassName";
            cbLicenseClasses.ValueMember = "LicenseClassID";//here We Save ClassName And it LicenseclassID
                                                            //because we do not need to give Selected ClassName ID From Database we
                                                            //while give it From /*SelectedValue*/

            if (_Mode == enMode.Addnew)
            {
                lbTitle.Text = "New Local Driving License Application";
                this.Text = "New Local Driving License Application";

                btnSave.Enabled = false;
                tbLoginInfo.Enabled = false;

                lbCreatedByUser.Text = GlobalSettings.CurrenctUser.UserName;
                lbApplicationDate.Text = DateTime.Today.ToString();
                lbApplicationFees.Text = clsApplicationTypes.Find((int)clsApplication.enApplicationType.NewLocalDrivingLicense).ApplicationFees.ToString();

                _LocalDrivingLicenseApplication = new clsLocalDrivingLicenseApplication();
            }
            else
            {

                lbTitle.Text = "Update Local Driving License Application";
                this.Text = "Update Local Driving License Application";
                btnSave.Enabled = true;
                tbLoginInfo.Enabled = true;

            }
           

        }

        void _LoadDate()
        {



            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.FindByLocalDrivingLIcenseID(_LocalDrivingLicenseID);
            ctrlShowPersonCardWithfiltering1.EnableFilter = false;

            if (_LocalDrivingLicenseApplication == null)
            {
                MessageBox.Show("No LocalDrivingLicenseApplication  with ID = " + _LocalDrivingLicenseID, "LocalDrivingLicenseApplication Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();

                return;
            }


            ctrlShowPersonCardWithfiltering1.LoadPersonInfo(_LocalDrivingLicenseApplication.ApplicantPersonID);
            cbLicenseClasses.SelectedIndex = cbLicenseClasses.FindString(_LocalDrivingLicenseApplication.LicenseClassInfo.ClassName);
            lbApplicationDate.Text = _LocalDrivingLicenseApplication.ApplicationDate.ToShortDateString();
            lbApplicationFees.Text = _LocalDrivingLicenseApplication.PaidFees.ToString();
            lbLocalDLApplicationID.Text= _LocalDrivingLicenseApplication.LocalDrivingLicenseID.ToString();
            lbCreatedByUser.Text = clsUser.FindByUserID(_LocalDrivingLicenseApplication.CreatedByUserID).UserName;


        }

      
      

        private void btnNext_Click(object sender, EventArgs e)
        {
          
            
            if (ctrlShowPersonCardWithfiltering1.PersonID!=-1)
            {

                btnSave.Enabled = true;
                tbLoginInfo.Enabled = true;

                tbControl.SelectedTab = tbControl.TabPages["tbLoginInfo"];

            }
            else
            {
                MessageBox.Show("Please select a person !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                btnSave.Enabled = false;
                tbLoginInfo.Enabled = false;
                ctrlShowPersonCardWithfiltering1.FilterFocus();
            }


        }

      


        private bool HandleApplicationException()
        {


            if (_Mode == enMode.Addnew)
                if (!clsLicenseClasses.IsPersonAgeAllowedMinimumAgeOfSelectedLicenseClass
                    ((short)ctrlShowPersonCardWithfiltering1.SelectedPersonInfo.DateOfBirth.Year, (int)cbLicenseClasses.SelectedValue))
                {
                    MessageBox.Show("Application Person's Age is below the minimum required for the Selected license class ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }



            int LicenseClassID = Convert.ToInt32(cbLicenseClasses.SelectedValue);

            string LicenseClassName = "";

            if (_Mode == enMode.Update)
                LicenseClassName = _LocalDrivingLicenseApplication.LicenseClassInfo.ClassName;


            if (cbLicenseClasses.Text.Trim() != LicenseClassName)
            {

                int ActiveApplicationID = clsApplication.GetActiveApplicationIDByLicenseClass(_SelectedPersonID, clsApplication.enApplicationType.NewInternationalLicense, LicenseClassID);
                if (ActiveApplicationID!=-1)
                {
                    MessageBox.Show("Choose another License Class ,the selected Person Already have an active application for the selected class with id=" + ActiveApplicationID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                if (clsLicense.IsLicenseExistByPersonID(_SelectedPersonID, LicenseClassID))
                {
                    MessageBox.Show("Person already have license with the same applied  Driving Class,choose different driving class", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

            }

           
                return true;
        }


        private void btnSave_Click(object sender, EventArgs e)
        {

            if (!HandleApplicationException())
                return;




            _LocalDrivingLicenseApplication.PaidFees = Convert.ToSingle(lbApplicationFees.Text);
            _LocalDrivingLicenseApplication.LicenseClassID = Convert.ToInt32(cbLicenseClasses.SelectedValue);
            _LocalDrivingLicenseApplication.ApplicantPersonID = ctrlShowPersonCardWithfiltering1.PersonID;
            _LocalDrivingLicenseApplication.ApplicationTypeID = (int)clsApplication.enApplicationType.NewLocalDrivingLicense;
            _LocalDrivingLicenseApplication.ApplicationDate = DateTime.Now;
            _LocalDrivingLicenseApplication.LastStatusDate = DateTime.Now;
            _LocalDrivingLicenseApplication.ApplicationStatus = clsApplication.enApplicationStatus.New;
            _LocalDrivingLicenseApplication.CreatedByUserID = GlobalSettings.CurrenctUser.UserID;


            if (_LocalDrivingLicenseApplication.Save())
            {

                lbLocalDLApplicationID.Text = _LocalDrivingLicenseApplication.LocalDrivingLicenseID.ToString();

                _Mode = enMode.Update;
                lbTitle.Text = "Update Local Driving License Application";
                this.Text = "Update Local Driving License Application";
                ctrlShowPersonCardWithfiltering1.EnableFilter = false;

                MessageBox.Show("Data saved successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("Faild Save Data", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void cbLicenseClasses_Validating(object sender, CancelEventArgs e)
        {



        }

        private void ctrlShowPersonCardWithfiltering1_Load(object sender, EventArgs e)
        {

        }

        private void ctrlShowPersonCardWithfiltering1_OnPersonSelected(int obj)
        {
            _SelectedPersonID= obj;
        }
    }
}
