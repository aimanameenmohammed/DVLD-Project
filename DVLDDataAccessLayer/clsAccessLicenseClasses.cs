using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDDataAccessLayer
{
    public class clsAccessLicenseClasses
    {





        public static  int GetMinimumAllowAgeOflicenseClassByID(int LicenseClassID)
        {

            short Age = 0;
            string query = @" 
select LicenseClasses.MinimumAllowedAge from LicenseClasses 
where LicenseClasses.LicenseClassID=@LicenseClassID

 ";


            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand Command = new SqlCommand(query, connection);
            Command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

            try
            {

                connection.Open();
                object Result = Command.ExecuteScalar();
                if (Result != null && short.TryParse(Result.ToString(), out short LicenseClassAge))
                {
                    Age = LicenseClassAge;
                }

            }
            catch (Exception ex)
            {

            }
            finally
            { connection.Close(); }

            return Age;
        }


        public static DataTable GetAllLicenseClassesInof()
        {

            string query = @"               
select * from LicenseClasses

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

        public static bool GetLicenseClassInfoByID(int LicenseClassID,ref string ClassName,ref string 
            ClassDescription,ref short MinimumAllowedAge,ref short DefaultValidityLength,ref float ClassFees)
        {
            bool ISFound = false;

            string query = @"
                  select * from LicenseClasses
           where LicenseClassID=@LicenseClassID
";

            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand Command = new SqlCommand(query, connection);

            Command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);


            try
            {

                connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.Read())
                {


                    ISFound = true;
                    ClassName = (string)Reader["ClassName"];
                    ClassDescription = (string)Reader["ClassDescription"];
                    MinimumAllowedAge = Convert.ToInt16(Reader["MinimumAllowedAge"]);
                    DefaultValidityLength = Convert.ToInt16(Reader["DefaultValidityLength"]);
                    ClassFees = Convert.ToSingle(Reader["ClassFees"]);


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

        public static bool GetLicenseClassInfoByClassName(ref int LicenseClassID,  string ClassName, ref string
                 ClassDescription, ref short MinimumAllowedAge, ref short DefaultValidityLength, ref float ClassFees)
        {
            bool ISFound = false;

            string query = @"
                  select * from LicenseClasses
           where ClassName=@ClassName
";

            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand Command = new SqlCommand(query, connection);

            Command.Parameters.AddWithValue("@ClassName", ClassName);


            try
            {

                connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.Read())
                {


                    ISFound = true;
                    LicenseClassID = (int)Reader["LicenseClassID"];
                    ClassDescription = (string)Reader["ClassDescription"];
                    MinimumAllowedAge = Convert.ToInt16(Reader["MinimumAllowedAge"]);
                    DefaultValidityLength = Convert.ToInt16(Reader["DefaultValidityLength"]);
                    ClassFees = Convert.ToSingle(Reader["ClassFees"]);


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


        public static int AddNewlicenseClass(string ClassName, string
            ClassDescription, short MinimumAllowedAge, short DefaultValidityLength, float ClassFees)
        {

            int NewLicenseClassID = -1;


            string query = @"
                INSERT INTO [dbo].[LicenseClasses]
           ([ClassName]
           ,[ClassDescription]
           ,[MinimumAllowedAge]
           ,[DefaultValidityLength]
           ,[ClassFees])
     VALUES
           (<ClassName>
           ,<ClassDescription>
           ,<MinimumAllowedAge>
           ,<DefaultValidityLength>
           ,<ClassFees>);
                 select Scope_Identity()";



            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand Command = new SqlCommand(query, connection);




            Command.Parameters.AddWithValue("@ClassName", ClassName);
            Command.Parameters.AddWithValue("@ClassDescription", ClassDescription);
            Command.Parameters.AddWithValue("@MinimumAllowedAge", MinimumAllowedAge);
            Command.Parameters.AddWithValue("@DefaultValidityLength", DefaultValidityLength);
            Command.Parameters.AddWithValue("@ClassFees", ClassFees);



            try
            {
                connection.Open();

                object Result = Command.ExecuteScalar();
                if (Result != null && int.TryParse(Result.ToString(), out int NewID))
                {
                    NewLicenseClassID = NewID;
                }

            }

            catch (Exception ex)
            {
            }
            finally
            { connection.Close(); }

            return NewLicenseClassID;
        }

        public static bool UpdatelicenseClass(int LicenseClassID,  string ClassName,  string
            ClassDescription,  short MinimumAllowedAge,  short DefaultValidityLength,  float ClassFees)
        {

            int EffectedRows = 0;



            string query = @" Update  LicenseClasses
                Set ClassName=@ClassName,ClassDescription=@ClassDescription,MinimumAllowedAge=@MinimumAllowedAge,
            DefaultValidityLength=@DefaultValidityLength,ClassFees=@ClassFees
                where LicenseClassID=@LicenseClassID";



            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand Command = new SqlCommand(query, connection);

            Command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
            Command.Parameters.AddWithValue("@ClassName", ClassName);
            Command.Parameters.AddWithValue("@ClassDescription", ClassDescription);
            Command.Parameters.AddWithValue("@MinimumAllowedAge", MinimumAllowedAge);
            Command.Parameters.AddWithValue("@DefaultValidityLength", DefaultValidityLength);
            Command.Parameters.AddWithValue("@ClassFees", ClassFees);


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

        public static bool DeletelicenseClass(int LicenseClassID)
        {
            int EffectedRows = 0;

            string query = "delete from LicenseClasses where LicenseClassID=@LicenseClassID";


            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand Command = new SqlCommand(query, connection);

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

    }
}
