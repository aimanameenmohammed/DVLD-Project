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
    public partial class ctrlScheduledTest : UserControl
    {
        public ctrlScheduledTest()
        {
            InitializeComponent();
        }
        private void ctrlScheduledTest_Load(object sender, EventArgs e)
        {

        }

        string lblTestIDTxt = "Not Taken Yet";
        clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication;
        clsTestAppointments _TestAppointment;
     
        int _TestID = -1;

        clsTestTypes.enTestType _TestType;

        public clsTestTypes.enTestType TestType
        {

            get
            {
                return _TestType;
            }
            set
            {
                _TestType = value;
                clsFormat.HandleEmageAndTileTestType((clsTestTypes.enTestType)_TestAppointment.TestTypeID, gbTestType, pbTestTypeImage);

            }

        }

        public int TestID
        {

            get
            {
                return _TestID;
            }
            set
            {
                _TestID = value;
            }

        }

    


        int _TestAppointmentID = -1;

        public int TestAppointmentID
        {

            get
            {
                return _TestAppointmentID;
            }
            set
            {
                _TestAppointmentID = value;
            }

        }




        public void LoadTestInfo(int TestAppointmentID)
        {
            _TestAppointment = clsTestAppointments.Find(TestAppointmentID);

            if (_TestAppointment == null)
            {
                MessageBox.Show("No TestAppointment with TestAppointmentID = " +
                    TestAppointmentID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                _TestAppointmentID = -1;

                return;

            }

            _TestAppointmentID = _TestAppointment.TestAppointmentID;
            _TestID = _TestAppointment.TestID;

             _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.FindByLocalDrivingLIcenseID(_TestAppointment.LocalDrivingLicenseApplicationID);

            if (_LocalDrivingLicenseApplication == null)
            {
                MessageBox.Show("Error: No Local Driving License Application with ID = " + _TestAppointment.LocalDrivingLicenseApplicationID.ToString(),
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            lblLocalDrivingLicenseAppID.Text = _LocalDrivingLicenseApplication.LocalDrivingLicenseID.ToString();
            lblFullName.Text = _LocalDrivingLicenseApplication.ApplicantFullName;
            lblDrivingClass.Text = _LocalDrivingLicenseApplication.LicenseClassInfo.ClassName;
            lblFees.Text = _TestAppointment.PaidFees.ToString();
            lblDate.Text = _TestAppointment.AppointmentDate.ToShortDateString();
            lblTrial.Text = _LocalDrivingLicenseApplication.TotalTrialPerTest(_TestType).ToString();

            lblTestID.Text = (_TestAppointment.TestID == -1) ? "No Taken Yet" : _TestAppointment.TestID.ToString();



        }


        private void gbTestType_Enter(object sender, EventArgs e)
        {

        }
    }
}
