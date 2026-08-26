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
using System.Windows.Media.Animation;

namespace FullRealLifeProject19
{
    public partial class frmManageUsers : Form
    {
        public frmManageUsers()
        {
            InitializeComponent();
        }

        private void callToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }




        private static DataTable _dtAllUsers = clsUser.GetAllUsersData();

        private DataTable _dtUsers = _dtAllUsers.DefaultView.ToTable(false, "UserID", "PersonID", "FullName", "UserName", "IsActive");



        private void _RefreshUserData()
        {
            _dtAllUsers = clsUser.GetAllUsersData();
            _dtUsers = _dtAllUsers.DefaultView.ToTable(false, "UserID", "PersonID", "FullName", "UserName", "IsActive");

            dgvUsersList.DataSource = _dtUsers;
            lbNumberOfUsers.Text = _dtUsers.Rows.Count.ToString();
        }

        void _Filtering()
        {


            string FilteringColumn = "";

            switch (cmFitering.Text)
            {

                case "Person ID":
                    FilteringColumn = "PersonID";
                    break;

                case "User ID":
                    FilteringColumn = "UserID";
                    break;

                case "Full Name":
                    FilteringColumn = "FullName";
                    break;

                case "User Name":
                    FilteringColumn = "UserName";
                    break;
            }

            if (txtFiltering.Text == "")
            {
                _dtUsers.DefaultView.RowFilter = "";
                lbNumberOfUsers.Text = _dtUsers.Rows.Count.ToString();
                return;
            }

            if (FilteringColumn == "PersonID" || FilteringColumn == "UserID")
                _dtUsers.DefaultView.RowFilter = string.Format($"{FilteringColumn}  = '{txtFiltering.Text.Trim()}'");

            else
                _dtUsers.DefaultView.RowFilter = string.Format($"{FilteringColumn}  like '{txtFiltering.Text.Trim()}%'");


            lbNumberOfUsers.Text = dgvUsersList.Rows.Count.ToString();

        }


        private void frmManageUsers_Load(object sender, EventArgs e)
        {

            dgvUsersList.DataSource = _dtUsers;
            lbNumberOfUsers.Text = _dtUsers.Rows.Count.ToString();

        }

        private void cmFitering_SelectedIndexChanged(object sender, EventArgs e)
        {



            txtFiltering.Visible = (cmFitering.Text != "None");
            cmIsActiveOrno.Visible = (cmFitering.Text == "Is Active");


            if (cmIsActiveOrno.Visible)
            {
                txtFiltering.Visible = false;
                cmIsActiveOrno.SelectedIndex = cmIsActiveOrno.FindString("All");
                cmIsActiveOrno.Focus();
            }
            else
            {
                txtFiltering.Focus();
                txtFiltering.Text = "";
            }


                _dtUsers.DefaultView.RowFilter = "";
            lbNumberOfUsers.Text = _dtUsers.Rows.Count.ToString();


        }

        private void txtFiltering_TextChanged(object sender, EventArgs e)
        {
            _Filtering();
        }

        private void txtFiltering_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cmFitering.Text == "Person ID" || cmFitering.Text == "User ID")
                e.Handled = (!char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar));
        }

        private void cmIsActiveOrno_SelectedIndexChanged(object sender, EventArgs e)
        {

            string FilterColumn = "IsActive";

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
                _dtUsers.DefaultView.RowFilter = "";
            else
                _dtUsers.DefaultView.RowFilter = string.Format($"{FilterColumn} = '{FilterValue}'");


            lbNumberOfUsers.Text = dgvUsersList.Rows.Count.ToString();

        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            frmAddAndEditUser frm = new frmAddAndEditUser();
            frm.ShowDialog();
            _RefreshUserData();
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmUserInfo(Convert.ToInt32(dgvUsersList.CurrentRow.Cells[0].Value));
            frm.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddAndEditUser frm = new frmAddAndEditUser(Convert.ToInt32(dgvUsersList.CurrentRow.Cells[0].Value));
            frm.ShowDialog();
            _RefreshUserData();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete User [" + dgvUsersList.CurrentRow.Cells[0].Value + "]", "Confirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)

            {


                //Perform Delele and refresh
                if (clsUser.DeleteUser((int)dgvUsersList.CurrentRow.Cells[0].Value))
                {

                    MessageBox.Show("User Deleted Successfully.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _RefreshUserData();

                }

                else
                    MessageBox.Show("User was not deleted because it has data linked to it.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }



        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangePassword frm = new frmChangePassword((int)dgvUsersList.CurrentRow.Cells[0].Value);
            frm.ShowDialog();

        }

        private void addNewUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddAndEditUser frm = new frmAddAndEditUser();
            frm.ShowDialog();
            _RefreshUserData();
        }
    }
}

