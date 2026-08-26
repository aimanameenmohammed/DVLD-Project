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
    public partial class frmLocalDrivingLicenseApplicationInfo : Form
    {
        int _LDLApplicationID;
        public frmLocalDrivingLicenseApplicationInfo(int LocalDrivingLicenseApplicationID)

        {
            InitializeComponent();
            _LDLApplicationID= LocalDrivingLicenseApplicationID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmLocalDrivingLicenseApplicationInfo_Load(object sender, EventArgs e)
        {
            ctrlDrivingLicenseApplicationInfo1.LoadApplicationInfoByLocalDrivingLicenseAppID(_LDLApplicationID);
        }

        private void ctrlDrivingLicenseApplicationInfo1_Load(object sender, EventArgs e)
        {

        }
    }
}
