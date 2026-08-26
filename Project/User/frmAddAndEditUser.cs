using DVLDDataBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FullRealLifeProject19
{
    public partial class frmAddAndEditUser : Form
    {

        enum enMode { Addnew = 1, Update = 2 };

        enMode _Mode= enMode.Addnew;
        int _UserID = -1;
        clsUser _User;

        public frmAddAndEditUser()
        {
            InitializeComponent();
        }


       

        public frmAddAndEditUser(int UserID)
        {
            InitializeComponent();
            _UserID = UserID;
            _Mode=enMode.Update;

        }


        void _SetDefaultValues()
        {
            //this will initialize the reset the defaule values

            if (_Mode == enMode.Addnew)
            {

                lbTitle.Text = "Add New User";
                this.Text = "Add New User";
                _User = new clsUser();

            ctrlShowPersonCardWithfiltering1.Focus();
                btnSave.Enabled = false;
                tbLoginInfo.Enabled = false;

            }
            else
            {
                lbTitle.Text = "Update User";
                this.Text = "Update User";

                tbLoginInfo.Enabled = true;
                btnSave.Enabled = true;

            }

            txtComfirmPassword.Text = string.Empty;
            ckbIsActive.Checked = true;
            txtPassword.Text = string.Empty;
            txtUserName.Text = string.Empty;
            lbUserID.Text = "???";
            tbControl.SelectedIndex = 0;
       
        }


        private void ctrlShowPersonCardWithfiltering1_Load(object sender, EventArgs e)
        {

        }

        void _LoadData()
        {


            _User = clsUser.FindByUserID(_UserID);
            ctrlShowPersonCardWithfiltering1.EnableFilter = false;

            if (_User == null)
            {
                MessageBox.Show("No User with ID = " + _User, "User Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();

                return;
            }

         

            lbUserID.Text = _User.UserID.ToString();
            ctrlShowPersonCardWithfiltering1.LoadPersonInfo(_User.PersonID);
            txtComfirmPassword.Text = _User.Password;
            txtUserName.Text = _User.UserName;
            txtPassword.Text= _User.Password;
            ckbIsActive.Checked = _User.IsActive;

        }
        private void frmAddNewUser_Load(object sender, EventArgs e)
        {
            _SetDefaultValues();

            if (_Mode == enMode.Update)
                _LoadData();
        }

      

        bool _btnNext()
        {


            if(_Mode==enMode.Update)
            {
                btnSave.Enabled = true;
                tbLoginInfo.Enabled = true;
                tbControl.SelectedTab = tbControl.TabPages["tbLoginInfo"];
                return true;
            }

            if (ctrlShowPersonCardWithfiltering1.PersonID != -1)
            {

                if (clsUser.isUserExistForPersonID(ctrlShowPersonCardWithfiltering1.PersonID))
                {

                    MessageBox.Show("Selected person already has a user,choose another one.", "Select another person", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnSave.Enabled = false;
                    tbLoginInfo.Enabled = false;
                    return false;

                }
                else
                {
                    btnSave.Enabled = true;
                    tbLoginInfo.Enabled = true;
                    return true;
                }

            }
            else
            {
                MessageBox.Show("Please select a person !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSave.Enabled = false;
                tbLoginInfo.Enabled = false;
                return false;
            }



        }

        void _Save()
        {


            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (!_btnNext())
                return;

            _User.PersonID = ctrlShowPersonCardWithfiltering1.PersonID;
            _User.Password = txtPassword.Text.Trim();
            _User.UserName = txtUserName.Text.Trim();
            _User.IsActive = ckbIsActive.Checked;

            if (_User.Save())
            {

                _Mode = enMode.Update;
                lbTitle.Text = "Update User";
                this.Text = "Update User";

                ctrlShowPersonCardWithfiltering1.EnableFilter = false;
                lbUserID.Text = _User.UserID.ToString();

                MessageBox.Show("Data saved successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Faild Save Data", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);


        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            _btnNext();
        }

        private void tbControl_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _Save();
        }

        private void txtComfirmPassword_Validating(object sender, CancelEventArgs e)
        {

            if (txtPassword.Text != txtComfirmPassword.Text)
            {

                e.Cancel = true;
                errorProvider1.SetError(txtComfirmPassword, "Comfirmation Password does not match the password !");
                return;
            }

            else
                errorProvider1.SetError(txtComfirmPassword, null);
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtPassword.Text))
            {

                e.Cancel = true;
                errorProvider1.SetError(txtPassword, "Password cannot be blank!");
                return;
            }

            else
                errorProvider1.SetError(txtPassword, null);
        }
        
        private void txtUserName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtUserName.Text))
            {

                e.Cancel = true;
                errorProvider1.SetError(txtUserName, "User Name cannot be blank!");
                return;
            }
            else
                errorProvider1.SetError(txtUserName, null);

            if (_Mode == enMode.Addnew)
            {

                if (clsUser.IsUserExists(txtUserName.Text.Trim()))
                {


                    e.Cancel = true;
                    errorProvider1.SetError(txtUserName, "This User Name is already used by another one");
                    return;

                }
                else
                    errorProvider1.SetError(txtUserName, null);
            }
            else
            {
                if (_User.UserName != txtUserName.Text.Trim())
                {
                    if (clsUser.IsUserExists(txtUserName.Text.Trim()))
                    {


                        e.Cancel = true;
                        errorProvider1.SetError(txtUserName, "This User Name is already used by another one");
                        return;

                    }
                    else
                        errorProvider1.SetError(txtUserName, null);
                }

                }



            





           
        }
    }
}
