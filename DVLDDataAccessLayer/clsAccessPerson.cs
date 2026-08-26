using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DVLDDataAccessLayer
{
    public class clsAccessPerson
    {




        public static int AddNewPerson(string FirstName, string SecondName, string ThirdName, string LastName, DateTime DateOfBirth, short Gender, string ImagePath,
            string Address, int NationalityCountryID, string Phone, string NationalNo, string Email)
        {

            int NewPersonID = -1;


            string query = @"
                INSERT INTO People
           ([NationalNo]
           ,[FirstName]
           ,[SecondName]
           ,[ThirdName]
           ,[LastName]
           ,[DateOfBirth]
           ,[Gendor]
           ,[Address]
           ,[Phone]
           ,[Email]
           ,[NationalityCountryID]
           ,[ImagePath])
     VALUES
           (@NationalNo,@FirstName,@SecondName,@ThirdName,@LastName,@DateOfBirth,@Gender,@Address,@Phone,@Email,@NationalityCountryID,@ImagePath);
                 select Scope_Identity()";



            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand Command = new SqlCommand(query, connection);

            Command.Parameters.AddWithValue("@NationalNo", NationalNo);
            Command.Parameters.AddWithValue("@FirstName", FirstName);
            Command.Parameters.AddWithValue("@SecondName", SecondName);

            if (ThirdName != "")
                Command.Parameters.AddWithValue("@ThirdName", ThirdName);
            else
                Command.Parameters.AddWithValue("@ThirdName", DBNull.Value);

            if (ImagePath != "")
                Command.Parameters.AddWithValue("@ImagePath", ImagePath);
            else
                Command.Parameters.AddWithValue("@ImagePath", DBNull.Value);


            Command.Parameters.AddWithValue("@LastName", LastName);
            Command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            Command.Parameters.AddWithValue("@Gender", Gender);
            Command.Parameters.AddWithValue("@Address", Address);
            Command.Parameters.AddWithValue("@Phone", Phone);

            if (Email != "")
                Command.Parameters.AddWithValue("@Email", Email);
            else
                Command.Parameters.AddWithValue("@Email", DBNull.Value);

            Command.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);


            try
            {
                connection.Open();

                object Result = Command.ExecuteScalar();
                if (Result != null && int.TryParse(Result.ToString(), out int NewID))
                {
                    NewPersonID = NewID;
                }

            }

            catch (Exception ex)
            {
            }
            finally
            { connection.Close(); }

            return NewPersonID;
        }


        public static bool UpdatePerson(int PersonID,string FirstName, string SecondName, string ThirdName, string LastName, DateTime DateOfBirth, short Gender, string ImagePath,
           string Address, int NationalityCountryID, string Phone, string NationalNo, string Email)
        {

            int EffectedRows = 0;

          

            string query = @" Update People              
           set NationalNo=@NationalNo,FirstName=@FirstName,SecondName=@SecondName,ThirdName=@ThirdName,LastName=@LastName,DateOfBirth=@DateOfBirth
,Gendor=@Gender,Address=@Address,Phone=@Phone,Email=@Email,NationalityCountryID=@NationalityCountryID,ImagePath=@ImagePath
where PersonID=@PersonID";



            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand Command = new SqlCommand(query, connection);

            Command.Parameters.AddWithValue("@PersonID", PersonID);
            Command.Parameters.AddWithValue("@NationalNo", NationalNo);
            Command.Parameters.AddWithValue("@FirstName", FirstName);
            Command.Parameters.AddWithValue("@SecondName", SecondName);

            if (ThirdName != "")
                Command.Parameters.AddWithValue("@ThirdName", ThirdName);
            else
                Command.Parameters.AddWithValue("@ThirdName", DBNull.Value);


            if (ImagePath != "")
                Command.Parameters.AddWithValue("@ImagePath", ImagePath);
            else
                Command.Parameters.AddWithValue("@ImagePath", DBNull.Value);


            Command.Parameters.AddWithValue("@LastName", LastName);
            Command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            Command.Parameters.AddWithValue("@Gender", Gender);
            Command.Parameters.AddWithValue("@Address", Address);
            Command.Parameters.AddWithValue("@Phone", Phone);

            if (Email != "")
                Command.Parameters.AddWithValue("@Email", Email);
            else
                Command.Parameters.AddWithValue("@Email", DBNull.Value);

            Command.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);



            try
            {
                connection.Open();

               EffectedRows=Command.ExecuteNonQuery();

            }

            catch (Exception ex)
            {
            }
            finally
            { connection.Close(); }

            return (EffectedRows>0);
        }


        public static bool DeletePerson(int PersonID)
        {
            int EffectedRows = 0;

            string query = "delete from People where PersonID=@PersonID";


            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand Command = new SqlCommand(query, connection);

            Command.Parameters.AddWithValue("@PersonID", PersonID);


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







        public static bool GetPersonInfoByID(int PersonID, ref string FirstName,ref string SecondName, ref string ThirdName,ref string LastName,
            ref DateTime DateOfBirth,ref short Gender,ref string ImagePath,
         ref string Address,ref int NationalityCountryID,ref string Phone,ref string NationalNo,ref string Email)
        { 

            bool ISFound = false;

            string query = @"
                select * from People 
                where PersonID=@PersonID
                ";


            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand Command = new SqlCommand(query, connection);

            Command.Parameters.AddWithValue("@PersonID", PersonID);


            try
            {
                connection.Open();

                SqlDataReader Reader = Command.ExecuteReader();

                if(Reader.Read())
                {
                    ISFound = true;

                    FirstName = (string)Reader["FirstName"];
                    SecondName = (string)Reader["SecondName"];

                    if (Reader["ThirdName"] != DBNull.Value)
                        ThirdName = (string)Reader["FirstName"];
                    else
                        ThirdName = "";

                    LastName = (string)Reader["LastName"];

                    if (Reader["Email"] != DBNull.Value)
                        Email = (string)Reader["Email"];
                    else
                        Email = "";

                    if (Reader["ImagePath"] != DBNull.Value)
                    ImagePath = (string)Reader["ImagePath"];
                    else
                        ImagePath = "";


                    Phone = (string)Reader["Phone"];
                    NationalNo = (string)Reader["NationalNo"];
                    NationalityCountryID = (int)Reader["NationalityCountryID"];
                    DateOfBirth = (DateTime)Reader["DateOfBirth"];
                    Gender = (byte)Reader["Gendor"];
                    Address = (string)Reader["Address"];

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


        public static bool GetPersonInfoByNationalNo(ref int PersonID, ref string FirstName, ref string SecondName, ref string ThirdName, ref string LastName,
         ref DateTime DateOfBirth, ref short Gender, ref string ImagePath,
      ref string Address, ref int NationalityCountryID, ref string Phone,  string NationalNo, ref string Email)
        {

            bool ISFound = false;

            string query = @"
                select * from People 
                where NationalNo=@NationalNo
                ";


            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand Command = new SqlCommand(query, connection);

            Command.Parameters.AddWithValue("@NationalNo", NationalNo);


            try
            {
                connection.Open();

                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.Read())
                {
                    ISFound = true;

                    PersonID = (int)Reader["PersonID"];
                    FirstName = (string)Reader["FirstName"];
                    SecondName = (string)Reader["SecondName"];

                    if (Reader["ThirdName"] != DBNull.Value)
                        ThirdName = (string)Reader["FirstName"];
                    else
                        ThirdName = "";

                    LastName = (string)Reader["LastName"];

                    if (Reader["Email"] != DBNull.Value)
                        Email = (string)Reader["Email"];
                    else
                        Email = "";

                    if (Reader["ImagePath"] != DBNull.Value)
                        ImagePath = (string)Reader["ImagePath"];
                    else
                        ImagePath = "";

                    Phone = (string)Reader["Phone"];
                    NationalNo = (string)Reader["NationalNo"];
                    NationalityCountryID = (int)Reader["NationalityCountryID"];
                    DateOfBirth = (DateTime)Reader["DateOfBirth"];
                    Gender = (byte)Reader["Gendor"];
                    Address = (string)Reader["Address"];

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


        public static DataTable GetAllPeopleInf()
        {

            string query = @"

SELECT People.PersonID, People.NationalNo,
              People.FirstName, People.SecondName, People.ThirdName, People.LastName,
			  People.DateOfBirth, People.Gendor,  
				  CASE
                  WHEN People.Gendor = 0 THEN 'Male'

                  ELSE 'Female'

                  END as GendorCaption ,
			  People.Address, People.Phone, People.Email, 
              People.NationalityCountryID, Countries.CountryName, People.ImagePath
              FROM            People INNER JOIN
                         Countries ON People.NationalityCountryID = Countries.CountryID
                ORDER BY People.FirstName

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


        public static bool IsPersonExist(int PersonID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT Found=1 FROM People WHERE PersonID = @PersonID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);

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

        public static bool IsPersonExist(string NationalNo)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT Found=1 FROM People WHERE NationalNo = @NationalNo";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@NationalNo", NationalNo);

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
