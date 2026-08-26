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
    public partial class frmChangePassword : Form
    {
        int _UserID;
        clsUser _User;
        public frmChangePassword(int userID)
        {
            InitializeComponent();
            _UserID = userID;
        }

        private void frmChangePassword_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();

            _User = clsUser.FindByUserID(_UserID);

            if (_User == null)
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Could not Find User with id = " + _UserID,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();

                return;

            }

            ctrlUserCard1.LoadUserInfo(_UserID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        void _ResetDefaultValues()
        {
            txtCurrentPassword.Text = string.Empty;
            txtnewPassword.Text = string.Empty;
            txtcomfirmPassword.Text = string.Empty;
            txtCurrentPassword.Focus();
        }

        void _SaveChange()
        {


            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _User.Password=txtnewPassword.Text;

            if(_User.Save())
            {

                MessageBox.Show("Password  Changed successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _ResetDefaultValues();

            }
            else
                MessageBox.Show("Faild Change password!", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }




        private void txtCurrentPassword_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrEmpty(txtCurrentPassword.Text))
            {

                e.Cancel = true;
                errorProvider1.SetError(txtCurrentPassword, "Current Password cannot be blank!");
                return;
            }

            else if (txtCurrentPassword.Text != _User.Password)
            {

                e.Cancel = true;
                errorProvider1.SetError(txtCurrentPassword, "Current Password is wrong!");
                return;
            }


            else
                errorProvider1.SetError(txtCurrentPassword, null);

        }

        private void txtnewPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtnewPassword.Text))
            {

                e.Cancel = true;
                errorProvider1.SetError(txtnewPassword, "New Password cannot be blank!");
                return;
            }

            else
                errorProvider1.SetError(txtnewPassword, null);
        }

        private void txtcomfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (txtcomfirmPassword.Text!=txtnewPassword.Text)
            {

                e.Cancel = true;
                errorProvider1.SetError(txtcomfirmPassword, "Password Comfirmation does not match New Password!");
                return;
            }

            else
                errorProvider1.SetError(txtcomfirmPassword, null);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _SaveChange();
        }
    }
}
