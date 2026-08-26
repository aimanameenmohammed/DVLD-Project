using DVLDDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDDataBusinessLayer
{
    public class clsApplicationTypes
    {

        enum enMode { Addnew = 1, Update = 2 };
        enMode _Mode;
     
        public int ApplicationTypeID {  get; set; }
        public string ApplicationTitle {  get; set; }
        public float ApplicationFees {  get; set; }

       public clsApplicationTypes()
        {

            this.ApplicationFees = 0;
            this.ApplicationTitle = "";
            this.ApplicationTypeID = -1;

            _Mode= enMode.Addnew;
        }

        public bool IsEmpty()
        {
            return (this.ApplicationTypeID ==-1);
        }
        bool _Addnew()
        {
            this.ApplicationTypeID = clsAccessApplicationTypes.AddNewApplicationType(this.ApplicationTitle, this.ApplicationFees);
            return (this.ApplicationTypeID!=-1);
        }
        clsApplicationTypes(int ID,string Title,float ApplicationFees)
        {
            this.ApplicationTypeID = ID;
            this.ApplicationTitle = Title;
            this.ApplicationFees = ApplicationFees;

            _Mode = enMode.Update;
        }

        bool _Update()
        {
            return clsAccessApplicationTypes.Update(this.ApplicationTypeID, this.ApplicationTitle, this.ApplicationFees);
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


        public static DataTable GetAllApplicationTypes()
        {
            return clsAccessApplicationTypes.GetAllApplicationTypes();
        }
        public static clsApplicationTypes Find(int ApplicationTypeID)
        {


            string ApplicationTitle = "";
            float ApplicationFees = 0;

            if (clsAccessApplicationTypes.FindApplicationTypeByID(ApplicationTypeID, ref ApplicationTitle, ref ApplicationFees))
                return new clsApplicationTypes(ApplicationTypeID, ApplicationTitle, ApplicationFees);

            else
                return null;

        }




    }
}