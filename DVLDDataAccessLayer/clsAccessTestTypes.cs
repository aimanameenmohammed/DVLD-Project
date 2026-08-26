using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDDataAccessLayer
{
    public class clsAccessTestTypes
    {





        public static DataTable GetAllTestTypes()
        {

            string query = @"
               select * from TestTypes ";

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

        public static bool Update(int TestTypeID, string TestTypeTitle,string Description, float TestTypeFees)
        {

            int EffectedRows = 0;
            string query = @" Update TestTypes
                 set TestTypeTitle=@TestTypeTitle,TestTypeFees=@TestTypeFees,TestTypeDescription=@TestTypeDescription
                where TestTypeID=@TestTypeID";


            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand Command = new SqlCommand(query, connection);


            Command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            Command.Parameters.AddWithValue("@TestTypeTitle", TestTypeTitle);
            Command.Parameters.AddWithValue("@TestTypeFees", TestTypeFees);
            Command.Parameters.AddWithValue("@TestTypeDescription", Description);

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

        public static bool FindTestTypeByID(int TestTypeID, ref string TestTypeTitle, ref  string Description, ref float TestTypeFees)
        {
            bool ISFound = false;

            string query = @"
                    select * from TestTypes
                 where TestTypeID=@TestTypeID
";

            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand Command = new SqlCommand(query, connection);

            Command.Parameters.AddWithValue("@TestTypeID", TestTypeID);


            try
            {

                connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.Read())
                {

                    ISFound = true;
                    TestTypeTitle = (string)Reader["TestTypeTitle"];
                    Description = (string)Reader["TestTypeDescription"];
                    TestTypeFees = Convert.ToSingle(Reader["TestTypeFees"]);


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

        public static int AddNewTestType(string TestTypeTitle, string Description, float TestTypeFees)
        {
            int TestTypeID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Insert Into TestTypes (TestTypeTitle,TestTypeDescription,TestTypeFees)
                            Values (@TestTypeTitle,@TestTypeDescription,@TestTypeFees)
                            
                            SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TestTypeFees", TestTypeFees);
            command.Parameters.AddWithValue("@TestTypeTitle", TestTypeTitle);
            command.Parameters.AddWithValue("@TestTypeDescription", Description);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    TestTypeID = insertedID;
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


            return TestTypeID;

        }




    }
}
