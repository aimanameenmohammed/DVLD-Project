using DVLDDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DVLDDataBusinessLayer
{
    public class clsDriver
    {

        enum enMode { Addnew = 1, Update = 2 };
        enMode _Mode;

        public int DriverID { get; set; }
        public int PersonID { get; set; }
        public int CreatedByUserID { get; set; }
        public DateTime CreatedDate { get; set; }

       public clsPerson PersonInfo;

        public clsDriver()
        {

            this.PersonID = -1;
            this.DriverID = -1;
            this.CreatedByUserID = -1;
            this.CreatedDate = DateTime.Now;

            _Mode = enMode.Addnew;
        }


        bool _Addnew()
        {

            this.DriverID = clsAccessDrivers.AddNewDriver(this.PersonID,this.CreatedByUserID);
            return (this.DriverID != -1);
        }
        clsDriver(int DriverID, int PersonID, int CreatedByUserID,DateTime CreatedDate)
        {
            this.DriverID = DriverID;
            this.PersonID = PersonID;
            this.CreatedDate = CreatedDate;
            this.CreatedByUserID=CreatedByUserID;

            this.PersonInfo = clsPerson.Find(PersonID);
            _Mode = enMode.Update;
        }

        bool _Update()
        {
            return clsAccessDrivers.UpdateDriver(this.DriverID,this.PersonID,this.CreatedByUserID,this.CreatedDate);
        }

        public static int GetDriverIDIfExistByPersonID(int PersonID)
        {

           return clsAccessDrivers.GetDriverIDIfExistByPersonID(PersonID);

        }


        public static clsDriver FindByID(int DriverID)
        {

            int PersonID = -1;
            int CreatedByUser = -1;
            DateTime CreatedDate=DateTime.Now;


            if (clsAccessDrivers.FindDriverInfoByDriverID(DriverID, ref PersonID, ref CreatedByUser, ref CreatedDate))
            {
                return new clsDriver(DriverID, PersonID, CreatedByUser, CreatedDate);
            }

            else
                return null;



        }



        public bool Save()
        {

            switch (_Mode)
            {
                case enMode.Addnew:
                    {

                      
                        if (_Addnew())
                        {
                            _Mode = enMode.Update;
                            return true;
                        }
                        else
                            return false;

                    }

                case enMode.Update:
                    return _Update();

            }
            return false;
        }

        public static DataTable GetAllDriversInfo()
        {
            return clsAccessDrivers.GetAllDriversInfo();
        }

        public static clsDriver FindByPersonID(int PersonID)
        {

            int DriverID = -1; int CreatedByUserID = -1; DateTime CreatedDate = DateTime.Now;

            if (clsAccessDrivers.GetDriverInfoByPersonID(PersonID, ref DriverID, ref CreatedByUserID, ref CreatedDate))

                return new clsDriver(DriverID, PersonID, CreatedByUserID, CreatedDate);
            else
                return null;

        }
        public static int GetPersonIDByDriverID(int DriverID)
        {
            return clsAccessDrivers.GetPersonIDByDriverID(DriverID);
        }




    }
}
