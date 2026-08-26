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
    public partial class frmShowInternationalLicenseInfo : Form
    {
        int _InternationalLicenseID;
        public frmShowInternationalLicenseInfo(int internationalLicenseID)
        {
            InitializeComponent();
            _InternationalLicenseID = internationalLicenseID;
        }

        private void frmShowInternationalLicenseInfo_Load(object sender, EventArgs e)
        {
            ctrlInternationalDriverInfo1.LoadInternationalLicenseInfo(_InternationalLicenseID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
