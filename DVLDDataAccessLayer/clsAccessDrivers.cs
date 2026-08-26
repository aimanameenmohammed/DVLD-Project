using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DVLDDataAccessLayer
{
    public class clsAccessDrivers
    {


        public static bool GetDriverInfoByPersonID(int PersonID, ref int DriverID,
          ref int CreatedByUserID, ref DateTime CreatedDate)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM Drivers WHERE PersonID = @PersonID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    // The record was found
                    isFound = true;

                    DriverID = (int)reader["DriverID"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    CreatedDate = (DateTime)reader["CreatedDate"];

                }
                else
                {
                    // The record was not found
                    isFound = false;
                }

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


        public static bool UpdateDriver(int DriverID,int PersonID,int CreatedByUserID,DateTime CreatedDate)
        {

            int EffectedRows = 0;
                 string query = @"UPDATE [dbo].[Drivers]
        SET [PersonID] = @PersonID
           ,[CreatedByUserID] = @CreatedByUserID
           ,[CreatedDate] = @CreatedDate
      WHERE DriverID=@DriverID";
     

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand Command = new SqlCommand(query, connection);


            Command.Parameters.AddWithValue("@DriverID", DriverID);
            Command.Parameters.AddWithValue("@PersonID", PersonID);
            Command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            Command.Parameters.AddWithValue("@CreatedDate", CreatedDate);

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


        public static int GetDriverIDIfExistByPersonID(int PersonID)
        {

            int DriverID = -1;

            string query = @"
                    select DriverID from Drivers
                 where PersonID=@PersonID
";


            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand Command = new SqlCommand(query, connection);

            Command.Parameters.AddWithValue("@PersonID", PersonID);


            try
            {

                connection.Open();
                object result = Command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int ID))
                {
                    DriverID = ID;
                }

            }
            catch (Exception ex)
            {
            }
            finally
            { connection.Close(); }

            return DriverID;





        }

        public static int GetPersonIDByDriverID(int DriverID)
        {

            int PersonID = -1;

            string query = @"
                   
select PersonID from Drivers
where DriverID=@DriverID

";


            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand Command = new SqlCommand(query, connection);

            Command.Parameters.AddWithValue("@DriverID", DriverID);


            try
            {

                connection.Open();
                object result = Command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int ID))
                {
                    PersonID = ID;
                }

            }
            catch (Exception ex)
            {
            }
            finally
            { connection.Close(); }

            return PersonID;





        }

        public static bool FindDriverInfoByDriverID( int DriverID,ref int PersonID,ref int CreatedByUserID,ref DateTime CreatedDate)
        {
            bool ISFound = false;

            string query = @"
                    select * from Drivers
                 where DriverID=@DriverID
";

            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand Command = new SqlCommand(query, connection);

            Command.Parameters.AddWithValue("@DriverID", DriverID);


            try
            {

                connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.Read())
                {
                    ISFound = true;

                    PersonID = (int)Reader["PersonID"];
                    CreatedByUserID = (int)Reader["CreatedByUserID"];
                    CreatedDate = (DateTime)Reader["CreatedDate"];

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

        public static int AddNewDriver(int PersonID, int CreatedByUserID)
        {
            int DriverID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"INSERT INTO [dbo].[Drivers]
           ([PersonID]
           ,[CreatedByUserID]
           ,[CreatedDate])
     VALUES
           (@PersonID
           ,@CreatedByUserID
           ,@CreatedDate);
                            
                            SELECT SCOPE_IDENTITY();";

            SqlCommand Command = new SqlCommand(query, connection);

            Command.Parameters.AddWithValue("@PersonID", PersonID);
            Command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            Command.Parameters.AddWithValue("@CreatedDate", DateTime.Now);
            try
            {
                connection.Open();

                object result = Command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    DriverID = insertedID;
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


            return DriverID;

        }



        public static DataTable GetAllDriversInfo()
        {

            string query = @"
               select * from Drivers_View";

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
