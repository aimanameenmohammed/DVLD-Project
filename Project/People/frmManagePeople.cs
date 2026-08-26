using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLDDataBusinessLayer;
using System.Windows.Forms;

namespace FullRealLifeProject19
{
    public partial class frmManagePeople : Form
    {
        public frmManagePeople()
        {
            InitializeComponent();
        }
        Form frm;

       private static  DataTable _dtAllPeople=clsPerson.GetAllPeopleData();

        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {

        } 

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Manage_People_FormClosing(object sender, FormClosingEventArgs e)
        {
           
        }

        private  DataTable _dtPeople= _dtAllPeople.DefaultView.ToTable(false, "PersonID", "NationalNo",
                                                        "FirstName", "SecondName", "ThirdName", "LastName",
                                                        "GendorCaption", "DateOfBirth", "CountryName",
                                                        "Phone", "Email");



        void RefreshPeopleData()
        {
            _dtAllPeople = clsPerson.GetAllPeopleData();

            _dtPeople = _dtAllPeople.DefaultView.ToTable(false, "PersonID", "NationalNo",
                                            "FirstName", "SecondName", "ThirdName", "LastName",
                                            "GendorCaption", "DateOfBirth", "CountryName",
                                            "Phone", "Email");


            dgvShowPeopleList.DataSource = _dtPeople;
            lbNumberOfPeople.Text = _dtAllPeople.Rows.Count.ToString();

        }

        private void Manage_People_Load(object sender, EventArgs e)
        {
           

            dgvShowPeopleList.DataSource = _dtPeople;
            lbNumberOfPeople.Text = _dtAllPeople.Rows.Count.ToString();

        }
        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm = new frmShowPersonDetails(Convert.ToInt32(dgvShowPeopleList.CurrentRow.Cells[0].Value));
            frm.ShowDialog();
            RefreshPeopleData();

        }

        private void addNewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm = new frmAdd_EditPerson();
            frm.ShowDialog();
            RefreshPeopleData();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm = new frmAdd_EditPerson(Convert.ToInt32(dgvShowPeopleList.CurrentRow.Cells[0].Value));
            frm.ShowDialog();
            RefreshPeopleData();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {

            int PersonID = Convert.ToInt32(dgvShowPeopleList.CurrentRow.Cells[0].Value);

            if (MessageBox.Show("Are you sure ,you want to delete this Person [" + PersonID + "]", "Comfirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {

                string ImagePath = _dtAllPeople.AsEnumerable().FirstOrDefault(r => r.Field<int>("PersonID") == PersonID)?.Field<string>("ImagePath");

                if (clsPerson.DeletePerson(PersonID))
                {

                    MessageBox.Show("Person Deleted successfully.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clsUtil.DeletePersonImage(ImagePath);
                    RefreshPeopleData();

                }
                else
                    MessageBox.Show("Person was not deleted ,because it has data linked to it.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }
            

        }

      
        void Filtering()
        {

            string FilteringName="";


            switch (cmSelectTypeOfFiltering.Text)
            {

                case "Person ID":
                    FilteringName = "PersonID"; break;

                case "First Name":
                    FilteringName = "FirstName"; break;

                case "Second Name":
                    FilteringName = "SecondName"; break;

                case "Last Name":
                    FilteringName = "LastName"; break;

                case "Nationality":
                    FilteringName = "CountryName"; break;

                case "National No.":
                    FilteringName = "NationalNo"; break;

                case "Phone":
                    FilteringName = "Phone"; break;

                case "Email":
                    FilteringName = "Email"; break;

                case "Gender":
                    FilteringName = "GendorCaption"; break;


            }

            if (txtFiltering.Text == "")
            {
                _dtPeople.DefaultView.RowFilter = "";
                lbNumberOfPeople.Text = _dtPeople.Rows.Count.ToString();
                return;
            }
            

            

            if (FilteringName == "PersonID")
                _dtPeople.DefaultView.RowFilter = $"{FilteringName} = '{txtFiltering.Text}'";

            else
                _dtPeople.DefaultView.RowFilter = $"{FilteringName} like '{txtFiltering.Text}%'";


            lbNumberOfPeople.Text = dgvShowPeopleList.Rows.Count.ToString();

        }

        private void cmSelectTypeOfFiltering_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFiltering.Visible = (cmSelectTypeOfFiltering.Text != "None");

            if (txtFiltering.Visible)
                txtFiltering.Focus();
            else
                _dtAllPeople.DefaultView.RowFilter = "";

            lbNumberOfPeople.Text = _dtAllPeople.Rows.Count.ToString();

        }

        private void txtFiltering_TextChanged(object sender, EventArgs e)
        {

            Filtering();
           
        }

       
        private void cmSelectTypeOfFiltering_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void txtSearchingOnSelectedColumn_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cmSelectTypeOfFiltering.Text == "Person ID")
            {
                e.Handled = !char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar);
            }
        }

        private void btnAddNewPerson_Click_1(object sender, EventArgs e)
        {
            frm = new frmAdd_EditPerson();
            frm.ShowDialog();
            RefreshPeopleData();


        }
    }
}
