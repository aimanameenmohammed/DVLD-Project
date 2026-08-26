using DVLDDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DVLDDataBusinessLayer
{
    public class clsApplication
    {

       public enum enMode { Addnew = 1, Update = 2 };
      public  enMode _Mode;
        public enum enApplicationType
        {
            NewLocalDrivingLicense = 1, RenewDrivingLicense = 2, ReplacementForALostDriving = 3, ReplacementForADamagedDriving = 4, ReleaseDetainedDriving = 5
    , NewInternationalLicense = 6, RetakeTest = 7
        }

        public enum enApplicationStatus { New=1,Cancelled=2,Completed=3}

        public int ApplicationID { get; set; }
       public int ApplicantPersonID { get; set; }
        public string ApplicantFullName
        {
            get
            {
                return clsPerson.Find(ApplicantPersonID).FullName;
            }
        }

       public DateTime ApplicationDate { get; set; }
       public int ApplicationTypeID {  get; set; }


        private clsApplicationTypes _ApplicationTypeInfo;
        public clsApplicationTypes ApplicationTypeInfo
        {

            get
            {
                if(_ApplicationTypeInfo.IsEmpty())
                _ApplicationTypeInfo = clsApplicationTypes.Find(ApplicationTypeID);

                return _ApplicationTypeInfo;
            }


        }
       public enApplicationStatus ApplicationStatus {  get; set; }
       public float PaidFees {  get; set; }
       public DateTime LastStatusDate {  get; set; }
        public int CreatedByUserID {  get; set; }

        private clsUser _UserInfo;

        public clsUser UserInfo
        {
            get
            {
                if (_UserInfo.IsEmpty())
                    _UserInfo = clsUser.FindByUserID(CreatedByUserID);

                return _UserInfo;
            }
        }


        public string StatusText
        {
            get
            {
                switch (ApplicationStatus)
                {

                    case enApplicationStatus.New:
                        return "New";

                        case enApplicationStatus.Cancelled:
                        return "Cancelled";

                    case enApplicationStatus.Completed:
                        return "Completed";

                    default:
                        return "UnKnown";
                }
            }
        }

        public clsApplication()
        {


            this.ApplicationDate = DateTime.Now;
            this.ApplicationID = -1;
            this.ApplicantPersonID = -1;
            this.ApplicationTypeID = -1;
            this.CreatedByUserID = -1;
            this.ApplicationStatus = enApplicationStatus.New;
            this.LastStatusDate = DateTime.Now;
            this.PaidFees= 0;


            _Mode = enMode.Addnew;
        }


        bool _AddnewApplication()
        {
            this.ApplicationID = clsAccessApplication.AddNewApplication(this.ApplicantPersonID,this.ApplicationDate,(int)this.ApplicationTypeID,(byte)this.ApplicationStatus,this.LastStatusDate,this.PaidFees,this.CreatedByUserID);
            return (this.ApplicationID != -1);
        }
        clsApplication(int ApplicationID, int ApplicationPersonID, DateTime ApplicationDate
            , int ApplicationTypeID, clsApplication.enApplicationStatus ApplicationStatus, DateTime LastStatusDate, float PaidFees, int CreatedByUserID)
        {


            //this.UserInfo = clsUser.FindByUserID(CreatedByUserID);

            this._UserInfo = new clsUser();
            this._ApplicationTypeInfo = new clsApplicationTypes();

            this.ApplicationDate = ApplicationDate;
            this.ApplicationID = ApplicationID;
            this.ApplicantPersonID = ApplicationPersonID;
            this.ApplicationTypeID = ApplicationTypeID;
            this.CreatedByUserID = CreatedByUserID;
            this.ApplicationStatus = ApplicationStatus;
            this.LastStatusDate = LastStatusDate;
            this.PaidFees = PaidFees;

            _Mode = enMode.Update;

        }

        bool _UpdateApplication()
        {
            return clsAccessApplication.UpdateApplication(this.ApplicationID,this.ApplicantPersonID,
                this.ApplicationDate,(int) this.ApplicationTypeID, (byte)this.ApplicationStatus, this.LastStatusDate, this.PaidFees, this.CreatedByUserID);
        }


        public bool Save()
        {

            switch (_Mode)
            {

                case enMode.Addnew:
                    {

                        if (_AddnewApplication())
                        {
                            _Mode = enMode.Update;
                            return true;
                        }
                        else
                            return false;

                    }

                case enMode.Update:
                    return _UpdateApplication();

            }
            return false;
        }

      
        public static clsApplication FindBaseApplication(int ApplicationID)
        {

            int ApplicationPersonID = -1; 
            DateTime ApplicationDate=DateTime.Now;
            int ApplicationTypeID=-1;
           byte ApplicationStatus=(byte)clsApplication.enApplicationStatus.New;
            DateTime LastStatusDate=DateTime.Now; 
            float PaidFees=0; 
            int CreatedByUserID=-1;


            if (clsAccessApplication.FindApplicationByID(ApplicationID,ref ApplicationPersonID,ref ApplicationDate,
                ref ApplicationTypeID,ref ApplicationStatus,ref LastStatusDate,ref PaidFees,ref CreatedByUserID))

                return new clsApplication(ApplicationID,ApplicationPersonID,ApplicationDate,ApplicationTypeID,
                    (clsApplication.enApplicationStatus)ApplicationStatus,LastStatusDate,PaidFees,CreatedByUserID);

            else
                return null;

        }

        public  bool Delete()
        {
            return clsAccessApplication.DeleteApplication(this.ApplicationID);
        }
        public  bool Cancelled()
        {
            return clsAccessApplication.UpdateStatus(this.ApplicationID, (byte)enApplicationStatus.Cancelled);
        }
        public  bool setCompleted()
        {
            return clsAccessApplication.UpdateStatus(this.ApplicationID, (byte)enApplicationStatus.Completed);
        }
      

        public static int GetActiveApplicationIDByLicenseClass(int PersonID,enApplicationType ApplicationType,int LicenseClassID)
        {
            return clsAccessApplication.GetActiveApplicationIDByLicenseClass(PersonID,(int)ApplicationType, LicenseClassID);
        }




    }
}
