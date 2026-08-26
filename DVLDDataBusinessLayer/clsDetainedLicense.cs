using DVLDDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DVLDDataBusinessLayer
{
    public class clsDetainedLicense
    {


        enum enMode { Addnew = 1, Update = 2 };
        enMode _Mode;



      public int DetainID   {set;get;}
      public int LicenseID      {set;get;}
      public DateTime DetainDate {set;get;}
      public float FineFees   {set;get;}
      public bool IsReleased   {set;get;}
      public DateTime ReleaseDate  {set;get;}
      public int CreatedByUserID  {set;get;}
      public int ReleasedByUserID {set;get;}
      public int ReleaseApplicationID { set; get; }

        public clsUser ReleasedByUserInfo { set; get; }
        public clsUser CreatedByUserInfo { set; get; }

        public clsDetainedLicense()
        {

            this.DetainID = -1;
            this.LicenseID = -1;
            this.DetainDate = DateTime.Now;
            this.FineFees = 0;
            this.IsReleased = false;
            this.ReleaseDate = DateTime.Now;
            this.CreatedByUserID = -1;
            this.ReleasedByUserID = -1;
            this.ReleaseApplicationID = -1;

            _Mode = enMode.Addnew;

        }

        clsDetainedLicense(int DetainID, int LicenseID, DateTime DetainDate
            , float FineFees, bool IsReleased, DateTime ReleaseDate,
            int CreatedByUserID, int ReleasedByUserID, int ReleaseApplicationID)
        {


            this.DetainID = DetainID;
            this.LicenseID = LicenseID;
            this.DetainDate = DetainDate;
            this.FineFees = FineFees;
            this.IsReleased = IsReleased;
            this.ReleaseDate = ReleaseDate;
            this.CreatedByUserID = CreatedByUserID;
            this.ReleasedByUserID = ReleasedByUserID;
            this.ReleaseApplicationID = ReleaseApplicationID;

            this.CreatedByUserInfo = clsUser.FindByUserID(this.CreatedByUserID);
            this.ReleasedByUserInfo = clsUser.FindByPersonID(this.ReleasedByUserID);
            _Mode = enMode.Update;

        }

        public bool IsEmpty()
        {
            return (this.DetainID == -1);
        }
      private bool _Addnew()
        {
            this.DetainID = clsAccessDetainedLicenses.AddNewDetainLicense(this.LicenseID, this.FineFees, this.CreatedByUserID);
            return (this.DetainID != -1);
        }


        private bool _Update()
        {
            return clsAccessDetainedLicenses.UpdateDetainLicense(this.DetainID,this.LicenseID, this.DetainDate, this.FineFees, this.IsReleased,
                this.ReleaseDate, this.CreatedByUserID, this.ReleasedByUserID, this.ReleaseApplicationID);
        }

        public bool Save()
        {

            switch (_Mode)
            {

                case enMode.Addnew:
                    {
                        if (_Addnew())
                        {
                            _Mode = enMode.Update;
                            return true;
                        }
                        else
                            return false;
                    }

                case enMode.Update:
                    return _Update();

            }
            return false;
        }





        public static clsDetainedLicense FindDetainedLicenseByID(int LicenseID)
        {      

            int DetainedID = -1;
            DateTime DetainDate=DateTime.Now;
            float FineFees=0;
            bool IsReleased=false;
            DateTime ReleaseDate=DateTime.Now;
            int CreatedByUserID=-1;
            int ReleasedByUserID=-1;
            int ReleaseApplicationID = -1;


            if (clsAccessDetainedLicenses.FindDetainLicenseByDetainID(ref DetainedID, LicenseID,ref DetainDate,ref FineFees,
                ref IsReleased,ref ReleaseDate,ref CreatedByUserID,ref ReleasedByUserID,ref ReleaseApplicationID))
                return new clsDetainedLicense(DetainedID,LicenseID,DetainDate,
                    FineFees,IsReleased,ReleaseDate,CreatedByUserID,ReleasedByUserID,ReleaseApplicationID);
            else
                return null;


        }


        public bool ReleaseDetainedLicense(int ReleaseApplicationID,int ReleasedByUserID)
        {

            return clsAccessDetainedLicenses.ReleaseDetainedLicense(this.DetainID, ReleaseApplicationID, ReleasedByUserID);

        }


        public static bool IsLicenseDetained(int LicenseID)
        {
            return clsAccessDetainedLicenses.IsLicenseDetained(LicenseID);
        }

        public static DataTable GetAllDetainedLicense()
        {
            return clsAccessDetainedLicenses.GetAllDetainedLicense();
        }
    }
}
