using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDDataAccessLayer
{
    public class clsAccessInternationalLicense
    {




        public static int AddNewInternationalLicese(int ApplicationID, int DriverID, int IssuedUsingLocalLicenseID, 
            DateTime IssueDate, DateTime ExpirationDate, bool IsActive, int CreatedByUserID )
        {

            int NewInterNationalLicenseID = -1;


            string query = @" 


 Update InternationalLicenses 
                               set IsActive=0
                               where DriverID=@DriverID;

INSERT INTO InternationalLicenses
           ([ApplicationID]
           ,[DriverID]
           ,[IssuedUsingLocalLicenseID]
           ,[IssueDate]
           ,[ExpirationDate]
           ,[IsActive]
           ,[CreatedByUserID])
     VALUES
           (@ApplicationID
           ,@DriverID
           ,@IssuedUsingLocalLicenseID
           ,@IssueDate
           ,@ExpirationDate
           ,@IsActive
           ,@CreatedByUserID);
                 select Scope_Identity()";



            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand Command = new SqlCommand(query, connection);

            Command.Parameters.AddWithValue("@DriverID", DriverID);
            Command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            Command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            Command.Parameters.AddWithValue("@IssuedUsingLocalLicenseID", IssuedUsingLocalLicenseID);
            Command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
            Command.Parameters.AddWithValue("@IssueDate", IssueDate);
            Command.Parameters.AddWithValue("@IsActive", IsActive);

           



            try
            {
                connection.Open();

                object Result = Command.ExecuteScalar();
                if (Result != null && int.TryParse(Result.ToString(), out int NewID))
                {
                    NewInterNationalLicenseID = NewID;
                }

            }

            catch (Exception ex)
            {
            }
            finally
            { connection.Close(); }

            return NewInterNationalLicenseID;
        }


        public static int GetAnActiveInternationalLicenseIDByDriverID(int DriverID)
        {

            int InternationalID = -1;


            string query = @" 
 SELECT Top 1 InternationalLicenseID
                            FROM InternationalLicenses 
                            where DriverID=@DriverID and GetDate() between IssueDate and ExpirationDate 
                            order by ExpirationDate Desc";

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand Command = new SqlCommand(query, connection);

            Command.Parameters.AddWithValue("@DriverID", DriverID);

            try
            {
                connection.Open();

                SqlDataReader Reader= Command.ExecuteReader();
                if (Reader.Read())
                {
                    InternationalID = (int)Reader["InternationalLicenseID"];
                }

            }

            catch (Exception ex)
            {
            }
            finally
            { connection.Close(); }

            return InternationalID;






        }

        public static bool FindInternationalLicenseByID(int InternationalLicenseID,ref int ApplicationID, ref int DriverID,ref  int IssuedUsingLocalLicenseID,
           ref DateTime IssueDate,ref DateTime ExpirationDate,ref bool IsActive,ref int CreatedByUserID)
        {
            bool ISFound = false;

            string query = @"
                  
         select * from InternationalLicenses
         where InternationalLicenseID=@InternationalLicenseID
         ";


            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand Command = new SqlCommand(query, connection);
            Command.Parameters.AddWithValue("@InternationalLicenseID", InternationalLicenseID);


            try
            {

                connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.Read())
                {
                    ISFound = true;


                    ApplicationID = (int)Reader["ApplicationID"];
                    DriverID = (int)Reader["DriverID"];
                    IssuedUsingLocalLicenseID = (int)Reader["IssuedUsingLocalLicenseID"];                   
                    CreatedByUserID = (int)Reader["CreatedByUserID"];
                    ExpirationDate = (DateTime)Reader["ExpirationDate"];
                    IssueDate = (DateTime)Reader["IssueDate"];
                    IsActive = (bool)Reader["IsActive"];
                

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
        public static DataTable GetAllInternationalLicenseInfoByPersonID(int PersonID)
        {


            string query = @"   


 select InternationalLicenses.* from InternationalLicenses
join Drivers on InternationalLicenses.DriverID=Drivers.DriverID
where PersonID=@PersonID
  order by ExpirationDate desc


 ";

            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand Command = new SqlCommand(query, connection);
            Command.Parameters.AddWithValue("@PersonID", PersonID);


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

        public static DataTable GetAllInterantionalLicenses()
        {


            string query = @" 
select * from InternationalLicenses

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


        public static bool UpdateInternationalLicense(
              int InternationalLicenseID, int ApplicationID,
             int DriverID, int IssuedUsingLocalLicenseID,
             DateTime IssueDate, DateTime ExpirationDate, bool IsActive, int CreatedByUserID)
        {

            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"UPDATE InternationalLicenses
                           SET 
                              ApplicationID=@ApplicationID,
                              DriverID = @DriverID,
                              IssuedUsingLocalLicenseID = @IssuedUsingLocalLicenseID,
                              IssueDate = @IssueDate,
                              ExpirationDate = @ExpirationDate,
                              IsActive = @IsActive,
                              CreatedByUserID = @CreatedByUserID
                         WHERE InternationalLicenseID=@InternationalLicenseID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@InternationalLicenseID", InternationalLicenseID);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@DriverID", DriverID);
            command.Parameters.AddWithValue("@IssuedUsingLocalLicenseID", IssuedUsingLocalLicenseID);
            command.Parameters.AddWithValue("@IssueDate", IssueDate);
            command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);

            command.Parameters.AddWithValue("@IsActive", IsActive);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                return false;
            }

            finally
            {
                connection.Close();
            }

            return (rowsAffected > 0);
        }

    }
}
