using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DVLDDataAccessLayer
{
    public class clsAccessLicense
    {


        public static int AddNewLicese(int DriverID, int ApplicationID,int LicenseClassID,int CreatedByUserID,
            DateTime ExpirationDate,DateTime IssueDate,bool IsActive ,float PaidFees,byte IssueReason,string Notes)
        {

            int NewLicenseID = -1;


            string query = @" INSERT INTO Licenses
           ([ApplicationID]
           ,[DriverID]
           ,[LicenseClass]
           ,[IssueDate]
           ,[ExpirationDate]
           ,[Notes]
           ,[PaidFees]
           ,[IsActive]
           ,[IssueReason]
           ,[CreatedByUserID])
     VALUES
           (@ApplicationID
           ,@DriverID
           ,@LicenseClass
           ,@IssueDate
           ,@ExpirationDate
           ,@Notes
           ,@PaidFees
           ,@IsActive
           ,@IssueReason
           ,@CreatedByUserID);
                 select Scope_Identity()";



            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand Command = new SqlCommand(query, connection);

            Command.Parameters.AddWithValue("@DriverID", DriverID);
            Command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            Command.Parameters.AddWithValue("@LicenseClass", LicenseClassID);
            Command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            Command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
            Command.Parameters.AddWithValue("@IssueDate", IssueDate);
            Command.Parameters.AddWithValue("@IsActive", IsActive);
            Command.Parameters.AddWithValue("@PaidFees", PaidFees);
            Command.Parameters.AddWithValue("@IssueReason", IssueReason);

            if(Notes!="")
            Command.Parameters.AddWithValue("@Notes", Notes);
            else
            Command.Parameters.AddWithValue("@Notes", DBNull.Value);




                try
                {
                    connection.Open();

                    object Result = Command.ExecuteScalar();
                    if (Result != null && int.TryParse(Result.ToString(), out int NewID))
                    {
                        NewLicenseID = NewID;
                    }

                }

                catch (Exception ex)
                {
                }
                finally
                { connection.Close(); }

            return NewLicenseID;
        }
        public static bool FindLicenseByLiceseID( int LicenseID, ref int DriverID,ref  int ApplicationID,ref  int LicenseClassID,ref int CreatedByUserID,
            ref DateTime ExpirationDate,ref DateTime IssueDate, ref bool IsActive,ref float PaidFees,ref byte IssueReason,ref string Notes)
        {
            bool ISFound = false;

            string query = @"
                  select * from Licenses
           where LicenseID=@LicenseID
";

            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand Command = new SqlCommand(query, connection);

            Command.Parameters.AddWithValue("@LicenseID", LicenseID);


            try
            {

                connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.Read())
                {
                    ISFound = true;


                    DriverID = (int)Reader["DriverID"];
                    ApplicationID = (int)Reader["ApplicationID"];
                    LicenseClassID = (int)Reader["LicenseClass"];
                    CreatedByUserID = (int)Reader["CreatedByUserID"];
                    ExpirationDate = (DateTime)Reader["ExpirationDate"];
                    IssueDate = (DateTime)Reader["IssueDate"];
                    IsActive = (bool)Reader["IsActive"];
                    PaidFees = Convert.ToSingle(Reader["PaidFees"]);
                    IssueReason = Convert.ToByte(Reader["IssueReason"]);

                    if (Reader["Notes"] != DBNull.Value)
                        Notes = (string)Reader["Notes"];
                    else
                        Notes = "";

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
        public static bool FindLicenseByApplicationID(ref int LicenseID, ref int DriverID, int ApplicationID, ref int LicenseClassID, ref int CreatedByUserID,
            ref DateTime ExpirationDate, ref DateTime IssueDate, ref bool IsActive, ref float PaidFees, ref byte IssueReason, ref string Notes)
        {
            bool ISFound = false;

            string query = @"
                  select * from Licenses
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


                    DriverID = (int)Reader["DriverID"];
                    LicenseID = (int)Reader["LicenseID"];
                    LicenseClassID = (int)Reader["LicenseClass"];
                    CreatedByUserID = (int)Reader["CreatedByUserID"];
                    ExpirationDate = (DateTime)Reader["ExpirationDate"];
                    IssueDate = (DateTime)Reader["IssueDate"];
                    IsActive = (bool)Reader["IsActive"];
                    PaidFees = Convert.ToSingle(Reader["PaidFees"]);
                    IssueReason = Convert.ToByte(Reader["IssueReason"]);

                    if (Reader["Notes"] != DBNull.Value)
                        Notes = (string)Reader["Notes"];
                    else
                        Notes = "";

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
        public static bool UpdateLicense(int LicenseID,int DriverID, int ApplicationID, int LicenseClassID, int CreatedByUserID,
            DateTime ExpirationDate, DateTime IssueDate, bool IsActive, float PaidFees, byte IssueReason, string Notes)
        {

            int EffectedRows = 0;



            string query = @" UPDATE Licenses
                 SET [ApplicationID] = @ApplicationID
                    ,[DriverID] = @DriverID
                    ,[LicenseClass] = @LicenseClass
                    ,[IssueDate] = @IssueDate
                    ,[ExpirationDate] = @ExpirationDate
                    ,[Notes] = @Notes
                    ,[PaidFees] = @PaidFees
                    ,[IsActive] = @IsActive
                    ,[IssueReason] = @IssueReason
                    ,[CreatedByUserID] = @CreatedByUserID
               WHERE LicenseID=@LicenseID";
              


            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand Command = new SqlCommand(query, connection);



            Command.Parameters.AddWithValue("@LicenseID", LicenseID);
            Command.Parameters.AddWithValue("@DriverID", DriverID);
            Command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            Command.Parameters.AddWithValue("@LicenseClass", LicenseClassID);
            Command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            Command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
            Command.Parameters.AddWithValue("@IssueDate", IssueDate);
            Command.Parameters.AddWithValue("@IsActive", IsActive);
            Command.Parameters.AddWithValue("@PaidFees", PaidFees);
            Command.Parameters.AddWithValue("@IssueReason", IssueReason);

            if (Notes != "")
                Command.Parameters.AddWithValue("@Notes", Notes);
            else
                Command.Parameters.AddWithValue("@Notes", DBNull.Value);




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
        public static bool DeleteLicenseByID(int LicenseID)
        {
            int EffectedRows = 0;

            string query = "delete from Licenses where LicenseID=@LicenseID";


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


        public static bool DeActivateLicense(int LicenseID)
        {
            int EffectedRows = 0;

            string query = @"     

update Licenses 
set IsActive=0
where LicenseID=@LicenseID

";



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

        public static DataTable GetAllLocalLicenseInfoByPersonID(int PersonID)
        {


            string query = @"   

         
SELECT     
                           Licenses.LicenseID,
                           ApplicationID,
		                   LicenseClasses.ClassName, Licenses.IssueDate, 
		                   Licenses.ExpirationDate, Licenses.IsActive
                           FROM Licenses INNER JOIN
                                LicenseClasses ON Licenses.LicenseClass = LicenseClasses.LicenseClassID
                                inner join Drivers 
                                on Drivers.DriverID=Licenses.DriverID
                            where PersonID=@PersonID
                            Order By IsActive Desc, ExpirationDate Desc
          
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




        public static int GetLicenseIDByLocalDLApplicationID(int LocalDrivingLicenseApplicationID)
        {

            int LicenseID = -1;

            string query = @"
select LicenseID from LocalDrivingLicenseApplications 
join Applications on Applications.ApplicationID=LocalDrivingLicenseApplications.ApplicationID
join Licenses on Licenses.ApplicationID=Applications.ApplicationID
where LocalDrivingLicenseApplicationID=@LocalDrivingLicenseApplicationID";


            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand Command = new SqlCommand(query, connection);

            Command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);


            try
            {
                connection.Open();

                object Result = Command.ExecuteScalar();
                if (Result != null && int.TryParse(Result.ToString(), out int ID))
                {
                    LicenseID = ID;
                }

            }
            catch (Exception ex)
            {
                //
            }
            finally
            { connection.Close(); }

            return LicenseID;

        }

        public static int GetPersonIDByLicenseID(int LicenseID)
        {

            int PersonID = -1;

            string query = @"

select PersonID from Drivers
join Licenses on Licenses.DriverID=Drivers.DriverID
where LicenseID=@LicenseID
";


            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand Command = new SqlCommand(query, connection);

            Command.Parameters.AddWithValue("@LicenseID", LicenseID);


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

            return  PersonID;
            ;

        }

        public static int GetActiveLicenseIDByPersonID(int PersonID,int LicenseClassID)
        {

            int LicenseID = -1;

            string query = @"

       
       select LicenseID from Licenses
       join Drivers on Drivers.DriverID=Licenses.DriverID
       where Drivers.PersonID=@PersonID and Licenses.LicenseClass=@LicenseClassID


";


            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand Command = new SqlCommand(query, connection);

            Command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
            Command.Parameters.AddWithValue("@PersonID", PersonID);


            try
            {
                connection.Open();

                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.Read())
                {

                    LicenseID = (int)Reader["LicenseID"];

                }
                Reader.Close();

            }
            catch (Exception ex)
            {
                //
            }
            finally
            { connection.Close(); }

            return LicenseID;
            ;

        }

    }
}
