using DVLDDataAccessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace DVLDDataBusinessLayer
{
    public class clsLicense
    {

        enum enMode { Addnew = 1, Update = 2 };
        enMode _Mode;

       public enum enIssueReason {FirstTime=1, Renew=2, ReplacementForLost=3,ReplacementForDamaged=4}
        public int LicenseID { get; set; }
        public int DriverID { get; set; }
        public int ApplicationID { get; set; }
        public int LicenseClassID { get; set; }
        public int CreatedByUserID { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate  { get; set; }
        public string Notes     { get; set; }
        public float PaidFees { get; set; }
        public bool IsActive { get; set; }
        public enIssueReason IssueReason { get; set; }


        private clsDetainedLicense _DetainedLicenseInfo;
        public clsLicenseClasses LicenseClassesInfo;
        public clsDriver DriverInfo;

        public clsDetainedLicense DetainedLicenseInfo
        {
            get
            {
                if (_DetainedLicenseInfo.IsEmpty())
                    _DetainedLicenseInfo = clsDetainedLicense.FindDetainedLicenseByID(this.LicenseID);


                return _DetainedLicenseInfo;
            }
        }

        public bool IsDetained
        {
            get
            {
               return  clsDetainedLicense.IsLicenseDetained(this.LicenseID);
            }
        }



        public string IssueReasonText
        {
            get
            {
                return _GetIssueReasonTest();
            }
        }

        public clsLicense()
        {

            this.LicenseClassID = -1;
            this.LicenseID = -1;
            this.DriverID = -1;
            this.ApplicationID = -1;
            this.CreatedByUserID = -1;
            this.IssueDate = DateTime.Now;
            this.ExpirationDate = DateTime.Now;
            this.Notes = "";
            this.PaidFees = 0;
            this.IsActive = false;
            this.IssueReason = enIssueReason.FirstTime;

            _Mode = enMode.Addnew;
        }







        bool _Addnew()
        {
            this.LicenseID = clsAccessLicense.AddNewLicese(this.DriverID,this.ApplicationID,this.LicenseClassID,this.CreatedByUserID,this.ExpirationDate,this.IssueDate,this.IsActive,this.PaidFees,(byte)this.IssueReason,this.Notes);
            return (this.LicenseID != -1);
        }
        clsLicense(int LicenseID, int ApplicationID, int DriverID, int CreatedUserID, int LicenseClassID, DateTime IssueDate,
            DateTime ExpirationDate, float PaidFees, bool IsActive,enIssueReason IssueReason,string Notes)
        {

            this.CreatedByUserID= CreatedUserID;
            this.LicenseClassID = LicenseClassID;
            this.LicenseID = LicenseID;
            this.ApplicationID=ApplicationID;
            this.DriverID= DriverID;
            this.IssueDate= IssueDate;
            this.ExpirationDate=ExpirationDate;
            this.IsActive=IsActive;
            this.PaidFees= PaidFees;
            this.IssueReason= IssueReason;
            this.Notes= Notes;


            this._DetainedLicenseInfo = new clsDetainedLicense();
            this.LicenseClassesInfo = clsLicenseClasses.Find(LicenseClassID);
            this.DriverInfo = clsDriver.FindByID(DriverID);

            _Mode = enMode.Update;

        }


       private string _GetIssueReasonTest()
        {

            switch (IssueReason)
            {

                case clsLicense.enIssueReason.FirstTime:
                    return "FirstTime";
                case clsLicense.enIssueReason.ReplacementForDamaged:
                    return "Replacement For Damaged";
                case clsLicense.enIssueReason.ReplacementForLost:
                    return "Replacement For Lost";
                default:
                    return "Renew";
            }

        }



        bool _Update()
        {
            return clsAccessLicense.UpdateLicense(this.LicenseID,this.DriverID, this.ApplicationID, this.LicenseClassID, this.CreatedByUserID, this.ExpirationDate, this.IssueDate, this.IsActive, this.PaidFees,(byte) this.IssueReason, this.Notes);
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




        public static clsLicense FindLicenseByLicenseID(int LicenseID)
        {
            int LicenseClassID = -1;
            int DriverID = -1;
            int ApplicationID = -1;
            int CreatedByUserID = -1;
            DateTime IssueDate = DateTime.Now;
             DateTime ExpirationDate = DateTime.Now;
            string Notes = "";
           float PaidFees = 0;
            bool IsActive = false;
            byte IssueReason = 0;


            if (clsAccessLicense.FindLicenseByLiceseID(LicenseID, ref DriverID, ref ApplicationID,
                ref LicenseClassID, ref CreatedByUserID, ref ExpirationDate, ref IssueDate, ref IsActive, ref PaidFees, ref IssueReason, ref Notes))
                return new clsLicense(LicenseID, ApplicationID, DriverID, CreatedByUserID, LicenseClassID, 
                    IssueDate, ExpirationDate, PaidFees, IsActive,(enIssueReason)IssueReason, Notes);

            else
                return null;

        }
        //public static clsLicense FindByApplicationID(int ApplicationID)
        //{
        //    int LicenseClassID = -1;
        //    int DriverID = -1;
        //    int LicenseID= -1;
        //    int CreatedByUserID = -1;
        //    DateTime IssueDate = DateTime.Now;
        //     DateTime ExpirationDate = DateTime.Now;
        //    string Notes = "";
        //   float PaidFees = 0;
        //    bool IsActive = false;
        //    byte IssueReason = 0;


        //    if (clsAccessLicense.FindLicenseByApplicationID(ref LicenseID, ref DriverID,  ApplicationID,
        //        ref LicenseClassID, ref CreatedByUserID, ref ExpirationDate, ref IssueDate, ref IsActive, ref PaidFees, ref IssueReason, ref Notes))
        //        return new clsLicense(LicenseID, ApplicationID, DriverID, CreatedByUserID, LicenseClassID, 
        //            IssueDate, ExpirationDate, PaidFees, IsActive, (enIssueReason)IssueReason, Notes);

        //    else
        //        return null;

        //}


        private bool DeActivateCurrentLicense()
        {
            return (clsAccessLicense.DeActivateLicense(this.LicenseID));
        }

        public clsLicense RenewLicense(string Notes ,int CreatedByUserID)
        {


            clsApplication Application = new clsApplication();

            Application.ApplicationStatus = clsApplication.enApplicationStatus.Completed;
            Application.ApplicationDate = DateTime.Now;
            Application.LastStatusDate = DateTime.Now;
            Application.ApplicantPersonID = this.DriverInfo.PersonID;
            Application.ApplicationTypeID = (int)clsApplication.enApplicationType.RenewDrivingLicense;
            Application.CreatedByUserID = CreatedByUserID;
            Application.PaidFees = clsApplicationTypes.Find((int)clsApplication.enApplicationType.RenewDrivingLicense).ApplicationFees;


            if(!Application.Save())
            {
                return null;
            }


            clsLicense License=new clsLicense();

            License.Notes = Notes;
            License.ApplicationID = Application.ApplicationID;
            License.DriverID = this.DriverID;
            License.CreatedByUserID= CreatedByUserID;
            License.ExpirationDate = DateTime.Now.AddYears(this.LicenseClassesInfo.DefaultValidityLength);
            License.IssueDate = DateTime.Now;
            License.IssueReason = clsLicense.enIssueReason.Renew;
            License.IsActive = true;
            License.PaidFees = this.LicenseClassesInfo.ClassFees;
            License.LicenseClassID = this.LicenseClassesInfo.LicenseClassID;


            if(!License.Save())
            {

                return null;

            }


            DeActivateCurrentLicense();

            return License;
        }


        public clsLicense Replace(int CreatedByUserID,clsLicense.enIssueReason IssueReason)
        {


            clsApplication Application = new clsApplication();

            Application.ApplicationStatus = clsApplication.enApplicationStatus.Completed;
            Application.ApplicationDate = DateTime.Now;
            Application.LastStatusDate = DateTime.Now;
            Application.ApplicantPersonID = this.DriverInfo.PersonID;

            Application.ApplicationTypeID = (IssueReason == clsLicense.enIssueReason.ReplacementForDamaged) ? 
                (int)clsApplication.enApplicationType.ReplacementForADamagedDriving 
                : (int)clsApplication.enApplicationType.ReplacementForALostDriving;

            Application.CreatedByUserID = CreatedByUserID;
            Application.PaidFees = clsApplicationTypes.Find(Application.ApplicationTypeID).ApplicationFees;


            if (!Application.Save())
            {
                return null;
            }


            clsLicense License = new clsLicense();

            License.Notes = Notes;
            License.ApplicationID = Application.ApplicationID;
            License.DriverID = this.DriverID;
            License.CreatedByUserID = CreatedByUserID;
            License.ExpirationDate = DateTime.Now.AddYears(this.LicenseClassesInfo.DefaultValidityLength);
            License.IssueDate = DateTime.Now;
            License.IssueReason = IssueReason;
            License.IsActive = true;
            License.PaidFees = 0;
            License.LicenseClassID = this.LicenseClassesInfo.LicenseClassID;


            if (!License.Save())
            {

                return null;

            }


            DeActivateCurrentLicense();

            return License;
        }


        public int Detain(float FineFees,int CreatedByUserID)
        {

            clsDetainedLicense DetainLicense = new clsDetainedLicense();

            DetainLicense.FineFees = FineFees;
            DetainLicense.CreatedByUserID= CreatedByUserID;
            DetainLicense.LicenseID=this.LicenseID;

            if(!DetainLicense.Save())
            {
                return -1;
            }

            return DetainLicense.DetainID;

        }

        public bool ReleaseDetainedLicense(int ReleasedByUserID,ref int ApplicationID)
        {




            clsApplication Application = new clsApplication();

            Application.ApplicationStatus = clsApplication.enApplicationStatus.Completed;
            Application.ApplicationDate = DateTime.Now;
            Application.LastStatusDate = DateTime.Now;
            Application.ApplicantPersonID = this.DriverInfo.PersonID;
            Application.ApplicationTypeID = (int)clsApplication.enApplicationType.ReleaseDetainedDriving;
            Application.CreatedByUserID = ReleasedByUserID;
            Application.PaidFees = clsApplicationTypes.Find((int)clsApplication.enApplicationType.ReleaseDetainedDriving).ApplicationFees;


            if (!Application.Save())
            {
                ApplicationID = -1;
                return false;
            }


            ApplicationID = Application.ApplicationID;

            return this._DetainedLicenseInfo.ReleaseDetainedLicense(Application.ApplicationID, ReleasedByUserID);

        }



        public Boolean IsLicenseExpired()
        {
            return (this.ExpirationDate<DateTime.Now);
        }

     
        public static bool Delete(int LicenseID)
        {
            return clsAccessLicense.DeleteLicenseByID(LicenseID);
        }


        public static DataTable GetAllLocalLicenseInfoByPersonID(int personID)
        {
            return clsAccessLicense.GetAllLocalLicenseInfoByPersonID(personID);
        }


        public static int GetLicenseIDByLocalDLApplicationID(int LocalDLApplicationID)
        {
            return clsAccessLicense.GetLicenseIDByLocalDLApplicationID(LocalDLApplicationID);
        }
        public static bool IsLicenseExistByPersonID(int PersonID, int LicenseClassID)
        {
            return (GetActiveLicenseIDByPersonID(PersonID, LicenseClassID) != -1);
        }



        public static int GetActiveLicenseIDByPersonID(int PersonID,int LicenseClassID)
        {
            return clsAccessLicense.GetActiveLicenseIDByPersonID(PersonID, LicenseClassID);
        }
       
        public static int GetPersonIDByLicenseID(int licenseID)
        {
            return clsAccessLicense.GetPersonIDByLicenseID(licenseID);
        }
    }
}
