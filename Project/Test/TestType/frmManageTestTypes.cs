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
    public partial class frmManageTestTypes : Form
    {
        public frmManageTestTypes()
        {
            InitializeComponent();
        }

        public static DataTable dtAllTestTypes = clsTestTypes.GetAllTestTypes();

        void _RefrechTestTypesList()
        {

            dtAllTestTypes = clsTestTypes.GetAllTestTypes();
            dgvTestTypes.DataSource = dtAllTestTypes;
            lbRecords.Text = dgvTestTypes.Rows.Count.ToString();

        }
        private void frmManageTestTypes_Load(object sender, EventArgs e)
        {

            dgvTestTypes.DataSource= dtAllTestTypes;
            lbRecords.Text=dgvTestTypes.Rows.Count.ToString();

        }

        private void editTestTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmEditTestType frm = new frmEditTestType((clsTestTypes.enTestType)dgvTestTypes.CurrentRow.Cells[1].Value);
            frm.ShowDialog();
            _RefrechTestTypesList();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
