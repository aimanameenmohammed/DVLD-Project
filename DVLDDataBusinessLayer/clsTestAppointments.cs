using DVLDDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DVLDDataBusinessLayer
{
    public class clsTestAppointments
    {

        enum enMode { Addnew = 1, Update = 2 };
        enMode _Mode;


        public int TestAppointmentID { get; set; }
        public int TestTypeID { get; set; }
        public int LocalDrivingLicenseApplicationID { get; set; }
        public float PaidFees {  get; set; }
        public DateTime AppointmentDate { get; set; }
        public int CreatedByUserID { get; set; }
        public int RetakeTestApplicationID { get; set; }
        public bool IsLocked { get; set; }

       public clsApplication RetakeTestApplication { get; set; }

        public int TestID
        {
            get
            {
                return GetTestID(TestAppointmentID);
            }
        }
        public clsTestAppointments()
        {

            this.TestAppointmentID = -1;
            this.CreatedByUserID = -1;
            this.TestTypeID = -1;
            this.LocalDrivingLicenseApplicationID = -1;
            this.PaidFees = 0;
            this.AppointmentDate = DateTime.Now;
            this.RetakeTestApplicationID = -1;
            this.IsLocked = false;

            _Mode = enMode.Addnew;
        }


        bool _Addnew()
        {
            this.TestAppointmentID = clsAccessTestAppointments.AddTestAppointment(this.TestTypeID,this.LocalDrivingLicenseApplicationID,this.AppointmentDate,this.PaidFees,this.CreatedByUserID,this.IsLocked,this.RetakeTestApplicationID);
            return (this.TestAppointmentID != -1);
        }
        clsTestAppointments(int TestAppointmentID, int TestTypeID, int LocalDrivingLicenseApplicationID, DateTime AppointmentDate, float PaidFees, int CreatedByUserID, bool IsLocked, int RetakeTestApplicationID)
        {


            this.RetakeTestApplication = clsApplication.FindBaseApplication(RetakeTestApplicationID);

            this.TestAppointmentID= TestAppointmentID;
            this.TestTypeID= TestTypeID;
            this.LocalDrivingLicenseApplicationID= LocalDrivingLicenseApplicationID;
            this.AppointmentDate= AppointmentDate;
            this.PaidFees   = PaidFees;
            this.CreatedByUserID= CreatedByUserID;
            this.IsLocked= IsLocked;
            this.RetakeTestApplicationID= RetakeTestApplicationID;

            _Mode = enMode.Update;

        }

        bool _Update()
        {
            return clsAccessTestAppointments.UpdateTestAppointment(this.TestAppointmentID, this.TestTypeID, this.LocalDrivingLicenseApplicationID, this.AppointmentDate, this.PaidFees, this.CreatedByUserID, this.IsLocked, this.RetakeTestApplicationID);
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



        public static clsTestAppointments Find(int TestAppointmentID)
        {


            int TestTypeID = -1;
            int LocalDrivingLicenseApplicationID = -1;
            DateTime AppointmentDate = DateTime.Now;
            float PaidFees = 0;
            int CreatedByUserID = -1;
            bool IsLocked = false;
            int RetakeTestApplicationID = -1;


            if (clsAccessTestAppointments.FindTestAppointmentByTestAppointmentID(TestAppointmentID, ref TestTypeID, ref LocalDrivingLicenseApplicationID,
                ref AppointmentDate, ref PaidFees, ref CreatedByUserID, ref IsLocked, ref RetakeTestApplicationID))
                return new clsTestAppointments(TestAppointmentID, TestTypeID, LocalDrivingLicenseApplicationID, AppointmentDate, PaidFees, CreatedByUserID, IsLocked, RetakeTestApplicationID);

            else
                return null;

        }

        public static bool Delete(int TestAppointmentID)
        {
            return clsAccessTestAppointments.DeleteTestAppointmentByTestAppointmentID(TestAppointmentID);
        }



        public static int TotalTrialPerTest(int LocalDrivingLicenseID,clsTestTypes.enTestType TestType)
        {

            return clsAccessTestAppointments.TotalTrialPerTest(LocalDrivingLicenseID, (byte)TestType);

        }

        public static bool DoesPassedTestType(int LocalDrivingLicenseApplicationID, clsTestTypes.enTestType TestType)
        {
            return clsAccessTestAppointments.DoesPassedTestType(LocalDrivingLicenseApplicationID, (byte)TestType);
        }


        public static bool IsThereAnActiveScheduleTest(int LocalDrivingLicenseApplicationID, clsTestTypes.enTestType TestType)
        {
            return clsAccessTestAppointments.IsThereAnActiveScheduleTest(LocalDrivingLicenseApplicationID,(byte)TestType);
        }


        public static DataTable GetAllAppointmentInfoByLDLApplicationIDAndTestType(int LocalDrivingLicenseApplicationID, clsTestTypes.enTestType TestType)
        {
            return clsAccessTestAppointments.GetAllAppointmentInfoByLDLApplicationIDAndTestType(LocalDrivingLicenseApplicationID,(byte)TestType);
        }


        public static bool DoesAttendTestType(int LocalDrivingLicenseApplicationID, clsTestTypes.enTestType TestType)
        {
            return clsAccessTestAppointments.DoesAttendTestType(LocalDrivingLicenseApplicationID,(byte)TestType);
        }



        private int GetTestID(int TestAppointmentID)
        {
            return clsAccessTests.GetTestID(TestAppointmentID);
        }

    }
}
