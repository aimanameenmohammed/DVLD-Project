using DVLDDataBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FullRealLifeProject19
{
    public partial class frmDriverList : Form
    {
        public frmDriverList()
        {
            InitializeComponent();
        }

        DataTable dtAllDriversInfo;
        private void txtFiltering_TextChanged(object sender, EventArgs e)
        {
            string FilteringColumn = "";


            switch (cmFitering.Text)
            {

                case "Person ID":
                    FilteringColumn = "PersonID";
                    break;

                case "Driver ID":
                    FilteringColumn = "DriverID";
                    break;

                case "National No.":
                    FilteringColumn = "NationalNo";
                    break;

                case "Full Name":
                    FilteringColumn = "FullName";
                    break;
            }

            if (txtFiltering.Text == "")
            {
                dtAllDriversInfo.DefaultView.RowFilter = "";
                lbRecords.Text = dtAllDriversInfo.Rows.Count.ToString();
                return;
            }

            if (FilteringColumn == "PersonID" || FilteringColumn == "DriverID")
                dtAllDriversInfo.DefaultView.RowFilter = string.Format($"{FilteringColumn}  = '{txtFiltering.Text.Trim()}'");

            else
                dtAllDriversInfo.DefaultView.RowFilter = string.Format($"{FilteringColumn}  like '{txtFiltering.Text.Trim()}%'");


            lbRecords.Text = dtAllDriversInfo.Rows.Count.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmDriverList_Load(object sender, EventArgs e)
        {

            dtAllDriversInfo = clsDriver.GetAllDriversInfo();
            dgvDriversList.DataSource=dtAllDriversInfo;
            lbRecords.Text = dtAllDriversInfo.Rows.Count.ToString();

        }

        private void txtFiltering_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (cmFitering.Text == "PersonID" || cmFitering.Text == "DriverID")
                e.Handled = (!char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar));

        }

        private void cmFitering_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFiltering.Visible = (cmFitering.Text != "None");
            txtFiltering.Text = "";
            lbRecords.Text = dtAllDriversInfo.Rows.Count.ToString();


        }

        private void showLicensesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowPersonDetails frm = new frmShowPersonDetails((int)dgvDriversList.CurrentRow.Cells[1].Value);
            frm.ShowDialog();
        }

        private void showPersonHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowPersonLicenseHistory frm = new frmShowPersonLicenseHistory((int)dgvDriversList.CurrentRow.Cells[1].Value);
            frm.ShowDialog();
        }
    }
}
