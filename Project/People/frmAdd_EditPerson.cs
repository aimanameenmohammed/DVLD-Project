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
    public partial class frmAdd_EditPerson : Form
    {
        enum enMode { Addnew = 1, Update = 2 };
        enMode _Mode = enMode.Addnew;
        int _PersonID=-1;


        public delegate void DataBackEventHandler(int ID);
        public event DataBackEventHandler Refresh;

        enum enGender { Male=0,Female=1 };


        clsPerson _Person;

        public frmAdd_EditPerson()
        {
            InitializeComponent();     
        }

        public frmAdd_EditPerson(int PersonID)
        {
            InitializeComponent();

            _Mode = enMode.Update;
            _PersonID = PersonID;
        }


        void _ResetDefualtValues()
        {

            //this will initialize the reset the defaule values

            if (_Mode == enMode.Addnew)
            {
                lbTitle.Text = "Add New Person";
                this.Text = "Add New Person";
                _Person = new clsPerson();
            }
            else
            {
                lbTitle.Text = "Update Person";
                this.Text = "Update Person";
            }


            txtAddress.Text= string.Empty;
            txtFirstName.Text= string.Empty;
            txtLastName.Text= string.Empty;
            txtSecondName.Text= string.Empty;
            txtThirdName.Text= string.Empty;

            rbMake.Checked = true;

            pbShowSelectedPicture.Image = Resources.Male_512;

            cmCountries.DataSource = clsCountry.GetAllCountry();
            cmCountries.DisplayMember = "CountryName";
            cmCountries.ValueMember = "CountryID";


            cmCountries.SelectedIndex = cmCountries.FindString("Yemen");
            txtEmail.Text= string.Empty;
            txtPhoneNumber.Text= string.Empty;
            txtNationalNumber.Text= string.Empty;


            dtDateOfBirth.MaxDate = DateTime.Now.AddYears(-18);
            dtDateOfBirth.MinDate = DateTime.Now.AddYears(-100);

            lnkRemoveImage.Visible = (pbShowSelectedPicture.ImageLocation != null);

        }




        void LoadData()
        {



            _Person = clsPerson.Find(_PersonID);


            lbShowPersonID.Text = _PersonID.ToString();
            txtAddress.Text = _Person.Address;
            txtEmail.Text = _Person.Email;
            txtFirstName.Text = _Person.FirstName;
            txtLastName.Text = _Person.LastName;
            txtNationalNumber.Text = _Person.NationalNo;
            txtPhoneNumber.Text = _Person.Phone;
            txtSecondName.Text = _Person.SecondName;
            txtThirdName.Text = _Person.ThirdName;
            dtDateOfBirth.Value = _Person.DateOfBirth;


            if (_Person.Gender == (short)enGender.Male)
                rbMake.Checked = true;
            else
                rbFemale.Checked = true;


            if (rbFemale.Checked)
                pbShowSelectedPicture.Image = Resources.Female_512;
            else
                pbShowSelectedPicture.Image = Resources.Male_512;

            if(_Person.ImagePath!="")
            pbShowSelectedPicture.ImageLocation = _Person.ImagePath;

            lnkRemoveImage.Visible =(pbShowSelectedPicture.ImageLocation != null);

            cmCountries.SelectedIndex = cmCountries.FindString(_Person.countryInfo.countryName);

        }


      
        bool _HandlePersonImage()
        {

            if (_Person.ImagePath != pbShowSelectedPicture.ImageLocation)
            {

                if (_Person.ImagePath != "")
                {
                    clsUtil.DeletePersonImage(_Person.ImagePath);
                }

                if (pbShowSelectedPicture.ImageLocation != null)
                {
                    string SourceFile = pbShowSelectedPicture.ImageLocation;
                    if (clsUtil.CopyImageToProjectImagesFolder(ref SourceFile))
                    {
                        pbShowSelectedPicture.ImageLocation = SourceFile;
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Error Copying Image File", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }


                }




            }
            return true;
        }



        void Save()
        {
           

            if(!this.ValidateChildren())
            {

                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }


            if (!_HandlePersonImage())
                return;


           _Person.Address= txtAddress.Text;
            _Person.Email=txtEmail.Text;
             _Person.FirstName=txtFirstName.Text;
           _Person.LastName= txtLastName.Text;
           _Person.NationalNo= txtNationalNumber.Text;
            _Person.Phone= txtPhoneNumber.Text;
            _Person.SecondName= txtSecondName.Text;
            _Person.ThirdName= txtThirdName.Text ;

            if (rbMake.Checked)
                _Person.Gender = (short)enGender.Male;
            else
                _Person.Gender = (short)enGender.Female;

            _Person.NationalityCountryID = (int)cmCountries.SelectedValue;
            _Person.DateOfBirth = dtDateOfBirth.Value;


            if (pbShowSelectedPicture.ImageLocation != null)
                _Person.ImagePath = pbShowSelectedPicture.ImageLocation;
            else
                _Person.ImagePath = "";


            if (_Person.Save())
            {

                _Mode = enMode.Update;

                Refresh?.Invoke(_Person.PersonID);

                lbTitle.Text = "Update Person ";
                lbShowPersonID.Text = _Person.PersonID.ToString();

                MessageBox.Show("Data saved successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Faild Save Data", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }


        private void guna2TextBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void Add_Edit_Person_Info_Load(object sender, EventArgs e)
        {
            _ResetDefualtValues();

           if(_Mode==enMode.Update)
            LoadData();              
        }

       

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lnkSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pbShowSelectedPicture.ImageLocation=openFileDialog1.FileName;
                lnkRemoveImage.Visible = true;

            }
        }

        private void ChangePictureMaleOrFemale(object sender, EventArgs e)
        {

            if (pbShowSelectedPicture.ImageLocation == null)
            {
                if (rbFemale.Checked)
                    pbShowSelectedPicture.Image = Resources.Female_512;
                else
                    pbShowSelectedPicture.Image = Resources.Male_512;
            }

        }

        private void txtNationalNumber_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrEmpty(txtNationalNumber.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtNationalNumber, "This Field is required.");
                return;
            }

         

            if(_Person.NationalNo!=txtNationalNumber.Text.Trim() && clsPerson.ISPersonExists(txtNationalNumber.Text.Trim()))
            {


                e.Cancel = true;
                errorProvider1.SetError(txtNationalNumber, "National Number is used for another person!");

            }
            else
            {
                errorProvider1.SetError(txtNationalNumber, null);
            }

        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                return;
            }

            if (!clsValidation.ValidateEmail(txtEmail.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtEmail, "Invalid Email Address Format!");

            }
            else
                errorProvider1.SetError(txtEmail, null);
        }
   
        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtPhoneNumber_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtPhoneNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar);
        }


        private void ValidatingEmptyTxtBox(object sender, CancelEventArgs e)
        {
            Control txtBox = sender as Control;

            if (string.IsNullOrEmpty(txtBox.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtBox, "This Field is required!");
            }
            else
                errorProvider1.SetError(txtBox, null);


        }

       

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void lnkRemoveImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pbShowSelectedPicture.ImageLocation = null;
            lnkRemoveImage.Visible = false;

            if (rbFemale.Checked)
                pbShowSelectedPicture.Image = Resources.Female_512;
            else
                pbShowSelectedPicture.Image = Resources.Male_512;


        }

     
    }
}
