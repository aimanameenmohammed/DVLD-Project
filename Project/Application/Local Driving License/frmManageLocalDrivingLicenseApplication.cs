using DVLDDataBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DVLDDataBusinessLayer.clsTestTypes;

namespace FullRealLifeProject19
{
    public partial class frmManageLocalDrivingLicenseApplication : Form
    {
        public frmManageLocalDrivingLicenseApplication()
        {
            InitializeComponent();
        }


        private  DataTable dtAllLocalDrivingLicenseApplications;

        private void frmManageLocalDrivingLicenseApplication_Load(object sender, EventArgs e)
        {

            _RefreshApplicationList();

        }

        void _RefreshApplicationList()
        {

            dtAllLocalDrivingLicenseApplications = clsLocalDrivingLicenseApplication.GetAllLocalDrivingLicenseApplications();
            dgvLDLApplicationList.DataSource = dtAllLocalDrivingLicenseApplications;
            lbRecords.Text = dgvLDLApplicationList.Rows.Count.ToString();
            txtFilteValue.Text = "";
            txtFilteValue.Focus();

        }
        private void cmFitering_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilteValue.Visible = (cmFitering.Text != "None");

            txtFilteValue.Text = "";
            dtAllLocalDrivingLicenseApplications.DefaultView.RowFilter = "";
            lbRecords.Text = dgvLDLApplicationList.Rows.Count.ToString();




        }

        private void txtFilteValue_TextChanged(object sender, EventArgs e)
        {

            string FilteringColumn = "";

            switch (cmFitering.Text)
            {

                case "L.D.L.AppID":
                    FilteringColumn = "LocalDrivingLicenseApplicationID";
                    break;

                case "National No.":
                    FilteringColumn = "NationalNo";
                    break;

                case "Full Name":
                    FilteringColumn = "FullName";
                    break;

                case "Status":
                    FilteringColumn = "Status";
                    break;
            }

            if (txtFilteValue.Text == "")
            {
                dtAllLocalDrivingLicenseApplications.DefaultView.RowFilter = "";
                lbRecords.Text = dtAllLocalDrivingLicenseApplications.Rows.Count.ToString();
                return;
            }

            if (FilteringColumn == "LocalDrivingLicenseApplicationID")
                dtAllLocalDrivingLicenseApplications.DefaultView.RowFilter = string.Format($"{FilteringColumn}  = '{txtFilteValue.Text.Trim()}'");

            else
                dtAllLocalDrivingLicenseApplications.DefaultView.RowFilter = string.Format($"{FilteringColumn}  like '{txtFilteValue.Text.Trim()}%'");


            lbRecords.Text = dgvLDLApplicationList.Rows.Count.ToString();

        }

        private void txtFilteValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cmFitering.Text == "L.D.L.AppID")
                e.Handled = (!char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar));
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {

            frmAddEditLocalDrivingLicenseApplication frm = new frmAddEditLocalDrivingLicenseApplication();
            frm.ShowDialog();
            _RefreshApplicationList();

        }

        private void editApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditLocalDrivingLicenseApplication frm = new frmAddEditLocalDrivingLicenseApplication((int)dgvLDLApplicationList.CurrentRow.Cells[1].Value);
            frm.ShowDialog();
            _RefreshApplicationList();

        }

        private void deleteApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Are you sure you want to delete this Application?", "Confirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {

                clsLocalDrivingLicenseApplication LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.FindByLocalDrivingLIcenseID((int)dgvLDLApplicationList.CurrentRow.Cells[1].Value);


                if (LocalDrivingLicenseApplication != null)
                {
                    //Perform Delele and refresh
                    if (LocalDrivingLicenseApplication.Delete())
                    {

                        MessageBox.Show("Application Deleted Successfully.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        _RefreshApplicationList();
                    }
                    else
                        MessageBox.Show("Could not delete application ,other data depends on it.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void showApplicationDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmLocalDrivingLicenseApplicationInfo frm = new frmLocalDrivingLicenseApplicationInfo((int)dgvLDLApplicationList.CurrentRow.Cells[1].Value);
            frm.ShowDialog();
            _RefreshApplicationList();

        }


        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

            int PassedTestCount = (int)dgvLDLApplicationList.CurrentRow.Cells[6].Value;
            clsLocalDrivingLicenseApplication LocalDrivingLicenseApp = clsLocalDrivingLicenseApplication.FindByLocalDrivingLIcenseID((int)dgvLDLApplicationList.CurrentRow.Cells[1].Value);


            bool ISLicenseExists = LocalDrivingLicenseApp.IsLicenseIssued();

             editApplicationTSM.Enabled =   !ISLicenseExists && (clsApplication.enApplicationStatus.New == LocalDrivingLicenseApp.ApplicationStatus);
            cancelApplicationTSM.Enabled = (clsApplication.enApplicationStatus.New == LocalDrivingLicenseApp.ApplicationStatus);
            deleteApplicationTSM.Enabled =(clsApplication.enApplicationStatus.New == LocalDrivingLicenseApp.ApplicationStatus);


            issueDrivingLicenseFirstTimeTSM.Enabled = (PassedTestCount == 3) && (clsApplication.enApplicationStatus.New == LocalDrivingLicenseApp.ApplicationStatus) && !ISLicenseExists;
            showLicenseTSM.Enabled = ISLicenseExists;
            sechduleTestsTSM.Enabled = !ISLicenseExists;

            bool PassedVisionTest = LocalDrivingLicenseApp.DoesPassedTestType(clsTestTypes.enTestType.VisionTest);
            bool PassedWrittenTest = LocalDrivingLicenseApp.DoesPassedTestType(clsTestTypes.enTestType.WrittenTest);
            bool PassedStreetTest = LocalDrivingLicenseApp.DoesPassedTestType(clsTestTypes.enTestType.StreetTest);

            sechduleTestsTSM.Enabled = (!PassedStreetTest || !PassedVisionTest || !PassedWrittenTest) && (clsApplication.enApplicationStatus.New == LocalDrivingLicenseApp.ApplicationStatus);

            if (sechduleTestsTSM.Enabled)
            {
                scheduleVisionTestTSM.Enabled = !PassedVisionTest;

                scheduleWrittenTestTSM.Enabled = !PassedWrittenTest && PassedVisionTest;

                scheduleStreetTestTSM.Enabled = !PassedStreetTest && PassedWrittenTest && PassedVisionTest;
            }


        }


        private void showLicenseTSM_Click(object sender, EventArgs e)
        {

            int licenseID = clsLicense.GetLicenseIDByLocalDLApplicationID((int)dgvLDLApplicationList.CurrentRow.Cells[1].Value);

            if (licenseID != -1)
            {

                frmShowLicenseInfo frm = new frmShowLicenseInfo(licenseID);
                frm.ShowDialog();

            }
            else
            {
                MessageBox.Show("No License Found!", "No License", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
                



        }

        private void cancelApplicationTSM_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Are you sure you want to Cancel this Application?", "Confirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                //Perform cancel and refresh
                clsLocalDrivingLicenseApplication localDrivingLicenseApplication = clsLocalDrivingLicenseApplication.FindByLocalDrivingLIcenseID((int)dgvLDLApplicationList.CurrentRow.Cells[1].Value);


                if (localDrivingLicenseApplication.Cancelled())
                {
                    MessageBox.Show("Application Cancelled Successfully.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _RefreshApplicationList();
                }
                else
                    MessageBox.Show("Failed Cancelled Application.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }


        private void ScheduleTestType(clsTestTypes.enTestType TestType)
        {

            frmListTestAppointments frm = new frmListTestAppointments((int)dgvLDLApplicationList.CurrentRow.Cells[1].Value, TestType);
            frm.ShowDialog();
            _RefreshApplicationList();

        }


        private void scheduleVisionTestTSM_Click(object sender, EventArgs e)
        {
            ScheduleTestType(clsTestTypes.enTestType.VisionTest);

        }

        private void scheduleWrittenTestTSM_Click(object sender, EventArgs e)
        {
            ScheduleTestType(clsTestTypes.enTestType.WrittenTest);

        }

        private void scheduleStreetTestTSM_Click(object sender, EventArgs e)
        {
            ScheduleTestType(clsTestTypes.enTestType.StreetTest);

        }

        private void issueDrivingLicenseFirstTimeTSM_Click(object sender, EventArgs e)
        {
            frmIssueDriverLicenseFirstTime frm = new frmIssueDriverLicenseFirstTime((int)dgvLDLApplicationList.CurrentRow.Cells[1].Value);
            frm.ShowDialog();
            _RefreshApplicationList();

        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowPersonLicenseHistory frm = new frmShowPersonLicenseHistory(clsLocalDrivingLicenseApplication.GetApplicaitonPersonIDByLDLApplicaitonID((int)dgvLDLApplicationList.CurrentRow.Cells[1].Value));
            frm.ShowDialog();
            _RefreshApplicationList();

        }
    }
}
