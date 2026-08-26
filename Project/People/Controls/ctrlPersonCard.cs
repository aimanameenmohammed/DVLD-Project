using DVLDDataBusinessLayer;
using FullRealLifeProject19.Properties;
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

namespace FullRealLifeProject19
{
    public partial class ctrlPersonCard : UserControl
    {
        public ctrlPersonCard()
        {
            InitializeComponent();
        }

        enum enGender { Male = 0, Female = 1 };


        int _PersonID=-1;
        clsPerson _Person;


        public int PersonID
        {
            get
            {
                return _PersonID;
            }
        }

        public clsPerson SelectedPersonInfo
        {
            get { return _Person; }
        }


        public  void ResetPersonInfo()
        {
            _PersonID = -1;
            lnkEditPersonInfo.Enabled = false;
            pbShowPersonPicture.Image = Resources.Male_512;
            lbShowPersonAddress.Text="[????]";
            lbShowPersonCountry.Text="[????]";
            lbShowPersonDateOfBirth.Text="[????]";
            lbShowPersonEmail.Text="[????]";
            lbShowPersonGender.Text="[????]";
            lbShowPersonID.Text="[????]";
            lbShowPersonName.Text = "[????]";
            lbShowPersonNationalNo.Text = "[????]";
            lbShowPersonPhone.Text = "[????]";

        }
       
        void _LoadPersonImage()
        {
            if (_Person.Gender == (short)enGender.Male)
                pbShowPersonPicture.Image = Resources.Male_512;
            else
                pbShowPersonPicture.Image = Resources.Female_512;

            string Imagepath = _Person.ImagePath;
            if (Imagepath != "")
            {
                if (File.Exists(Imagepath))
                    pbShowPersonPicture.ImageLocation = Imagepath;
                else
                    MessageBox.Show("Could not find this image: = " + Imagepath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        void _FillPersonInfo()
        {
            _PersonID = _Person.PersonID;
            lnkEditPersonInfo.Enabled = true;   
            lbShowPersonAddress.Text = _Person.Address;
            lbShowPersonCountry.Text = _Person.countryInfo.countryName;
            lbShowPersonDateOfBirth.Text = _Person.DateOfBirth.ToShortDateString();
            lbShowPersonEmail.Text = _Person.Email;
            lbShowPersonGender.Text = _Person.Gender == (byte)enGender.Male ? "Male" : "Female";         
            lbShowPersonName.Text = _Person.FullName;
            lbShowPersonNationalNo.Text = _Person.NationalNo;
            lbShowPersonPhone.Text = _Person.Phone;
            lbShowPersonID.Text = _Person.PersonID.ToString();

            _LoadPersonImage();

        }


        public void LoadPersonInfo(int PersonID)
        {
            _Person = clsPerson.Find(PersonID);
            if (_Person == null )
            {
                ResetPersonInfo();
                MessageBox.Show("No Person with Person ID = " + PersonID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;


            }

            _FillPersonInfo();
        }
        public void LoadPersonInfo(string NationalNo)
        {
            _Person = clsPerson.Find(NationalNo);
            if (_Person == null)
            {

                ResetPersonInfo();
                MessageBox.Show("No Person with National No. = " + NationalNo, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;


            }

            _FillPersonInfo();
        }

        private void guna2GroupBox1_Click(object sender, EventArgs e)
        {

        }
       
        private void ctrlPersonCard_Load(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void lnkEditPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAdd_EditPerson frm = new frmAdd_EditPerson(_PersonID);
            frm.ShowDialog();
            LoadPersonInfo(_PersonID);

        }
    }
}
