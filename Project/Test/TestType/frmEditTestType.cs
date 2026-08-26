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
    public partial class frmEditTestType : Form
    {
        enum enMode { Update = 0 };

        enMode _Mode = enMode.Update;

        clsTestTypes.enTestType _TestTypeID;
        clsTestTypes _TestType;

        public frmEditTestType(clsTestTypes.enTestType TestTypeID)
        {
            InitializeComponent();
            _TestTypeID = TestTypeID;
        }
        void _setDefaultValues()
        {

            lbID.Text = "???";
            this.Text = "Update Test Types";
            lbTitle.Text = "Update Test Types";
            txtFees.Text = string.Empty;
            txtTitle.Text = string.Empty;
            txtDescription.Text = string.Empty;

        }
        void _LoadData()
        {

            _TestType = clsTestTypes.Find(_TestTypeID);

            if (_TestType == null)
            {
                MessageBox.Show("No Test Type with ID = " + _TestTypeID, "Application Type Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();

                return;
            }

            lbID.Text = ((int)_TestType.ID).ToString();
            txtTitle.Text = _TestType.TestTypeTitle;
            txtFees.Text = _TestType.TestTypeFees.ToString();
            txtDescription.Text= _TestType.TestTypeDescription;

        }

        private void frmEditTestType_Load(object sender, EventArgs e)
        {
            _setDefaultValues();

            if (_Mode == enMode.Update)
                _LoadData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", 
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            _TestType.TestTypeTitle = txtTitle.Text.Trim();
            _TestType.TestTypeFees = Convert.ToSingle(txtFees.Text.Trim());
            _TestType.TestTypeDescription= txtDescription.Text.Trim();


            if (_TestType.Save())
            {

                MessageBox.Show("Date Saved successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Faild Saved Data ", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void txtTitle_Validating(object sender, CancelEventArgs e)
        {


            if (string.IsNullOrEmpty(txtTitle.Text))
            {

                e.Cancel = true;
                errorProvider1.SetError(txtTitle, "Test Title cannot be Empty!");
                return;
            }

            else
                errorProvider1.SetError(txtTitle, null);


        }

        private void txtFees_Validating(object sender, CancelEventArgs e)
        {


            if (string.IsNullOrEmpty(txtFees.Text))
            {

                e.Cancel = true;
                errorProvider1.SetError(txtFees, "Test  Fees cannot be Empty!");
                return;
            }

            else if (!clsValidation.IsNumber(txtFees.Text.Trim()))
            {

                e.Cancel = true;
                errorProvider1.SetError(txtFees, "Invalid Number!");
                return;

            }

            errorProvider1.SetError(txtFees, null);

        }

        private void txtDescription_Validating(object sender, CancelEventArgs e)
        {


            if (string.IsNullOrEmpty(txtDescription.Text))
            {

                e.Cancel = true;
                errorProvider1.SetError(txtDescription, "Test Description cannot be Empty!");
                return;
            }

            else
                errorProvider1.SetError(txtDescription, null);


        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
