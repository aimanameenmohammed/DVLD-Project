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
    public partial class frmScheduleTest : Form
    {


        int _localDrivingLicenseApplicationID;
        clsTestTypes.enTestType _TestType;
        int _TestAppointmentID;


        
      

        public frmScheduleTest(int localDrivingLicenseApplicationID,clsTestTypes.enTestType TestType,int TestAppointmentID=-1)
        {

            InitializeComponent();
            _localDrivingLicenseApplicationID = localDrivingLicenseApplicationID;
            _TestType = TestType;
            _TestAppointmentID = TestAppointmentID;

        }
       

        private void frmScheduleTest_Load(object sender, EventArgs e)
        {


            ctrlScheduleTest1.TestTypeID = _TestType;
            ctrlScheduleTest1.LoadInfo(_localDrivingLicenseApplicationID, _TestAppointmentID);

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ctrlScheduleTest1_Load(object sender, EventArgs e)
        {

        }
    }
}
