using DVLDDataBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Windows.Shapes;

namespace FullRealLifeProject19
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }


        clsUser _User;

        private void pbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }



     
        void CheckUserInfo()
        {



            _User = clsUser.FindByUsernameAndPassword(txtUserName.Text.Trim(), txtPassword.Text.Trim());

           

            if (_User != null)
            {



                if (chkRememberMe.Checked)
                {
                    GlobalSettings.RememberUsernameAndPassword(txtUserName.Text, txtPassword.Text);
                }
                else
                    GlobalSettings.RememberUsernameAndPassword("", "");


            }
            else
            {
                MessageBox.Show("Invalid UserName/Password.", "Wrong Credintials", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUserName.Focus();
                return;

            }

            if (!_User.IsActive)
            {
                txtUserName.Focus();
                MessageBox.Show("Your Account is not Active , contact Admin", "In Active Account", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            GlobalSettings.CurrenctUser= _User;

            this.Hide();
            MainForm frm = new MainForm(this);
            frm.ShowDialog();

        }


        
        private void frmLogin_Load(object sender, EventArgs e)
        {

            string UserName = "";
            string Password = "";
            if (GlobalSettings.GetStoredCredential(ref UserName, ref Password))
            {
                txtUserName.Text = UserName;
                txtPassword.Text = Password;
                chkRememberMe.Checked = true;


            }
            else
                chkRememberMe.Checked=false;

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
           
            CheckUserInfo();
              
        }

        private void chkRememberMe_CheckedChanged(object sender, EventArgs e)
        {
        }
    }
}
