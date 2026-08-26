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
    public partial class ctrlDriverLicense : UserControl
    {
        public ctrlDriverLicense()
        {
            InitializeComponent();
        }

        int _PersonID;
        void LoadInternationalLicense()
        {

            DataTable AllInternationalLicense= clsInternationalLicense.GetAllInternationalLicenseInfoByPersonID(_PersonID);
            if (AllInternationalLicense.Rows.Count > 0)  
                dgvInternationalLicensesHistory.DataSource = AllInternationalLicense.DefaultView.ToTable(false, "InternationalLicenseID", "ApplicationID"
                   , "IssuedUsingLocalLicenseID", "IssueDate", "ExpirationDate", "IsActive");

                lblInternationalLicensesRecords.Text = dgvInternationalLicensesHistory.Rows.Count.ToString();
         
        }

        void LoadLocalLicense()
        {


            DataTable AllLocalLicenseInfo=clsLicense.GetAllLocalLicenseInfoByPersonID( _PersonID);
            if (AllLocalLicenseInfo.Rows.Count > 0)
                dgvLocalLicensesHistory.DataSource = AllLocalLicenseInfo;

            lblLocalLicensesRecords.Text = dgvLocalLicensesHistory.Rows.Count.ToString();

        }

        public void LoadPersonLicenseInfo(int PersonID)
        {



            clsDriver Driver = clsDriver.FindByPersonID(PersonID);
            if (Driver != null)
            {
               MessageBox.Show("this Person ID not Link to Driver ","No Allow",MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            _PersonID = Driver.PersonID;
            LoadInternationalLicense();
            LoadLocalLicense();



        }

        private void dgvLocalLicensesHistory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void showLicenseInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowLicenseInfo frm = new frmShowLicenseInfo((int)dgvLocalLicensesHistory.CurrentRow.Cells[0].Value);
            frm.ShowDialog();

        }

        private void showLicenseInfoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmShowInternationalLicenseInfo frm = new frmShowInternationalLicenseInfo((int)dgvInternationalLicensesHistory.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }
    }
}
