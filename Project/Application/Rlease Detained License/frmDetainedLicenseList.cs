using DVLDDataBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FullRealLifeProject19
{
    public partial class frmDetainedLicenseList : Form
    {
        public frmDetainedLicenseList()
        {
            InitializeComponent();
        }

        private void showLicenseDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowLicenseInfo frm = new frmShowLicenseInfo((int)dgvDetainLicenseList.CurrentRow.Cells[1].Value);
            frm.ShowDialog();
        }


        DataTable dtAllDetainLicenseInfo;

        private void frmDetainedLicenseList_Load(object sender, EventArgs e)
        {

            dtAllDetainLicenseInfo = clsDetainedLicense.GetAllDetainedLicense();
            dgvDetainLicenseList.DataSource = dtAllDetainLicenseInfo;
            lbRecords.Text=dtAllDetainLicenseInfo.Rows.Count.ToString();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmFitering_SelectedIndexChanged(object sender, EventArgs e)
        {

            txtFilteValue.Visible = (cmFitering.Text != "None");
            cmIsActiveOrno.Visible = (cmFitering.Text == "Is Released");


            if (cmIsActiveOrno.Visible)
            {
                txtFilteValue.Visible = false;
                cmIsActiveOrno.SelectedIndex = cmIsActiveOrno.FindString("All");
                cmIsActiveOrno.Focus();
            }
            else
            {
                txtFilteValue.Focus();
                txtFilteValue.Text = "";
            }


            dtAllDetainLicenseInfo.DefaultView.RowFilter = "";
            lbRecords.Text = dtAllDetainLicenseInfo.Rows.Count.ToString();
        }

        private void cmIsActiveOrno_SelectedIndexChanged(object sender, EventArgs e)
        {
            string FilterColumn = "IsReleased";

            string FilterValue = cmIsActiveOrno.Text;


            switch (cmIsActiveOrno.Text)
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
                dtAllDetainLicenseInfo.DefaultView.RowFilter = "";
            else
                dtAllDetainLicenseInfo.DefaultView.RowFilter = string.Format($"{FilterColumn} = '{FilterValue}'");


            lbRecords.Text = dgvDetainLicenseList.Rows.Count.ToString();
        }

        private void txtFilteValue_TextChanged(object sender, EventArgs e)
        {
            string FilteringColumn = "";

     

            switch (cmFitering.Text)
            {

                case "Detain ID":
                    FilteringColumn = "DetainID";
                    break;

                case "National No.":
                    FilteringColumn = "NationalNo";
                    break;

                case "Full Name":
                    FilteringColumn = "FullName";
                    break;

                case "Release Application ID":
                    FilteringColumn = "ReleaseApplicationID";
                    break;
            }

            if (txtFilteValue.Text == ""|| FilteringColumn=="")
            {
                dtAllDetainLicenseInfo.DefaultView.RowFilter = "";
                lbRecords.Text = dtAllDetainLicenseInfo.Rows.Count.ToString();
                return;
            }

            if (FilteringColumn == "DetainID" || FilteringColumn == "ReleaseApplicationID")
                dtAllDetainLicenseInfo.DefaultView.RowFilter = string.Format($"{FilteringColumn}  = '{txtFilteValue.Text.Trim()}'");

            else
                dtAllDetainLicenseInfo.DefaultView.RowFilter = string.Format($"{FilteringColumn}  like '{txtFilteValue.Text.Trim()}%'");


            lbRecords.Text = dgvDetainLicenseList.Rows.Count.ToString();
        }

        private void txtFilteValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cmFitering.Text == "Release Application ID" || cmFitering.Text == "Detain ID")
                e.Handled = (!char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar));
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            frmReleaseDetainedLicense frm=new frmReleaseDetainedLicense();
            frm.ShowDialog();
            frmDetainedLicenseList_Load(null, null);
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            frmDetainedLicense frm = new frmDetainedLicense();
            frm.ShowDialog();
            frmDetainedLicenseList_Load(null, null);
        }

        private void showPersonDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowPersonDetails frm = new frmShowPersonDetails(clsLicense.GetPersonIDByLicenseID((int)dgvDetainLicenseList.CurrentRow.Cells[1].Value));
            frm.ShowDialog();
            frmDetainedLicenseList_Load(null, null);

        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmShowPersonLicenseHistory frm = new frmShowPersonLicenseHistory(clsLicense.GetPersonIDByLicenseID((int)dgvDetainLicenseList.CurrentRow.Cells[1].Value));
            frm.ShowDialog();
            frmDetainedLicenseList_Load(null, null);

        }

        private void releaseDetainedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        { 
            
            
            frmReleaseDetainedLicense frm=new frmReleaseDetainedLicense((int)dgvDetainLicenseList.CurrentRow.Cells[1].Value);
            frm.ShowDialog();
            frmDetainedLicenseList_Load(null, null);

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            releaseDetainedLicenseToolStripMenuItem.Enabled= !((bool)dgvDetainLicenseList.CurrentRow.Cells[3].Value);
        }
    }
}
