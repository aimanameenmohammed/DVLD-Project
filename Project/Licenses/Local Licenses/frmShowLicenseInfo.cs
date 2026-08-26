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
    public partial class frmShowLicenseInfo : Form
    {
        int _LicenseID;
        public frmShowLicenseInfo(int  LicenseID )
        {
            InitializeComponent();
            _LicenseID = LicenseID;
        }

        private void frmShowLicenseInfo_Load(object sender, EventArgs e)
        {
            ctrlDrivingLicenseInfo1.LoadDriverLicenseInfoByLicenseID(_LicenseID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
