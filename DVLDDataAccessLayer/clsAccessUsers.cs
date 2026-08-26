using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDDataAccessLayer
{
    public class clsAccessUsers
    {





        public static DataTable GetAllUSersInf()
        {

            string query = @"


          select Users.UserID,Users.PersonID,People.FirstName+' '+People.SecondName+' '+
          ISNULL(People.ThirdName,' ')+' '+People.LastName as 
          FullName,
          Users.UserName,Users.IsActive
          from Users join People on People.PersonID=Users.PersonID;



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



        public static int AddNewUser(int PersonID, string UserName,string Password,bool IsActive)
        {

            int NewUserID = -1;


            string query = @"
                INSERT INTO Users
           ([PersonID]        
           ,[UserName]
           ,[Password]
           ,[IsActive])
          
     VALUES
           (@PersonID,@UserName,@Password,@IsActive);
                 select Scope_Identity()";



            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand Command = new SqlCommand(query, connection);

           


            Command.Parameters.AddWithValue("@PersonID", PersonID);
            Command.Parameters.AddWithValue("@UserName", UserName);
            Command.Parameters.AddWithValue("@Password", Password);
            Command.Parameters.AddWithValue("@IsActive", IsActive);

           

            try
            {
                connection.Open();

                object Result = Command.ExecuteScalar();
                if (Result != null && int.TryParse(Result.ToString(), out int NewID))
                {
                    NewUserID = NewID;
                }

            }

            catch (Exception ex)
            {
            }
            finally
            { connection.Close(); }

            return NewUserID;
        }


        public static bool GetUserInfoByUsernameAndPassword( string username,  string password,ref int personID,ref int UserID,ref bool IsActive)
        {



            bool ISFound = false;

            string query = @"
                select * from Users 
                where UserName =@UserName and Password=@Password
                ";


            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand Command = new SqlCommand(query, connection);

            Command.Parameters.AddWithValue("@UserName", username);
            Command.Parameters.AddWithValue("@Password", password);


            try
            {
                connection.Open();

                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.Read())
                {
                    ISFound = true;

                
                    IsActive = (bool)Reader["IsActive"];
                    personID = (int)Reader["PersonID"];
                    UserID = (int)Reader["UserID"];


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

        public static bool UpdateUser(int UserID, string UserName, string Password, bool IsActive)
        {

            int EffectedRows = 0;



            string query = @"Update  Users  
                            set 
                                UserName = @UserName,
                                Password = @Password,
                                IsActive = @IsActive
                                where UserID = @UserID";


            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@Password", Password);
            command.Parameters.AddWithValue("@IsActive", IsActive);
            command.Parameters.AddWithValue("@UserID", UserID);



            try
            {
                connection.Open();

                EffectedRows = command.ExecuteNonQuery();

            }

            catch (Exception ex)
            {
            }
            finally
            { connection.Close(); }

            return (EffectedRows > 0);
        }

        public static bool DeleteUser(int UserID)
        {
            int EffectedRows = 0;

            string query = "delete from Users where UserID=@UserID";


            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand Command = new SqlCommand(query, connection);

            Command.Parameters.AddWithValue("@UserID", UserID);


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

        public static bool GetUserByUserID(int UserID,ref int PersonID,ref string UserName,ref  string Password,ref bool IsActive)
        {

            bool ISFound = false;

            string query = @"
                select * from Users 
                where UserID=@UserID
                ";


            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand Command = new SqlCommand(query, connection);

            Command.Parameters.AddWithValue("@UserID", UserID);


            try
            {
                connection.Open();

                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.Read())
                {
                    ISFound = true;

                    UserName = (string)Reader["UserName"];
                    Password = (string)Reader["Password"];
                    IsActive = (bool)Reader["IsActive"];
                    PersonID = (int)Reader["PersonID"];

                   
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


        //public static bool ChangePassword(int UserID, string NewPassword)
        //{

        //    int rowsAffected = 0;
        //    SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

        //    string query = @"Update  Users  
        //                    set Password = @Password
        //                    where UserID = @UserID";

        //    SqlCommand command = new SqlCommand(query, connection);

        //    command.Parameters.AddWithValue("@UserID", UserID);

        //    try
        //    {
        //        connection.Open();
        //        rowsAffected = command.ExecuteNonQuery();

        //    }
        //    catch (Exception ex)
        //    {
        //        //Console.WriteLine("Error: " + ex.Message);
        //        return false;
        //    }

        //    finally
        //    {
        //        connection.Close();
        //    }

        //    return (rowsAffected > 0);
        //}

        public static bool GetUserInfoByPersonID(ref int UserID, int PersonID, ref string UserName, ref string Password, ref bool IsActive)
        {

            bool ISFound = false;

            string query = @"
                select * from Users 
                where PersonID=@PersonID
                ";


            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand Command = new SqlCommand(query, connection);

            Command.Parameters.AddWithValue("@PersonID", PersonID);


            try
            {
                connection.Open();

                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.Read())
                {
                    ISFound = true;

                    UserName = (string)Reader["UserName"];
                    Password = (string)Reader["Password"];
                    IsActive = (bool)Reader["IsActive"];
                    UserID = (int)Reader["UserID"];


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


        public static bool GetUserByUserName(ref int UserID, ref int PersonID, string UserName, ref string Password, ref bool IsActive)
        {

            bool ISFound = false;

            string query = @"
                select * from Users 
                where UserName=@UserName
                ";


            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand Command = new SqlCommand(query, connection);

            Command.Parameters.AddWithValue("@UserName", UserName);


            try
            {
                connection.Open();

                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.Read())
                {
                    ISFound = true;

                    UserID = (int)Reader["UserID"];
                    Password = (string)Reader["Password"];
                    IsActive = (bool)Reader["IsActive"];
                    PersonID = (int)Reader["PersonID"];

                }

                Reader.Close();

            }

            catch (Exception ex)
            {
            }
            finally
            { connection.Close(); }

            return ISFound;
        }

        public static bool IsUserExistForPersonID(int PersonID)
        {

            bool IsUser = false;

            string query = "select found=1 from Users where Users.PersonID=@PersonID";


            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand Command = new SqlCommand(query, connection);

            Command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();

                SqlDataReader Reader = Command.ExecuteReader();
                IsUser = Reader.HasRows;


                Reader.Close();
            }
            catch (Exception ex)
            {
                IsUser = false;
            }
            finally
            { connection.Close(); }


            return IsUser;
        }


        public static bool IsUserExistsByUserName(string UserName)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT Found=1 FROM Users WHERE UserName = @UserName";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@UserName", UserName);

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


        public static bool IsUserExistsByUserID(int UserID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT Found=1 FROM Users WHERE UserID = @UserID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@UserID", UserID);

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









    }
}
