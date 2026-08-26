using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLDDataAccessLayer;


namespace DVLDDataBusinessLayer
{
    public static class BankDatabaseManager
    {
        public static void InitializeDatabase()
        {
            DatabaseInitializer.InitializeDatabase();

        }
    }

}
