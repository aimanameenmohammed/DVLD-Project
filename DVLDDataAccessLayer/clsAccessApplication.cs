using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DVLDDataAccessLayer
{
    public class clsAccessApplication
    {






        public static bool UpdateStatus(int ApplicationID,byte Applicationstatus)
        {


            int EffectedRows = 0;
            string query = @"
                Update Applications
                 set ApplicationStatus=@Applicationstatus,
                     LastStatusDate=getdate()       
              where ApplicationID=@ApplicationID";


            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand Command = new SqlCommand(query, connection);
           
            Command.Parameters.AddWithValue("@Applicationstatus", Applicationstatus);
            Command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

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

        public static bool UpdateApplication(int ApplicationID, int ApplicationPersonID,DateTime ApplicationDate
            ,int ApplicationTypeID,byte ApplicationStatus, DateTime LastStatusDate,float PaidFees,int CreatedByUserID)
        {

            int EffectedRows = 0;
                string query = @" UPDATE Applications
            SET [ApplicantPersonID] = @ApplicantPersonID
               ,[ApplicationDate] = @ApplicationDate
               ,[ApplicationTypeID] = @ApplicationTypeID
               ,[ApplicationStatus] = @ApplicationStatus
               ,[LastStatusDate] = @LastStatusDate
               ,[PaidFees] = @PaidFees
          ,[CreatedByUserID] = @CreatedByUserID
                  WHERE ApplicationID=@ApplicationID";
          
          
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand Command = new SqlCommand(query, connection);


            Command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            Command.Parameters.AddWithValue("@ApplicantPersonID", ApplicationPersonID);
            Command.Parameters.AddWithValue("@ApplicationDate", ApplicationDate);
            Command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
            Command.Parameters.AddWithValue("@ApplicationStatus", ApplicationStatus);
            Command.Parameters.AddWithValue("@LastStatusDate", LastStatusDate);
            Command.Parameters.AddWithValue("@PaidFees", PaidFees);
            Command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

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

        public static bool FindApplicationByID(int ApplicationID, ref int ApplicationPersonID,ref DateTime ApplicationDate
            ,ref int ApplicationTypeID, ref byte ApplicationStatus,ref DateTime LastStatusDate,ref float PaidFees,ref int CreatedByUserID)
        {
            bool ISFound = false;

            string query = @"
                    select * from Applications
                 where ApplicationID=@ApplicationID
";

            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand Command = new SqlCommand(query, connection);

            Command.Parameters.AddWithValue("@ApplicationID", ApplicationID);


            try
            {

                connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.Read())
                {
                    ISFound = true;
                    ApplicationPersonID = (int)Reader["ApplicantPersonID"];
                    ApplicationDate = (DateTime)Reader["ApplicationDate"];
                    ApplicationTypeID = (int)Reader["ApplicationTypeID"];
                    ApplicationStatus = (byte)Reader["ApplicationStatus"];
                    LastStatusDate = (DateTime)Reader["LastStatusDate"];
                    PaidFees = Convert.ToSingle(Reader["PaidFees"]);
                    CreatedByUserID = (int)Reader["CreatedByUserID"];

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

        public static int AddNewApplication(int ApplicationPersonID, DateTime ApplicationDate
            , int ApplicationTypeID, byte ApplicationStatus, DateTime LastStatusDate, float PaidFees, int CreatedByUserID)
        {
            int ApplicationID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"INSERT INTO [dbo].[Applications]

                 ([ApplicantPersonID]
                 ,[ApplicationDate]
                 ,[ApplicationTypeID]
                 ,[ApplicationStatus]
                 ,[LastStatusDate]
                 ,[PaidFees]
                 ,[CreatedByUserID])
           VALUES
                 (@ApplicantPersonID
                 ,@ApplicationDate
                 ,@ApplicationTypeID
                 ,@ApplicationStatus
                 ,@LastStatusDate
                 ,@PaidFees
                 ,@CreatedByUserID);

                 SELECT SCOPE_IDENTITY();";

            SqlCommand Command = new SqlCommand(query, connection);

            Command.Parameters.AddWithValue("@ApplicantPersonID", ApplicationPersonID);
            Command.Parameters.AddWithValue("@ApplicationDate", ApplicationDate);
            Command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
            Command.Parameters.AddWithValue("@ApplicationStatus", ApplicationStatus);
            Command.Parameters.AddWithValue("@LastStatusDate", LastStatusDate);
            Command.Parameters.AddWithValue("@PaidFees", PaidFees);
            Command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            try
            {
                connection.Open();

                object result = Command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    ApplicationID = insertedID;
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


            return ApplicationID;

        }
       
        public static bool DeleteApplication(int ApplicationID)
        {
            int EffectedRows = 0;

            string query = "delete from Applications where ApplicationID=@ApplicationID";


            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand Command = new SqlCommand(query, connection);

            Command.Parameters.AddWithValue("@ApplicationID", ApplicationID);


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

        public static int GetActiveApplicationIDByLicenseClass(int PersonID, int ApplicationType, int LicenseClassID)
        {



            int ActiveApplicationID = -1;

            string query = @"


  select ActiveApplicationID=Applications.ApplicationID
  from Applications join LocalDrivingLicenseApplications on LocalDrivingLicenseApplications.ApplicationID
  =Applications.ApplicationID
  where Applications.ApplicationTypeID=@ApplicationTypeID and applications.ApplicantPersonID=@PersonID and LocalDrivingLicenseApplications.LicenseClassID=@LicenseClassID





";


            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand Command = new SqlCommand(query, connection);

            Command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
            Command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationType);
            Command.Parameters.AddWithValue("@PersonID", PersonID);


            try
            {
                connection.Open();

                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.Read())
                {

                    ActiveApplicationID = (int)Reader["ActiveApplicationID"];

                }
                Reader.Close();

            }
            catch (Exception ex)
            {
                //
            }
            finally
            { connection.Close(); }

            return ActiveApplicationID;
            ;









        }




    }
}
