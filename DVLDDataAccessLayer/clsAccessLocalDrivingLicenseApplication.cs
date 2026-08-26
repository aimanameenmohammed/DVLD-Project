using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DVLDDataAccessLayer
{
    public class clsAccessLocalDrivingLicenseApplication
    {




        public static DataTable GetAllLocalDrivingLicenseApplicationInfo()
        {

            string query = @"               

         select * from LocalDrivingLicenseApplications_View
         ORDER BY Status desc
 ";

            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand Command = new SqlCommand(query, connection);


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

        public static bool FindLocalDrivingLicenseByID(int LocalDrivingLicenseApplicationID,ref int ApplicationID,ref int LicenseClassID)
        {
            bool ISFound = false;

            string query = @"
                  select * from LocalDrivingLicenseApplications
           where LocalDrivingLicenseApplicationID=@LocalDrivingLicenseApplicationID
";

            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand Command = new SqlCommand(query, connection);

            Command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);


            try
            {

                connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.Read())
                {
                    ISFound = true;
                    ApplicationID = (int)Reader["ApplicationID"];
                    LicenseClassID = (int)Reader["LicenseClassID"];

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

        public static int AddNewLocalDrivingLicense(int ApplicationID,int LicenseClassID)
        {

            int NewLocalDrivinglicenseID = -1;


            string query = @" Insert Into LocalDrivingLicenseApplications(ApplicationID,LicenseClassID)
                Values(@ApplicationID,@LicenseClassID);
                 select Scope_Identity()";



            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand Command = new SqlCommand(query, connection);

            Command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            Command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

           

            try
            {
                connection.Open();

                object Result = Command.ExecuteScalar();
                if (Result != null && int.TryParse(Result.ToString(), out int NewID))
                {
                    NewLocalDrivinglicenseID = NewID;
                }

            }

            catch (Exception ex)
            {
            }
            finally
            { connection.Close(); }

            return NewLocalDrivinglicenseID;
        }

        public static bool UpdateLocalDrivingLicense(int LocalDrivingLicenseApplicationID,int ApplicationID, int LicenseClassID)
        {

            int EffectedRows = 0;



            string query = @" Update  LocalDrivingLicenseApplications
                Set ApplicationID=@ApplicationID,LicenseClassID=@LicenseClassID
                where LocalDrivingLicenseApplicationID=@LocalDrivingLicenseApplicationID";



            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand Command = new SqlCommand(query, connection);

            Command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            Command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            Command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);




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

        public static bool DeleteLocalDrivingLicenseApplication(int LocalDrivingLicenseApplicationID)
        {
            int EffectedRows = 0;

            string query = "delete from LocalDrivingLicenseApplications where LocalDrivingLicenseApplicationID=@LocalDrivingLicenseApplicationID";


            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand Command = new SqlCommand(query, connection);

            Command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);


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

        public static int GetApplicationIDByLocalDrivingLicenseID(int LocalDrivingLicenseApplicationID)
        {

            int ApplicationID = -1;

            string query = @" select ApplicationID from LocalDrivingLicenseApplications where
                         LocalDrivingLicenseApplicationID=@LocalDrivingLicenseApplicationID";


            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand Command = new SqlCommand(query, connection);

            Command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);


            try
            {
                connection.Open();

                object Result = Command.ExecuteScalar();
                if (Result != null && int.TryParse(Result.ToString(), out int ID))
                {
                    ApplicationID =ID;
                }

            }
            catch (Exception ex)
            {
                //
            }
            finally
            { connection.Close(); }

            return ApplicationID;

        }


        public static int GetApplicaitonPersonIDByLDLApplicaitonID(int LocalDrivingLicenseApplicationID)
        {

            int PersonID = -1;

            string query = @" select Applications.ApplicantPersonID from LocalDrivingLicenseApplications 
                 join Applications on Applications.ApplicationID=LocalDrivingLicenseApplications.ApplicationID    
                   where
                         LocalDrivingLicenseApplicationID=@LocalDrivingLicenseApplicationID";


            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand Command = new SqlCommand(query, connection);

            Command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);


            try
            {
                connection.Open();

                object Result = Command.ExecuteScalar();
                if (Result != null && int.TryParse(Result.ToString(), out int ID))
                {
                    PersonID = ID;
                }

            }
            catch (Exception ex)
            {
                //
            }
            finally
            { connection.Close(); }

            return PersonID;

        }






    }
}
