using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDDataAccessLayer
{
    public class clsAccessTests
    {








        public static bool UpdateTest(int TestID, int TestAppointmentID, bool TestResult, string Notes, int CreatedByUserID)
        {

            int EffectedRows = 0;
            string query = @"UPDATE Tests
   SET [TestAppointmentID] = @TestAppointmentID
      ,[TestResult] = @TestResult
      ,[Notes] =@Notes
      ,[CreatedByUserID] = @CreatedByUserID
 WHERE TestID=@TestID ";


            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand Command = new SqlCommand(query, connection);


            Command.Parameters.AddWithValue("@TestID", TestID);
            Command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            Command.Parameters.AddWithValue("@TestResult", TestResult);
            Command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            if (Notes != "")
                Command.Parameters.AddWithValue("@Notes", Notes);
            else
                Command.Parameters.AddWithValue("@Notes", DBNull.Value);





            try
            {

                connection.Open();
                EffectedRows = Command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
            }
            finally
            { connection.Close(); }

            return (EffectedRows > 0);
        }

        public static bool FindTestByTestAppointmentID(ref int TestID, int TestAppointmentID, ref bool TestResult, ref string Notes, ref int CreatedByUserID)
        {
            bool ISFound = false;

            string query = @"
                    select * from Tests
                 where TestAppointmentID=@TestAppointmentID
";

            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand Command = new SqlCommand(query, connection);

            Command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);


            try
            {

                connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.Read())
                {

                    ISFound = true;

                    if (Reader["Notes"] != DBNull.Value)
                        Notes = (string)Reader["Notes"];
                    else
                        Notes = "";

                    TestID = (int)Reader["TestID"];
                    CreatedByUserID = (int)Reader["CreatedByUserID"];
                    TestResult = (bool)Reader["TestResult"];


                }

                Reader.Close();
            }
            catch (Exception ex)
            {
                ISFound = false;
            }
            finally
            { connection.Close(); }

            return ISFound;

        }



        public static int AddNewTest(int TestAppointmentID, bool TestResult, string Notes, int CreatedByUserID)
        {
            int TestID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"INSERT INTO Tests
           ([TestAppointmentID]
           ,[TestResult]
           ,[Notes]
           ,[CreatedByUserID])
     VALUES
           (@TestAppointmentID
           ,@TestResult
           ,@Notes
           ,@CreatedByUserID);

                        
           Update TestAppointments 
           set IsLocked=1 
           where TestAppointmentID=@TestAppointmentID;
                                             
                            SELECT SCOPE_IDENTITY();";

            SqlCommand Command = new SqlCommand(query, connection);

            Command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            Command.Parameters.AddWithValue("@TestResult", TestResult);
            Command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            if (Notes != "")
                Command.Parameters.AddWithValue("@Notes", Notes);
            else
                Command.Parameters.AddWithValue("@Notes", DBNull.Value);

            try
            {
                connection.Open();

                object result = Command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    TestID = insertedID;
                }
            }

            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);

            }

            finally
            {
                connection.Close();
            }


            return TestID;

        }


        public static int GetPassedTestCount(int LocalDrivingLicenseAppID)
        {


            int PassedTestCount = -1;

            string query = @"

     select PassedTestCount =count(TestAppointments.TestTypeID) from TestAppointments
     join Tests on Tests.TestAppointmentID =TestAppointments.TestAppointmentID 
     where TestAppointments.LocalDrivingLicenseApplicationID=@LocalDrivingLicenseAppID and Tests.TestResult=1
     
     
     ";


            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand Command = new SqlCommand(query, connection);

            Command.Parameters.AddWithValue("@LocalDrivingLicenseAppID", LocalDrivingLicenseAppID);


            try
            {
                connection.Open();

                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.Read())
                {

                    PassedTestCount = (int)Reader["PassedTestCount"];

                }
                Reader.Close();

            }
            catch (Exception ex)
            {
                //
            }
            finally
            { connection.Close(); }

            return PassedTestCount;


        }

        public static bool GetLastTestPerTestType(int LocalDrivingLicenseAppID, int TestTypeID, ref int TestID
            , ref int TestAppointmentID, ref bool TestResult, ref string Notes, ref int CreatedByUserID)
        {

            bool IsFound = false;


            string query = @"

                    
      select Top 1 Tests.* from Tests join 
       TestAppointments on TestAppointments.TestAppointmentID=Tests.TestAppointmentID
       where TestAppointments.LocalDrivingLicenseApplicationID=@LocalDrivingLicenseApplicationID
      and TestAppointments.TestTypeID=@TestTypeID
       order by Tests.TestAppointmentID desc

      
      ";

            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand Command = new SqlCommand(query, connection);

            Command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseAppID);
            Command.Parameters.AddWithValue("@TestTypeID", TestTypeID);


            try
            {

                connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.Read())
                {

                    IsFound = true;

                    if (Reader["Notes"] != DBNull.Value)
                        Notes = (string)Reader["Notes"];
                    else
                        Notes = "";

                    CreatedByUserID = (int)Reader["CreatedByUserID"];
                    TestResult = (bool)Reader["TestResult"];
                    TestAppointmentID = (int)Reader["TestAppointmentID"];
                    TestID = (int)Reader["TestID"];


                }

                Reader.Close();
            }
            catch (Exception ex)
            {
                IsFound = false;
            }
            finally
            { connection.Close(); }










            return IsFound;

        }



        public static int GetTestID(int TestAppointmentID)
        {


            int TestID = -1;

            string query = @"

select TestID from Tests
join TestAppointments on Tests.TestAppointmentID=TestAppointments.TestAppointmentID
where Tests.TestAppointmentID=@TestAppointmentID
     
     ";


            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand Command = new SqlCommand(query, connection);

            Command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);


            try
            {
                connection.Open();

                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.Read())
                {

                    TestID = (int)Reader["TestID"];

                }
                Reader.Close();

            }
            catch (Exception ex)
            {
                //
            }
            finally
            { connection.Close(); }

            return TestID;


        }







    }


}


    

