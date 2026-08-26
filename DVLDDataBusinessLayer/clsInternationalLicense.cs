using DVLDDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static DVLDDataBusinessLayer.clsLicense;

namespace DVLDDataBusinessLayer
{
    public class clsInternationalLicense:clsApplication
    {

        enum enMode { Addnew = 1, Update = 2 };
        enMode _Mode;

        public int InternationalLicenseID { get; set;}
       public int DriverID { get; set;}
        public int IssuedUsingLocalLicenseID {  get; set;}
       public DateTime IssueDate {  get; set;}
       public DateTime ExpirationDate {  get; set;}
       public bool IsActive {  get; set;}

        public clsDriver DriverInfo;

        private bool _AddnewInternationalLicense()
        {
            this.InternationalLicenseID = clsAccessInternationalLicense.AddNewInternationalLicese(this.ApplicationID, 
                this.DriverID, this.IssuedUsingLocalLicenseID, this.IssueDate, this.ExpirationDate, this.IsActive, this.CreatedByUserID);

            return (this.InternationalLicenseID != -1);
        }
        private bool _UpdateInternationalLicense()
        {

            return clsAccessInternationalLicense.UpdateInternationalLicense(
                this.InternationalLicenseID, this.ApplicationID, this.DriverID, this.IssuedUsingLocalLicenseID,
               this.IssueDate, this.ExpirationDate,
               this.IsActive, this.CreatedByUserID);
        }

        clsInternationalLicense(int InternationalLicenseID, int ApplicationID, int DriverID, int IssuedUsingLocalLicenseID,
            DateTime IssueDate, DateTime ExpirationDate, bool IsActive, int CreatedByUserID
            ,DateTime ApplicationDate,clsApplication.enApplicationStatus ApplicationStatus,
            DateTime LastStatusDate,int ApplicantPersonID,int ApplicationTypeID,float PaidFees)
        {


            base.ApplicationID = ApplicationID;
            base.CreatedByUserID= CreatedByUserID;
            base.ApplicationDate = ApplicationDate;
            base.ApplicationStatus = ApplicationStatus;
            base.LastStatusDate= LastStatusDate;
            base.ApplicantPersonID = ApplicantPersonID;
            base.ApplicationTypeID = ApplicationTypeID;
            base.PaidFees = PaidFees;


            this.ApplicationID = ApplicationID;
            this.ExpirationDate = ExpirationDate;
            this.IssueDate = IssueDate;
            this.DriverID = DriverID;
            this.IssuedUsingLocalLicenseID = IssuedUsingLocalLicenseID;
            this.CreatedByUserID = CreatedByUserID;
            this.IsActive = IsActive;
            this.InternationalLicenseID = InternationalLicenseID;

            this.DriverInfo = clsDriver.FindByID(DriverID);

            _Mode = enMode.Update;
        }


        public clsInternationalLicense()
        {
            this.ExpirationDate = DateTime.Now;
            this.IssueDate = DateTime.Now;
            this.DriverID = -1;
            this.IssuedUsingLocalLicenseID = -1;
            this.IsActive = true;
            this.InternationalLicenseID = -1;


            _Mode = enMode.Addnew;
        }



        public new bool Save()
        {


            base._Mode = (clsApplication.enMode)_Mode;

            if (!base.Save())
                return false;


            switch (_Mode)
            {

                case enMode.Addnew:
                    {

                        if (_AddnewInternationalLicense())
                        {
                            _Mode = enMode.Update;
                            return true;
                        }
                        else
                            return false;

                    }

                case enMode.Update:
                    return _UpdateInternationalLicense();
            }
            return false;
        }


        public static clsInternationalLicense Find(int InternationalLicenseID)
        {

            int DriverID = -1;
            int ApplicationID = -1;
            int IssuedUsingLocalLicenseID = -1;
            DateTime IssueDate = DateTime.Now; 
            DateTime ExpirationDate = DateTime.Now;
            bool IsActive = false;
            int CreatedByUserID = -1;

            if (clsAccessInternationalLicense.FindInternationalLicenseByID(InternationalLicenseID, ref ApplicationID,
                ref DriverID,ref IssuedUsingLocalLicenseID,ref IssueDate,ref ExpirationDate,ref IsActive, ref CreatedByUserID))
            {

                //now we find the base application

                clsApplication Application = clsApplication.FindBaseApplication(ApplicationID);

                return new clsInternationalLicense(InternationalLicenseID, ApplicationID, DriverID, IssuedUsingLocalLicenseID, IssueDate, ExpirationDate, IsActive, CreatedByUserID
                                , Application.ApplicationDate, Application.ApplicationStatus, Application.LastStatusDate, 
                                Application.ApplicantPersonID, Application.ApplicationTypeID, Application.PaidFees);

            }

            else
                return null;
        }



        public static int GetAnActiveInternationalLicenseIDByDriverID(int DriverID)
        {
            return clsAccessInternationalLicense.GetAnActiveInternationalLicenseIDByDriverID(DriverID);
        }

        public static DataTable GetAllInternationalLicenseInfoByPersonID(int personID)
        {
            return clsAccessInternationalLicense.GetAllInternationalLicenseInfoByPersonID(personID);
        }
        public static DataTable GetAllInterantionalLicenses()
        {
            return clsAccessInternationalLicense.GetAllInterantionalLicenses();
        }
    }
}
