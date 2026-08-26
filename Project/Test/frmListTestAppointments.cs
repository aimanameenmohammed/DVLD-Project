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
    public partial class frmListTestAppointments : Form
    {
        int _LocalDrivingLicenseApplicationID;
        clsTestTypes.enTestType _TestType;

        public frmListTestAppointments(int LocalDrivingLicenseApplicationID,clsTestTypes.enTestType TestType)
        {
            InitializeComponent();

            _LocalDrivingLicenseApplicationID= LocalDrivingLicenseApplicationID;
            _TestType= TestType;

        }

       
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }


        static DataTable dtAllAppointmentInfo;

       
        void _RefreshAppointmentList()
        {

            dtAllAppointmentInfo = clsTestAppointments.GetAllAppointmentInfoByLDLApplicationIDAndTestType(_LocalDrivingLicenseApplicationID, _TestType);
            if(dtAllAppointmentInfo.Rows.Count>0)
            dgvAppointmentList.DataSource = dtAllAppointmentInfo.DefaultView.ToTable(false, "TestAppointmentID", "AppointmentDate", "PaidFees", "IsLocked");
            lbRecords.Text=dgvAppointmentList.Rows.Count.ToString();

        }

        private void frmVisionTestAppointments_Load(object sender, EventArgs e)
        {
            _RefreshAppointmentList();

            clsFormat.HandleEmageAndTileTestType(_TestType, lbTestType, pbTestType);
            lbTestType.Text += " Appointment";
            this.Text = lbTestType.Text;
            ctrlDrivingLicenseApplicationInfo1.LoadApplicationInfoByLocalDrivingLicenseAppID(_LocalDrivingLicenseApplicationID);

        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


      
        private void btnAddUser_Click(object sender, EventArgs e)
        {



            //clsLocalDrivingLicenseApplication localDrivingLicenseApplication =
            //    clsLocalDrivingLicenseApplication.FindByLocalDrivingLIcenseID(_LocalDrivingLicenseApplicationID);


            if (clsTestAppointments.IsThereAnActiveScheduleTest(_LocalDrivingLicenseApplicationID, _TestType))
            {

                MessageBox.Show("Person Already have an active appointment for this test,You cannot add new appointment", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //
            //clsTests LastTest=clsTests.GetLastTestPerTestType(_LocalDrivingLicenseApplicationID, _TestType);

            //if (LastTest == null)
            //{

            //    frmScheduleTest frm1 = new frmScheduleTest(_LocalDrivingLicenseApplicationID, _TestType);

            //    frm1.ShowDialog();
            //    _RefreshAppointmentList();
            //    return;

            //}

            if (clsTestAppointments.DoesPassedTestType(_LocalDrivingLicenseApplicationID,_TestType))
            {

                MessageBox.Show("this person already passed this test before,you can only retake faild test", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


           
            frmScheduleTest frm2 = new frmScheduleTest(_LocalDrivingLicenseApplicationID, _TestType);

            frm2.ShowDialog();
            _RefreshAppointmentList();

        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmScheduleTest frm = new frmScheduleTest(_LocalDrivingLicenseApplicationID,_TestType,(int)dgvAppointmentList.CurrentRow.Cells[1].Value);
            frm.ShowDialog();
            _RefreshAppointmentList();
        }

        private void takeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTakeTest frm = new frmTakeTest((int)dgvAppointmentList.CurrentRow.Cells[1].Value,_TestType);
            frm.ShowDialog();
            _RefreshAppointmentList();

        }
    }
}
