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
    public partial class ctrlUserCard : UserControl
    {
        public ctrlUserCard()
        {
            InitializeComponent();
        }

        clsUser _User;

        void _FillUserData()
        {

            ctrlPersonCard1.LoadPersonInfo(_User.PersonID);
            lbIsActive.Text = _User.IsActive.ToString();
            lbUserName.Text = _User.UserName;
            lbUserID.Text = _User.UserID.ToString();

        }
        void _SetDefaultValues()
        {
            lbUserID.Text = "???";
            lbUserName.Text = "???";
            lbIsActive.Text = "???";
            ctrlPersonCard1.ResetPersonInfo();

        }

        public  void LoadUserInfo(int UserID)
        {
            _User=clsUser.FindByUserID(UserID);

            if( _User == null )
            {
                _SetDefaultValues();
                MessageBox.Show("No User with User ID = " + UserID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            _FillUserData();

        }


        private void ctrlPersonCard1_Load(object sender, EventArgs e)
        {

        }
    }
}
