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
    public partial class frmManageApplicationTypes : Form
    {
        public frmManageApplicationTypes()
        {
            InitializeComponent();
        }



        public static DataTable dtAllApplicationTypes = clsApplicationTypes.GetAllApplicationTypes();

        private void editApplicationTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }


        void _RefrechApplicationTypesList()
        {

            dtAllApplicationTypes = clsApplicationTypes.GetAllApplicationTypes();
            dgvApplicationTypes.DataSource = dtAllApplicationTypes;
            lbRecords.Text = dgvApplicationTypes.Rows.Count.ToString();

        }

        private void frmApplicationTypes_Load(object sender, EventArgs e)
        {

            dgvApplicationTypes.DataSource = dtAllApplicationTypes;
            lbRecords.Text = dgvApplicationTypes.Rows.Count.ToString();


        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void editApplicationTypeToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmEditApplicationTypes frm =new frmEditApplicationTypes((int)dgvApplicationTypes.CurrentRow.Cells[1].Value);
            frm.ShowDialog();

            _RefrechApplicationTypesList();
        }
    }
}
