using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DVLDDataAccessLayer
{
    public class DatabaseInitializer
    {

        public static void InitializeDatabase()
        {
            string connectionString =
                "Server=.;Database=master;User Id=sa;Password=123456;";

            string databaseName = "DVLDDatabase";

            using (SqlConnection connection =
                   new SqlConnection(connectionString))
            {
                connection.Open();

                string checkDatabaseQuery =
                    "SELECT COUNT(*) FROM sys.databases WHERE name = @DatabaseName";

                using (SqlCommand command =
                       new SqlCommand(checkDatabaseQuery, connection))
                {
                    command.Parameters.AddWithValue(
                        "@DatabaseName",
                        databaseName);

                    int databaseExists =
                        Convert.ToInt32(command.ExecuteScalar());

                    if (databaseExists == 0)
                    {
                        CreateDatabase(connection);
                    }
                }
            }
        }

        private static void CreateDatabase(SqlConnection connection)
        {
            string databaseScriptPath = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                @"..\..\..\Database\DVLDDatabase.sql"
            );

            databaseScriptPath =
                Path.GetFullPath(databaseScriptPath);

            if (!File.Exists(databaseScriptPath))
            {
                throw new FileNotFoundException(
                    "DVLDDatabase.sql was not found.",
                    databaseScriptPath
                );
            }

            string script =
                File.ReadAllText(databaseScriptPath);

            string[] batches =
                Regex.Split(
                    script,
                    @"^\s*GO\s*(?:--.*)?$",
                    RegexOptions.Multiline |
                    RegexOptions.IgnoreCase);

            foreach (string batch in batches)
            {
                string sql = batch.Trim();

                if (string.IsNullOrWhiteSpace(sql))
                    continue;

                using (SqlCommand command =
                       new SqlCommand(sql, connection))
                {
                    command.CommandTimeout = 120;
                    command.ExecuteNonQuery();
                }
            }
        }




    }
}
