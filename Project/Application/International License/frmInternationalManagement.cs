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
    public partial class frmInternationalManagement : Form
    {
        public frmInternationalManagement()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        DataTable _dtAllInternationalLicense;
        DataTable _dtSpecialColumn;
        void _RefreshInternationalLicenseList()
        {

            _dtAllInternationalLicense = clsInternationalLicense.GetAllInterantionalLicenses();
            if (_dtAllInternationalLicense.Rows.Count > 0)
            {
                _dtSpecialColumn = _dtAllInternationalLicense.DefaultView.ToTable(false, "InternationalLicenseID", "ApplicationID", "DriverID"
                   , "IssuedUsingLocalLicenseID", "IssueDate", "ExpirationDate", "IsActive");
                dgvInternationalLicenses.DataSource = _dtSpecialColumn;
            }
            lbRecords.Text = dgvInternationalLicenses.Rows.Count.ToString();

        }

        private void frmInternationalManagement_Load(object sender, EventArgs e)
        {
            _RefreshInternationalLicenseList();
        }

        private void cmFitering_SelectedIndexChanged(object sender, EventArgs e)
        {

            txtFilteValue.Visible = (cmFitering.Text != "None");
            cmIsActive.Visible = (cmFitering.Text == "Is Active");


            if (cmIsActive.Visible)
            {
                txtFilteValue.Visible = false;
                cmIsActive.SelectedIndex = cmIsActive.FindString("All");
                cmIsActive.Focus();
            }
           else if(txtFilteValue.Visible)
            {
                txtFilteValue.Focus();
                txtFilteValue.Text = "";
            }


            _dtAllInternationalLicense.DefaultView.RowFilter = "";
            lbRecords.Text = _dtAllInternationalLicense.Rows.Count.ToString();
        }

        private void txtFilteValue_KeyPress(object sender, KeyPressEventArgs e)
        {

            e.Handled = (!char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar));
        }

        private void txtFilteValue_TextChanged(object sender, EventArgs e)
        {

            string FilteringColumn = "";

            switch (cmFitering.Text)
            {

                case "Driver ID":
                    FilteringColumn = "DriverID";
                    break;

                case "Application ID":
                    FilteringColumn = "ApplicationID";
                    break;

                case "International License ID":
                    FilteringColumn = "InternationalLicenseID";
                    break;

                case "Local License ID":
                    FilteringColumn = "IssuedUsingLocalLicenseID";
                    break;
            }

            if (txtFilteValue.Text == "")
            {
                _dtSpecialColumn.DefaultView.RowFilter = "";
                lbRecords.Text = dgvInternationalLicenses.Rows.Count.ToString();
                return;
            }

            _dtSpecialColumn.DefaultView.RowFilter = string.Format($"{FilteringColumn}  = '{txtFilteValue.Text.Trim()}'");

            lbRecords.Text = dgvInternationalLicenses.Rows.Count.ToString();

        }

        private void cmIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {

            string FilterColumn = "IsActive";

            string FilterValue = cmIsActive.Text;


            switch (cmIsActive.Text)
            {
                case "All":
                    break;

                case "Yes":
                    FilterValue = "True";
                    break;

                case "No":
                    FilterValue = "False";
                    break;

            }


            if (FilterValue == "All")
                _dtSpecialColumn.DefaultView.RowFilter = "";
            else
                _dtSpecialColumn.DefaultView.RowFilter = string.Format($"{FilterColumn} = '{FilterValue}'");


            lbRecords.Text = dgvInternationalLicenses.Rows.Count.ToString();
        }

        private void showPersonDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {


            frmShowPersonDetails frm = new frmShowPersonDetails(clsDriver.GetPersonIDByDriverID((int)dgvInternationalLicenses.CurrentRow.Cells[3].Value));
            frm.ShowDialog();
        }

        private void showLicenseDetailsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmShowInternationalLicenseInfo frm = new frmShowInternationalLicenseInfo((int)dgvInternationalLicenses.CurrentRow.Cells[1].Value);
            frm.ShowDialog();
        }

        private void showPersonLicenseHistoryToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmShowPersonLicenseHistory frm = new frmShowPersonLicenseHistory(clsDriver.GetPersonIDByDriverID((int)dgvInternationalLicenses.CurrentRow.Cells[3].Value));
            frm.ShowDialog();
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            frmNewInternationalLicense frm = new frmNewInternationalLicense();
            frm.ShowDialog();
            _RefreshInternationalLicenseList();
        }
    }
}
