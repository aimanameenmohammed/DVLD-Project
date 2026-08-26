using DVLDDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DVLDDataBusinessLayer.clsTestTypes;

namespace DVLDDataBusinessLayer
{
    public class clsTests
    {

        enum enMode { Addnew = 1, Update = 2 };
        enMode _Mode;

        public int TestID {  get; set; }
       public int TestAppointmentID {  get; set; }
        public bool TestResult {  get; set; }
       public string Notes {  get; set; }
       public int CreatedByUserID {  get; set; }

        public clsTestAppointments TestAppointmentInfo { get; set; }


        public clsTests()
        {

            this.TestID = -1;
            this.TestAppointmentID = -1;
            this.Notes = "";
            this.CreatedByUserID = -1;
            this.TestResult = false;

            _Mode = enMode.Addnew;
        }


        bool _Addnew()
        {
            this.TestID = clsAccessTests.AddNewTest(this.TestAppointmentID,this.TestResult,this.Notes,this.CreatedByUserID);
            return (this.TestID != -1);
        }

        clsTests(int TestID, int TestAppointmentID, bool TestResult, string Notes, int CreatedByUserID)
        {


            this.TestID = TestID;
            this.TestAppointmentID = TestAppointmentID;
            this.Notes = Notes;
            this.CreatedByUserID = CreatedByUserID;
            this.TestResult = TestResult;

            this.TestAppointmentInfo = clsTestAppointments.Find(TestAppointmentID);

            _Mode = enMode.Update;
        }

        bool _Update()
        {
            return clsAccessTests.UpdateTest(this.TestID,this.TestAppointmentID, this.TestResult, this.Notes, this.CreatedByUserID);
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




        public static clsTests Find(int TestAppointmentID)
        {


            int TestID = -1;
            bool TestResult = false;
            string Notes = "";
            int CreatedByUserID = -1;

            if (clsAccessTests.FindTestByTestAppointmentID(ref TestID, TestAppointmentID, ref TestResult, ref Notes, ref CreatedByUserID))
                return new clsTests(TestID, TestAppointmentID, TestResult, Notes, CreatedByUserID);

            else
                return null;

        }

      


       public static int GetPassedTestCount(int LocalDrivingLicenseAppID)
        {
            return clsAccessTests.GetPassedTestCount(LocalDrivingLicenseAppID);
        }








    }
}
