using DVLDDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDDataBusinessLayer
{
    public class clsCountry
    {




        public string countryName {  get; set; }
        public int CountryID { get; set; }


        clsCountry(string countryName, int countryID)
        {
            this.countryName = countryName;
            this.CountryID = countryID;
        }


        public static DataTable GetAllCountry()
        {
            return clsAccessCountry.GetAllCountry();
        }

        public static clsCountry Find(int CountryID)
        {
            string countryName = "";

            if (clsAccessCountry.FindCountryByID(CountryID, ref countryName))
                return new clsCountry(countryName, CountryID);

            else
                return null;
        }
        public static clsCountry Find(string CountryName)
        {
            int CountryID = -1;

            if (clsAccessCountry.FindCountryByName(ref CountryID,  CountryName))
                return new clsCountry(CountryName, CountryID);

            else
                return null;
        }





    }
}
