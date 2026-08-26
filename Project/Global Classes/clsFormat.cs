using DVLDDataBusinessLayer;
using FullRealLifeProject19.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DVLDDataBusinessLayer.clsApplication;
using static DVLDDataBusinessLayer.clsTestTypes;

namespace FullRealLifeProject19
{
    public class clsFormat
    {



        public static void HandleEmageAndTileTestType(clsTestTypes.enTestType TestType, Control TestTypeTitle, PictureBox pbTestTypeImage)
        {

            switch (TestType)
            {

                case clsTestTypes.enTestType.VisionTest:
                    TestTypeTitle.Text = "Vision Test";
                    pbTestTypeImage.Image = Resources.Vision_512;
                    break;

                case clsTestTypes.enTestType.WrittenTest:
                    TestTypeTitle.Text = "Written Test";
                    pbTestTypeImage.Image = Resources.Written_Test_512;
                    break;

                default:
                    TestTypeTitle.Text = "Street Test";
                    pbTestTypeImage.Image = Resources.driving_test_512;
                    break;

            }
        }
    }
}


        





       
