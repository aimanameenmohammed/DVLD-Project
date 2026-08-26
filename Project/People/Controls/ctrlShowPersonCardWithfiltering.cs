using DVLDDataBusinessLayer;
using System;
using System.Web.UI.HtmlControls;
using System.Windows.Forms;

namespace FullRealLifeProject19
{
    public partial class ctrlShowPersonCardWithfiltering : UserControl
    {
        public ctrlShowPersonCardWithfiltering()
        {
            InitializeComponent();
        }

        public event Action<int> OnPersonSelected;

        public  virtual void PersonSelected(int PersonID)
        {


            OnPersonSelected?.Invoke(PersonID);


        }

        public int PersonID
        {
            get
            {
                return ctrlPersonCard1.PersonID;
            }
        }


        private bool _FilterEnabled = true;

        public bool EnableFilter
        {
            get
            {
                return _FilterEnabled;
            }
            set
            {
                _FilterEnabled = value;
                grbFilter.Enabled = _FilterEnabled;
            }

        }
    public clsPerson SelectedPersonInfo
        {
            get
            {

                return ctrlPersonCard1.SelectedPersonInfo;

            }
        }
        public void FilterFocus()
        {
            txtFilterValue.Focus();
        }


        private void txtFiltering_KeyPress(object sender, KeyPressEventArgs e)
        {

            if(e.KeyChar ==(char)13)
            {

                btnSearch.PerformClick();
            }


            if(cmFilterType.Text=="Person ID")
            e.Handled=(!char.IsNumber(e.KeyChar)&&!char.IsControl(e.KeyChar));
        }

        private void txtFiltering_TextChanged(object sender, EventArgs e)
        {
            if (txtFilterValue.Text == "")
                ctrlPersonCard1.ResetPersonInfo();


        }


     
        public void LoadPersonInfo(int PersonID)
        {
            cmFilterType.SelectedIndex = 1;
            txtFilterValue.Text = PersonID.ToString();
            _Searching();
        }

       
        void _Searching()
        {


            switch (cmFilterType.Text)
            {

                case "National No.":
                    ctrlPersonCard1.LoadPersonInfo(txtFilterValue.Text.Trim());
                    break;

                case "Person ID":
                    ctrlPersonCard1.LoadPersonInfo(Convert.ToInt32(txtFilterValue.Text.Trim()));
                    break;
                    default: break;
            }


            PersonSelected(ctrlPersonCard1.PersonID);



        }

       
        private void btnSearch_Click(object sender, EventArgs e)
        {

            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }


            _Searching();
        }

      

        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            frmAdd_EditPerson frm=new frmAdd_EditPerson();
            frm.Refresh += LoadPersonInfo;
            frm.ShowDialog();
        }

        private void grbFilter_Click(object sender, EventArgs e)
        {

        }

        private void ctrlPersonCard1_Load(object sender, EventArgs e)
        {

        }

        private void cmSearchType_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterValue.Text = "";
            txtFilterValue.Focus();
        }

        private void ctrlShowPersonCardWithfiltering_Load(object sender, EventArgs e)
        {
            txtFilterValue.Focus();
            cmFilterType.SelectedIndex = 0;
        }

        private void txtFilterValue_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtFilterValue.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFilterValue, "This field is required!");
            }
            else
            {
                //e.Cancel = false;
                errorProvider1.SetError(txtFilterValue, null);
            }
        }
    }
}
