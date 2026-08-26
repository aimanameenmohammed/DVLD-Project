using DVLDDataBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FullRealLifeProject19
{
    public partial class ctrlApplicationBasicInfo : UserControl
    {
        public ctrlApplicationBasicInfo()
        {
            InitializeComponent();
        }
        clsApplication _Application;
        private void guna2GroupBox1_Click(object sender, EventArgs e)
        {

        }



        public clsApplication SelectedApplicationInfo
        {
            get
            {
                return _Application;
            }
        }

       
        public void _ResetBaseApplicationInfo()
        {

            lblApplicant.Text = "[????]";
            lblApplicationID.Text = "[???]";
            lblCreatedByUser.Text = "[???]";
            lblDate.Text = "[??/??/????]";
            lblStatusDate.Text = "[??/??/????]";
            lblFees.Text = "[$$$]";
            lblType.Text = "[???]";
            llViewPersonInfo.Enabled = true;
            lblStatus.Text = "[???]";
        }


        public void LoadBaseApplicationInfo(int ApplicationID)
        {
            _Application=clsApplication.FindBaseApplication(ApplicationID);

            if (_Application == null)
            {
                _ResetBaseApplicationInfo();
                MessageBox.Show("No Application with Application ID = " + ApplicationID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            _FillValues();

        }




        void _FillValues()
        {

            lblApplicant.Text =_Application.ApplicantFullName;
            lblType.Text = _Application.ApplicationTypeInfo.ApplicationTitle;
            lblApplicationID.Text = _Application.ApplicationID.ToString();
            lblCreatedByUser.Text = _Application.UserInfo.UserName;
            lblDate.Text=_Application.ApplicationDate.ToShortDateString();
            lblStatusDate.Text=_Application.LastStatusDate.ToShortDateString();
            lblFees.Text = _Application.PaidFees.ToString();
            lblStatus.Text = _Application.StatusText;

        }

        private void ctrlApplicationBasicInfo_Load(object sender, EventArgs e)
        {

        }

        private void llViewPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowPersonDetails frm = new frmShowPersonDetails(_Application.ApplicantPersonID);
            frm.ShowDialog();
            lblApplicant.Text = _Application.ApplicantFullName;


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
