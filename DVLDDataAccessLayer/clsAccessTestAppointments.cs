using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDDataAccessLayer
{
    public class clsAccessTestAppointments
    {



        public static int AddTestAppointment(int TestTypeID, int LocalDrivingLicenseApplicationID, DateTime AppointmentDate, float PaidFees,int CreatedByUserID,bool IsLocked, int RetakeTestApplicationID)
        {

            int NewTestAppointmentID = -1;


            string query = @" INSERT INTO TestAppointments
           ([TestTypeID]
           ,[LocalDrivingLicenseApplicationID]
           ,[AppointmentDate]
           ,[PaidFees]
           ,[CreatedByUserID]
           ,[IsLocked]
           ,[RetakeTestApplicationID])
     VALUES
           (@TestTypeID
           ,@LocalDrivingLicenseApplicationID
           ,@AppointmentDate
           ,@PaidFees
           ,@CreatedByUserID
           ,@IsLocked
           ,@RetakeTestApplicationID);
                 select Scope_Identity()";



            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand Command = new SqlCommand(query, connection);

            Command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            Command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            Command.Parameters.AddWithValue("@AppointmentDate", AppointmentDate);
            Command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            Command.Parameters.AddWithValue("@PaidFees", PaidFees);
            Command.Parameters.AddWithValue("@IsLocked", IsLocked);

            if (RetakeTestApplicationID!= -1)
            Command.Parameters.AddWithValue("@RetakeTestApplicationID", RetakeTestApplicationID);
            else
                Command.Parameters.AddWithValue("@RetakeTestApplicationID", DBNull.Value);




            try
            {
                connection.Open();

                object Result = Command.ExecuteScalar();
                if (Result != null && int.TryParse(Result.ToString(), out int NewID))
                {
                    NewTestAppointmentID = NewID;
                }

            }

            catch (Exception ex)
            {
            }
            finally
            { connection.Close(); }

            return NewTestAppointmentID;
        }
        public static bool FindTestAppointmentByTestAppointmentID(int TestAppointmentID,ref int TestTypeID, ref int LocalDrivingLicenseApplicationID, ref DateTime AppointmentDate,ref float PaidFees, ref int CreatedByUserID,ref bool IsLocked, ref int RetakeTestApplicationID)
        {
            bool ISFound = false;

            string query = @"
                  select * from TestAppointments
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


                    TestTypeID = (int)Reader["TestTypeID"];
                    LocalDrivingLicenseApplicationID = (int)Reader["LocalDrivingLicenseApplicationID"];
                    CreatedByUserID = (int)Reader["CreatedByUserID"];
                    AppointmentDate = (DateTime)Reader["AppointmentDate"];
                    IsLocked = (bool)Reader["IsLocked"];
                    PaidFees = Convert.ToSingle(Reader["PaidFees"]);


                    if (Reader["RetakeTestApplicationID"] != DBNull.Value)
                        RetakeTestApplicationID = (int)Reader["RetakeTestApplicationID"];
                    else
                        RetakeTestApplicationID = -1;

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
        public static bool UpdateTestAppointment(int TestAppointmentID, int TestTypeID, int LocalDrivingLicenseApplicationID, DateTime AppointmentDate, float PaidFees, int CreatedByUserID, bool IsLocked, int RetakeTestApplicationID)
        {

            int EffectedRows = 0;



            string query = @"UPDATE TestAppointments
                     SET [TestTypeID] =@TestTypeID
                        ,[LocalDrivingLicenseApplicationID] = @LocalDrivingLicenseApplicationID
                        ,[AppointmentDate] = @AppointmentDate
                        ,[PaidFees] = @PaidFees
                        ,[CreatedByUserID] = @CreatedByUserID
                        ,[IsLocked] = @IsLocked
                        ,[RetakeTestApplicationID] = @RetakeTestApplicationID
                   WHERE TestAppointmentID=@TestAppointmentID
                  ";
                  

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand Command = new SqlCommand(query, connection);



            Command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);

            Command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            Command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            Command.Parameters.AddWithValue("@AppointmentDate", AppointmentDate);
            Command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            Command.Parameters.AddWithValue("@PaidFees", PaidFees);
            Command.Parameters.AddWithValue("@IsLocked", IsLocked);

            if (RetakeTestApplicationID != -1)
                Command.Parameters.AddWithValue("@RetakeTestApplicationID", RetakeTestApplicationID);
            else
                Command.Parameters.AddWithValue("@RetakeTestApplicationID", DBNull.Value);



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
        public static bool DeleteTestAppointmentByTestAppointmentID(int TestAppointmentID)
        {
            int EffectedRows = 0;

            string query = "delete from TestAppointments where TestAppointmentID=@TestAppointmentID";


            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand Command = new SqlCommand(query, connection);

            Command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);


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

        public static DataTable GetAllAppointmentInfoByLDLApplicationIDAndTestType(int LocalDrivingLicenseApplicationID,byte TestTypeID)
        {
            string query = @"

         select * from TestAppointments
         where TestAppointments.LocalDrivingLicenseApplicationID=
            @LocalDrivingLicenseApplicationID and TestAppointments.TestTypeID=@TestTypeID

";

            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand Command = new SqlCommand(query, connection);
            Command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            Command.Parameters.AddWithValue("@TestTypeID", TestTypeID);


            try
            {

                connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.HasRows)
                {
                    dt.Load(Reader);
                }

                Reader.Close();
            }
            catch (Exception ex)
            {

            }
            finally
            { connection.Close(); }

            return dt;

        }


       public static bool DoesPassedTestType(int LocalDrivingLicenseApplicationID, byte TestTypeID)
        {

            bool IsPassed = false;

            string query = @"
      
     
            

            select Tests.TestResult from TestAppointments join 
            Tests on Tests.TestAppointmentID =TestAppointments.TestAppointmentID
            where TestAppointments.LocalDrivingLicenseApplicationID=@LocalDrivingLicenseApplicationID
                and TestAppointments.TestTypeID=@TestTypeID and TestResult=1

             
             ";


            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand Command = new SqlCommand(query, connection);

            Command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            Command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                connection.Open();

                SqlDataReader Reader = Command.ExecuteReader();
                IsPassed = Reader.HasRows;

                Reader.Close();
            }
            catch (Exception ex)
            {
            }
            finally
            { connection.Close(); }


            return IsPassed;
        }

        public static bool DoesAttendTestType(int LocalDrivingLicenseApplicationID, byte TestTypeID)
        {

            bool Found = false;

            string query = @"
      
     
            
         
         select top 1 Found=1 from TestAppointments join 
         LocalDrivingLicenseApplications on LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID=
         TestAppointments.LocalDrivingLicenseApplicationID join Tests
         on Tests.TestAppointmentID=TestAppointments.TestAppointmentID join TestTypes on 
         TestTypes.TestTypeID=TestAppointments.TestTypeID
         where Tests.TestResult=0 and TestAppointments.LocalDrivingLicenseApplicationID=@LocalDrivingLicenseApplicationID
         and TestAppointments.TestTypeID=@TestTypeID
         
             
             ";


            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand Command = new SqlCommand(query, connection);

            Command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            Command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                connection.Open();

                SqlDataReader Reader = Command.ExecuteReader();
                Found = Reader.HasRows;

                Reader.Close();
            }
            catch (Exception ex)
            {
            }
            finally
            { connection.Close(); }


            return Found;
        }

        public static bool IsThereAnActiveScheduleTest(int LocalDrivingLicenseApplicationID, byte TestTypeID)
        {

            bool IsThere = false;

            string query = @"
               
       
         
        select Top 1 Found=1 from TestAppointments
        where TestAppointments.LocalDrivingLicenseApplicationID=@LocalDrivingLicenseApplicationID
        and TestAppointments.TestTypeID=@TestTypeID
        and Islocked=0 
        order by TestAppointments.TestAppointmentID desc
 
             
             ";


            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand Command = new SqlCommand(query, connection);

            Command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            Command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                connection.Open();

                SqlDataReader Reader = Command.ExecuteReader();
                IsThere = Reader.HasRows;

                Reader.Close();
            }
            catch (Exception ex)
            {
            }
            finally
            { connection.Close(); }


            return IsThere;
        }

        public static int TotalTrialPerTest(int LocalDrivingLicenseApplicationID, byte TestType)
        {



            int NumOfRetakeTest = 0;


                 string query = @" select count(TestID) as FaildTests from Tests
        join TestAppointments on Tests.TestAppointmentID=TestAppointments.TestAppointmentID
        where TestAppointments.TestTypeID=@TestType and 
            TestAppointments.LocalDrivingLicenseApplicationID=@LocalDrivingLicenseApplicationID
            ";
     


            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand Command = new SqlCommand(query, connection);

            Command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            Command.Parameters.AddWithValue("@TestType", TestType);
          

            try
            {
                connection.Open();

                object Result = Command.ExecuteScalar();
                if (Result != null && int.TryParse(Result.ToString(), out int Num))
                {
                    NumOfRetakeTest = Num;
                }

            }

            catch (Exception ex)
            {
            }
            finally
            { connection.Close(); }

            return NumOfRetakeTest;

        }


    }
}
