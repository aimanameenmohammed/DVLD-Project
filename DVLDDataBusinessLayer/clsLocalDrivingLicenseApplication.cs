using DVLDDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DVLDDataBusinessLayer
{
    public class clsLocalDrivingLicenseApplication:clsApplication
    {


      public  enum enMode { Addnew = 1, Update = 2 };
      public  enMode _Mode=enMode.Addnew;

        public int LicenseClassID { get; set; }
        public int LocalDrivingLicenseID {  get; set; }

        public clsLicenseClasses LicenseClassInfo;
        
        public clsLocalDrivingLicenseApplication()
        {

            this.LicenseClassID = -1;
            this.ApplicationID = -1;
            this.LocalDrivingLicenseID = -1;

            _Mode = enMode.Addnew;
        }



       

        bool _AddnewLocalLicenseApplication()
        {
            this.LocalDrivingLicenseID = clsAccessLocalDrivingLicenseApplication.AddNewLocalDrivingLicense(this.ApplicationID,this.LicenseClassID);
            return (this.LocalDrivingLicenseID != -1);
        }
        clsLocalDrivingLicenseApplication(int LocalDrivingLicenseID, int LicenseClassID, int ApplicationID, int ApplicationPersonID, DateTime ApplicationDate
            , int ApplicationTypeID, clsApplication.enApplicationStatus ApplicationStatus, DateTime LastStatusDate, float PaidFees, int CreatedByUserID)
        {


            this.ApplicationID=ApplicationID;
            this.ApplicantPersonID=ApplicationPersonID;
            this.ApplicationDate=ApplicationDate;
            this.ApplicationTypeID=ApplicationTypeID;
            this.ApplicationStatus=ApplicationStatus;
            this.LastStatusDate=LastStatusDate;
           this.PaidFees=PaidFees;
            this.CreatedByUserID=CreatedByUserID;
           

            this.LicenseClassID = LicenseClassID;
            this.LocalDrivingLicenseID = LocalDrivingLicenseID;

            this.LicenseClassInfo=clsLicenseClasses.Find(LicenseClassID);

           
            _Mode = enMode.Update;
        }

        bool _UpdateLocalLicenseApplication()
        {
            return clsAccessLocalDrivingLicenseApplication.UpdateLocalDrivingLicense(this.LocalDrivingLicenseID,this.ApplicationID,this.LicenseClassID);
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

                        if (_AddnewLocalLicenseApplication())
                        {
                            _Mode = enMode.Update;
                            return true;
                        }
                        else
                            return false;

                    }

                case enMode.Update:
                    return _UpdateLocalLicenseApplication();

            }
            return false;
        }


        public static DataTable GetAllLocalDrivingLicenseApplications()
        {
            return clsAccessLocalDrivingLicenseApplication.GetAllLocalDrivingLicenseApplicationInfo();
        }
        public static clsLocalDrivingLicenseApplication FindByLocalDrivingLIcenseID(int LocalDrivingLicenseID)
        {


            int ApplicationID = -1;
            int LicenseClassID = -1;

            bool IsFound = clsAccessLocalDrivingLicenseApplication.FindLocalDrivingLicenseByID(
                LocalDrivingLicenseID, ref ApplicationID, ref LicenseClassID);
               
            if(IsFound)
            {

                clsApplication Application = clsApplication.FindBaseApplication(ApplicationID);


                return new clsLocalDrivingLicenseApplication(LocalDrivingLicenseID, LicenseClassID, Application.
                    ApplicationID, Application.ApplicantPersonID
                    , Application.ApplicationDate, Application.ApplicationTypeID, Application.ApplicationStatus,
                    Application.LastStatusDate, Application.PaidFees, Application.CreatedByUserID);

            }
            else
                return null;

        }






        public int IssueLicenseForFirstTime(int CreatedbyUser,string Notes)
        {

            int DriverID = clsDriver.GetDriverIDIfExistByPersonID(this.ApplicantPersonID);
            
            if(DriverID==-1)
            {
                clsDriver Driver = new clsDriver();

                Driver.CreatedByUserID = CreatedbyUser;
                Driver.PersonID = this.ApplicantPersonID;

                if (Driver.Save())
                {

                    DriverID = Driver.DriverID;

                }
                else
                    return -1;
            }


            clsLicense License = new clsLicense();

            License.CreatedByUserID = CreatedbyUser;
            License.DriverID= DriverID; 
            License.ApplicationID = this.ApplicationID;
            License.Notes = Notes;
            License.PaidFees = this.LicenseClassInfo.ClassFees;
            License.LicenseClassID = this.LicenseClassID;
            License.ExpirationDate = DateTime.Now.AddYears(this.LicenseClassInfo.DefaultValidityLength);
            License.IssueReason = clsLicense.enIssueReason.FirstTime;
            License.IsActive = true;
            License.IssueDate = DateTime.Now;


            if (License.Save())
            {
                this.setCompleted();
                return License.LicenseID;
            }
            else
            {
                return -1;
            }


        }



    
        public int GetActiveLicenseIDByPersonID()
        {

            return clsLicense.GetActiveLicenseIDByPersonID(this.ApplicantPersonID, this.LicenseClassID);
        }


        public static int GetApplicaitonPersonIDByLDLApplicaitonID(int LDLApplictationID)
        {
            return clsAccessLocalDrivingLicenseApplication.GetApplicaitonPersonIDByLDLApplicaitonID(LDLApplictationID);
        }

     

        public bool IsLicenseIssued()
        {
            return (GetActiveLicenseIDByPersonID() != -1);
        }
        public int GetPassedTestCount()
        {
           return  clsTests.GetPassedTestCount(this.LocalDrivingLicenseID);
        }

        public bool DoesPassedTestType(clsTestTypes.enTestType TestType)
        {
            return clsTestAppointments.DoesPassedTestType(this.LocalDrivingLicenseID, TestType);
        }
        public new bool Delete()
        {

            if (clsAccessLocalDrivingLicenseApplication.DeleteLocalDrivingLicenseApplication(this.LocalDrivingLicenseID))
            {

               return base.Delete(); 

            }
            else
                return false;
                  
        }
        public bool PassedAllTest()
        {
            return (GetPassedTestCount() == 3);
        }

        public bool DoesAttendTestType(clsTestTypes.enTestType TestType)
        {
            return clsTestAppointments.DoesAttendTestType(this.LocalDrivingLicenseID, TestType);
        }

        public int TotalTrialPerTest(clsTestTypes.enTestType TestType)
        {
            return clsTestAppointments.TotalTrialPerTest(this.LocalDrivingLicenseID, TestType);
        }


        public bool IsThereAnActiveShedultTest(clsTestTypes.enTestType TestType)
        {
            return clsTestAppointments.IsThereAnActiveScheduleTest(this.LocalDrivingLicenseID, TestType);
        }


      

    }
}
