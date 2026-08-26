using DVLDDataBusinessLayer;
using FullRealLifeProject19.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DVLDDataBusinessLayer.clsTestTypes;

namespace FullRealLifeProject19
{
    public partial class ctrlScheduleTest : UserControl
    {

      
        public ctrlScheduleTest()
        {
            InitializeComponent();
        }



        enum enMode { enAddnew=1 , enUpdate=2 }
        enMode _Mode=enMode.enAddnew;
        enum enCreationMode { RetakeTestSchedule=1,FirstTimeSchedule=2}

        enCreationMode _CreationMode = enCreationMode.FirstTimeSchedule;

        clsLocalDrivingLicenseApplication _LocalDrivingLicenseApp;
        clsTestAppointments _TestAppointment;
        clsTestTypes.enTestType _TestType;
        int _TestAppointmentID;
        public clsTestTypes.enTestType TestTypeID
        {

            get
            {
                return _TestType;
            }
            set
            {
                _TestType = value;
                clsFormat.HandleEmageAndTileTestType(_TestType, gbTestType, pbTestTypeImage);

            }

        }




        public void LoadInfo(int LocalDrivingLicenseApplicationID,int TestAppointmentID=-1)
        {

            if (TestAppointmentID != -1)
                _Mode = enMode.enUpdate;
            else
                _Mode = enMode.enAddnew;

            _TestAppointmentID = TestAppointmentID;
                _LocalDrivingLicenseApp = clsLocalDrivingLicenseApplication.FindByLocalDrivingLIcenseID(
                    LocalDrivingLicenseApplicationID);

            if (_LocalDrivingLicenseApp == null)
            {
                MessageBox.Show("No LocalDrivingLicenseApplicant with LDLApplicationID = "
                    + LocalDrivingLicenseApplicationID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSave.Enabled = false;
                return;
            }


            if (_LocalDrivingLicenseApp.DoesAttendTestType(_TestType))
                _CreationMode = enCreationMode.RetakeTestSchedule;

            else
                _CreationMode = enCreationMode.FirstTimeSchedule;



            if(_CreationMode==enCreationMode.RetakeTestSchedule)
            {

                lblRetakeAppFees.Text = clsApplicationTypes.Find((int)clsApplication.enApplicationType.RetakeTest).ApplicationFees.ToString();
                gbRetakeTestInfo.Enabled = true;
                lblTitle.Text = "Schedule Retake Test";

            }
            else
            {

                lblRetakeAppFees.Text = "0";
                gbRetakeTestInfo.Enabled = false;
                lblTitle.Text = "Schedule Test";
                lblRetakeTestAppID.Text = "N/A";

            }


            lblDrivingClass.Text = _LocalDrivingLicenseApp.LicenseClassInfo.ClassName;
            lblLocalDrivingLicenseAppID.Text = _LocalDrivingLicenseApp.LocalDrivingLicenseID.ToString();
            lblFullName.Text =_LocalDrivingLicenseApp.ApplicantFullName;
            lblTrial.Text = _LocalDrivingLicenseApp.TotalTrialPerTest(_TestType).ToString();


            if(_Mode==enMode.enAddnew)
            {

                lblFees.Text = clsTestTypes.Find(_TestType).TestTypeFees.ToString();
                clsFormat.HandleEmageAndTileTestType(_TestType, gbTestType, pbTestTypeImage);

                _TestAppointment = new clsTestAppointments();
                dtpTestDate.MinDate = DateTime.Now;
            }
            else
            {
                if (!_LoadTestAppointmentInfo())
                    return;
            }

            lblTotalFees.Text = ((Convert.ToSingle(lblFees.Text)) + (Convert.ToSingle(lblRetakeAppFees.Text))).ToString();

            if (!_HandleAnActiveTestAppointmentConstraint())
                return;

            if (!_HandleTestAppointmentLockedConstraint())
                return;

            if (!_HandlePrviousTestConstraint())
                return;

        }


        private bool _HandlePrviousTestConstraint()
        {
            //we need to make sure that this person passed the prvious required test before apply to the new test.
            //person cannno apply for written test unless s/he passes the vision test.
            //person cannot apply for street test unless s/he passes the written test.

            switch (TestTypeID)
            {
                case clsTestTypes.enTestType.VisionTest:
                    //in this case no required prvious test to pass.
                    lblShowErrorMessage.Visible = false;

                    return true;

                case clsTestTypes.enTestType.WrittenTest:
                    //Written Test, you cannot sechdule it before person passes the vision test.
                    //we check if pass visiontest 1.
                    if (!_LocalDrivingLicenseApp.DoesPassedTestType(clsTestTypes.enTestType.VisionTest))
                    {
                        lblShowErrorMessage.Text = "Cannot Sechule, Vision Test should be passed first";
                        lblShowErrorMessage.Visible = true;
                        btnSave.Enabled = false;
                        dtpTestDate.Enabled = false;
                        return false;
                    }
                    else
                    {
                        lblShowErrorMessage.Visible = false;
                        btnSave.Enabled = true;
                        dtpTestDate.Enabled = true;
                    }


                    return true;

                case clsTestTypes.enTestType.StreetTest:

                    //Street Test, you cannot sechdule it before person passes the written test.
                    //we check if pass Written 2.
                    if (!_LocalDrivingLicenseApp.DoesPassedTestType(clsTestTypes.enTestType.WrittenTest))
                    {
                        lblShowErrorMessage.Text = "Cannot Sechule, Written Test should be passed first";
                        lblShowErrorMessage.Visible = true;
                        btnSave.Enabled = false;
                        dtpTestDate.Enabled = false;
                        return false;
                    }
                    else
                    {
                        lblShowErrorMessage.Visible = false;
                        btnSave.Enabled = true;
                        dtpTestDate.Enabled = true;
                    }


                    return true;

            }
            return true;

        }

        bool _HandleAnActiveTestAppointmentConstraint()
        {

            if (_Mode == enMode.enAddnew && _LocalDrivingLicenseApp.IsThereAnActiveShedultTest(_TestType))
            {
                btnSave.Enabled= false;
                lblShowErrorMessage.Text = "Person Already have an active appointment for this test";
                lblShowErrorMessage.Visible = true;
                dtpTestDate.Enabled= false;
                return false;

            }

            return true;

        }

        bool _HandleTestAppointmentLockedConstraint()
        {

            if (_TestAppointment.IsLocked)
            {

                btnSave.Enabled = false;
                dtpTestDate.Enabled = false;
                lblShowErrorMessage.Text = "Person already sat for the test, appointment loacked.";
                lblShowErrorMessage.Visible = true;

                return false;

            }
            else
                lblShowErrorMessage.Visible = false;

            return true;

        }

        bool _LoadTestAppointmentInfo()
        {

             _TestAppointment = clsTestAppointments.Find(_TestAppointmentID);


            if (_TestAppointment == null)
            {
                MessageBox.Show("Error: No Appointment with ID = " + _TestAppointmentID.ToString(),
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSave.Enabled = false;
                return false;
            }


            _TestType = (clsTestTypes.enTestType)_TestAppointment.TestTypeID;
            lblFees.Text=_TestAppointment.PaidFees.ToString();

            if (_TestAppointment.RetakeTestApplicationID != -1)
            {
                lblRetakeTestAppID.Text=_TestAppointment.RetakeTestApplicationID.ToString();
                lblRetakeAppFees.Text = _TestAppointment.RetakeTestApplication.PaidFees.ToString();
                gbRetakeTestInfo.Enabled = true;
                lblTitle.Text = "Schedule Retake Test";
            }

            if (DateTime.Compare(DateTime.Now, _TestAppointment.AppointmentDate) < 0)
            {
                dtpTestDate.MinDate = DateTime.Now;
            }
            else
                dtpTestDate.MinDate = _TestAppointment.AppointmentDate;


            dtpTestDate.Value = _TestAppointment.AppointmentDate;

           

            return true;
        }

      



        private void ctrlScheduleTest_Load(object sender, EventArgs e)
        {

        }

        bool _AddRetakeTestApplication()
        {


            if (_Mode == enMode.enAddnew && _CreationMode == enCreationMode.RetakeTestSchedule)
            {

                clsApplication RetakeApplication = new clsApplication();


                RetakeApplication.ApplicationTypeID = (int)clsApplication.enApplicationType.RetakeTest;
                RetakeApplication.PaidFees = clsApplicationTypes.Find((int)clsApplication.enApplicationType.RetakeTest).ApplicationFees;

                RetakeApplication.ApplicationStatus = clsApplication.enApplicationStatus.Completed;
                RetakeApplication.ApplicationDate = DateTime.Now;
                RetakeApplication.LastStatusDate = DateTime.Now;
                RetakeApplication.ApplicantPersonID = _LocalDrivingLicenseApp.ApplicantPersonID;
                RetakeApplication.CreatedByUserID = GlobalSettings.CurrenctUser.UserID;

                if(!RetakeApplication.Save())
                {

                    _TestAppointment.RetakeTestApplicationID = -1;
                    MessageBox.Show("Faild to Create application", "Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                _TestAppointment.RetakeTestApplicationID = RetakeApplication.ApplicationID;
            }

            return true;

        }


        void _Save()
        {


            if (!_AddRetakeTestApplication())
                return;
            

         

            _TestAppointment.LocalDrivingLicenseApplicationID = _LocalDrivingLicenseApp.LocalDrivingLicenseID;
            _TestAppointment.PaidFees = Convert.ToSingle(lblFees.Text);
            _TestAppointment.TestTypeID = (int)_TestType;
            _TestAppointment.AppointmentDate = dtpTestDate.Value;
            _TestAppointment.CreatedByUserID = GlobalSettings.CurrenctUser.UserID;

            if(_TestAppointment.Save())
            {
                _Mode = enMode.enUpdate;
                MessageBox.Show("Data saved successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
                MessageBox.Show("Failed Save Data S", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);


            this.FindForm().Close();


        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            _Save();
           
        }

        private void gbTestType_Enter(object sender, EventArgs e)
        {

        }
    }
}
