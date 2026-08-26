using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDDataAccessLayer
{
    public class clsAccessCountry
    {



        public static DataTable GetAllCountry()
        {

            string query = @"
                  select * from Countries Order By CountryName 
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

        public static bool FindCountryByID(int countryID,ref string countryName)
        {
            bool ISFound = false;   

            string query = @"
                  select * from Countries
where CountryID=@CountryID
";

            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand Command = new SqlCommand(query, connection);

            Command.Parameters.AddWithValue("@CountryID", countryID);


            try
            {

                connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.Read())
                {
                    ISFound = true;
                    countryName = (string)Reader["CountryName"];
                    countryID = (int)Reader["CountryID"];

                }

                Reader.Close();
            }
            catch (Exception ex)
            {
                ISFound=false;
            }
            finally
            { connection.Close(); }

            return ISFound;

        }

        public static bool FindCountryByName(ref int countryID,  string countryName)
        {
            bool ISFound = false;

            string query = @"
                  select * from Countries
where CountryName=@CountryName
";

            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand Command = new SqlCommand(query, connection);

            Command.Parameters.AddWithValue("@CountryName", countryName);


            try
            {

                connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.Read())
                {
                    ISFound = true;
                    countryName = (string)Reader["CountryName"];
                    countryID = (int)Reader["CountryID"];

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






    }
}
