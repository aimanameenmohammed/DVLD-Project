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
    public partial class frmEditApplicationTypes : Form
    {

        enum enMode { Update=0};

        enMode _Mode=enMode.Update;

        int _ApplicationID;
        clsApplicationTypes _ApplicationType;
        public frmEditApplicationTypes(int ApplicationID)
        {
            InitializeComponent();
            _ApplicationID = ApplicationID;
        }



        void _setDefaultValues()
        {
            
            lbID.Text = "???";
            this.Text = "Update Application Types";
            lbTitle.Text = "Update Application Types";
            txtFees.Text= string.Empty;
            txtTitle.Text= string.Empty;
        }

        void _LoadData()
        {

            _ApplicationType = clsApplicationTypes.Find(_ApplicationID);

            if (_ApplicationType == null)
            {
                MessageBox.Show("No Application Type with ID = " + _ApplicationID, "Application Type Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();

                return;
            }

            lbID.Text = _ApplicationType.ApplicationTypeID.ToString();
            txtTitle.Text = _ApplicationType.ApplicationTitle;
            txtFees.Text = _ApplicationType.ApplicationFees.ToString();

        }

        private void frmEditApplicationTypes_Load(object sender, EventArgs e)
        {
            _setDefaultValues();

            if (_Mode == enMode.Update)
                _LoadData();

        }
        private void txtTitle_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtTitle.Text))
            {

                e.Cancel = true;
                errorProvider1.SetError(txtTitle, "Application Title cannot be Empty!");
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
                errorProvider1.SetError(txtFees, "Application Fees cannot be Empty!");
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

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            _ApplicationType.ApplicationTitle = txtTitle.Text.Trim();
            _ApplicationType.ApplicationFees = Convert.ToSingle(txtFees.Text.Trim());


            if (_ApplicationType.Save())
            {

                MessageBox.Show("Date Saved successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Faild Saved Data ", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);


        }
    }
}
