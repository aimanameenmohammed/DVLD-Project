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
    public partial class frmTakeTest : Form
    {

        int _TestAppointmentID;
        clsTests _Test;
        clsTestTypes.enTestType _TestType;
        public frmTakeTest(int TestAppointmentID ,clsTestTypes.enTestType TestType)
        {
            InitializeComponent();
            _TestAppointmentID = TestAppointmentID;
            _TestType = TestType;
        }

     
        void _LoadInfo()
        {
            ctrlScheduledTest1.TestType = _TestType;
            ctrlScheduledTest1.LoadTestInfo(_TestAppointmentID);


            if (ctrlScheduledTest1.TestAppointmentID == -1)
                btnSave.Enabled = false;
            else
                btnSave.Enabled = true;



            if (ctrlScheduledTest1.TestID != -1)
            {
                _Test = clsTests.Find(_TestAppointmentID);

                if (_Test == null)
                {
                    MessageBox.Show("No Test with TestAppointmentID = " + _TestAppointmentID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }

                txtNotes.Text = _Test.Notes;

                if (_Test.TestResult)
                    rbPass.Checked = true;
                else
                    rbFail.Checked = true;

                rbFail.Enabled = false;
                rbPass.Enabled = false;
                lblUserMessage.Visible = true;

            }
            else
            {
                _Test = new clsTests();
            }

        }


        private void frmTakeTest_Load(object sender, EventArgs e)
        {
            _LoadInfo();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {


            _Test.TestAppointmentID = _TestAppointmentID;
            _Test.Notes = txtNotes.Text.Trim();
            _Test.TestResult = rbPass.Checked;
            _Test.CreatedByUserID = GlobalSettings.CurrenctUser.UserID;


            if (MessageBox.Show("Are you sure  you want to save? After that you cannot change the Pass/Fail results after you save?.", "Confirm", MessageBoxButtons.OK, MessageBoxIcon.Warning) == DialogResult.OK)
            {

                if (_Test.Save())
                {

                    MessageBox.Show("Data saved successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                    MessageBox.Show("Data Not saved" .ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.Close();


        }
    }
}
