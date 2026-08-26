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
    public partial class frmShowPersonLicenseHistory : Form
    {

        int _PersonID;
        public frmShowPersonLicenseHistory(int PersonID)
        {
            InitializeComponent();
            _PersonID = PersonID;
        }

        private void frmShowPersonLicenseHistory_Load(object sender, EventArgs e)
        {       

            ctrlPersonCard1.LoadPersonInfo(_PersonID);

            if(ctrlPersonCard1.PersonID!=-1)
            ctrlDriverLicense1.LoadPersonLicenseInfo(_PersonID);     
            
        }

        private void ctrlDriverLicense1_Load(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
