using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDDataAccessLayer
{
    public class clsAccessDetainedLicenses
    {


        public static bool UpdateDetainLicense(int DetainID, int LicenseID, DateTime DetainDate
            , float FineFees, bool IsReleased, DateTime ReleaseDate,
            int CreatedByUserID,int ReleasedByUserID,int ReleaseApplicationID)
        {

            int EffectedRows = 0;
            string query = @" UPDATE DetainedLicenses
               SET [LicenseID] = @LicenseID
                  ,[DetainDate] = @DetainDate
                  ,[FineFees] = @FineFees
                  ,[CreatedByUserID] = @CreatedByUserID
                  ,[IsReleased] = @IsReleased
                  ,[ReleaseDate] = @ReleaseDate
                  ,[ReleasedByUserID] = @ReleasedByUserID
                  ,[ReleaseApplicationID] = @ReleaseApplicationID
             WHERE  DetainID=@DetainID ";
            
            
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand Command = new SqlCommand(query, connection);


            Command.Parameters.AddWithValue("@DetainID", DetainID);
            Command.Parameters.AddWithValue("@LicenseID", LicenseID);
            Command.Parameters.AddWithValue("@DetainDate", DetainDate);
            Command.Parameters.AddWithValue("@FineFees", FineFees);
            Command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            Command.Parameters.AddWithValue("@IsReleased", IsReleased);
            Command.Parameters.AddWithValue("@ReleaseDate", ReleaseDate);
            Command.Parameters.AddWithValue("@ReleasedByUserID", ReleasedByUserID);
            Command.Parameters.AddWithValue("@ReleaseApplicationID", ReleaseApplicationID);


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

        public static bool FindDetainLicenseByDetainID(ref int DetainID, int LicenseID, ref DateTime DetainDate
            , ref float FineFees,ref bool IsReleased,ref DateTime ReleaseDate,
           ref int CreatedByUserID,ref int ReleasedByUserID,ref int ReleaseApplicationID)
        {
            bool ISFound = false;

            string query = @"
                    select * from DetainedLicenses
                 where LicenseID=@LicenseID and IsReleased=0
";

            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand Command = new SqlCommand(query, connection);

            Command.Parameters.AddWithValue("@licenseID", LicenseID);


            try
            {

                connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.Read())
                {

                    ISFound = true;
                    DetainID = (int)Reader["DetainID"];
                    DetainDate = (DateTime)Reader["DetainDate"];
                    FineFees = Convert.ToSingle(Reader["FineFees"]);
                    IsReleased = (bool)Reader["IsReleased"];

                    if(Reader["ReleaseDate"]!=DBNull.Value)
                    ReleaseDate = (DateTime)Reader["ReleaseDate"];


                    CreatedByUserID = (int)Reader["CreatedByUserID"];

                    if(Reader["ReleasedByUserID"] != DBNull.Value)
                    ReleasedByUserID = (int)Reader["ReleasedByUserID"];

                    if(Reader["ReleaseApplicationID"] != DBNull.Value)
                    ReleaseApplicationID = (int)Reader["ReleaseApplicationID"];

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

        public static int AddNewDetainLicense(int LicenseID
            , float FineFees, int CreatedByUserID)
        {
            int DetainID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"INSERT INTO DetainedLicenses
           ([LicenseID]
           ,[DetainDate]
           ,[FineFees]
           ,[CreatedByUserID])
     VALUES
           (@LicenseID
           ,@DetainDate
           ,@FineFees
           ,@CreatedByUserID
                          );

                 SELECT SCOPE_IDENTITY();";

            SqlCommand Command = new SqlCommand(query, connection);

            Command.Parameters.AddWithValue("@LicenseID", LicenseID);
            Command.Parameters.AddWithValue("@DetainDate", DateTime.Now);
            Command.Parameters.AddWithValue("@FineFees", FineFees);
            Command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
           


            try
            {
                connection.Open();

                object result = Command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    DetainID = insertedID;
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


            return DetainID;

        }

        public static bool DeleteDetainLicense(int LicenseID)
        {
            int EffectedRows = 0;

            string query = "delete from DetainedLicenses where LicenseID=@LicenseID";


            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand Command = new SqlCommand(query, connection);

            Command.Parameters.AddWithValue("@LicenseID", LicenseID);


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

        public static bool ReleaseDetainedLicense(int DetainID,int ReleaseApplicationID,int ReleasedByUserID)
        {
            int EffectedRows = 0;

            string query = @"

         update DetainedLicenses 
         set ReleaseApplicationID=@ReleaseApplicationID,
         IsReleased=@IsReleased,
         ReleaseDate=@ReleaseDate,
         ReleasedByUserID=@ReleasedByUserID
         where DetainID=@DetainID
         
";


            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand Command = new SqlCommand(query, connection);

            Command.Parameters.AddWithValue("@IsReleased", true);
            Command.Parameters.AddWithValue("@ReleaseApplicationID", ReleaseApplicationID);
            Command.Parameters.AddWithValue("@ReleaseDate", DateTime.Now);
            Command.Parameters.AddWithValue("@ReleasedByUserID", ReleasedByUserID);
            Command.Parameters.AddWithValue("@DetainID", DetainID);


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






        public static bool IsLicenseDetained(int LicenseID)
        {


            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT Found=1 FROM DetainedLicenses WHERE LicenseID =@LicenseID AND IsReleased=0";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LicenseID", LicenseID);

            try

            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                isFound = reader.HasRows;

                reader.Close();
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;

        }


        public static DataTable GetAllDetainedLicense()
        {


            string query = @"   

select * from DetainedLicenses_View
order by IsReleased
          
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



    }
}
