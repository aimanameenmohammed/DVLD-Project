using DVLDDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDDataBusinessLayer
{
    public class clsLicenseClasses
    {


        enum enMode { Addnew = 1, Update = 2 };
        enMode _Mode;
       
        public int LicenseClassID { get; set; }
        public string ClassName { get; set; }
        public string ClassDescription { get; set; }
        public short MinimumAllowedAge { get; set; }
        public short DefaultValidityLength { get; set; }
        public float ClassFees { get; set; }

        public clsLicenseClasses()
        {

            this.LicenseClassID = -1;
            this.ClassName = "";
            this.ClassDescription = "";
            this.MinimumAllowedAge = 0;
            this.DefaultValidityLength = 0;
            this.ClassFees= 0;

            _Mode = enMode.Addnew;
        }


        bool _Addnew()
        {
            this.LicenseClassID = clsAccessLicenseClasses.AddNewlicenseClass(this.ClassName,this.ClassDescription,this.MinimumAllowedAge,this.DefaultValidityLength,this.ClassFees);
            return (this.LicenseClassID != -1);
        }
        clsLicenseClasses(int LicenseClassID, string ClassName, string  ClassDescription,short MinimumAllowedAge,short DefaultValidityLength,float ClassFees)
        {

            this.LicenseClassID= LicenseClassID;
            this.ClassName= ClassName;
            this.ClassDescription= ClassDescription;
            this.MinimumAllowedAge= MinimumAllowedAge;
            this.DefaultValidityLength= DefaultValidityLength;
            this.ClassFees= ClassFees;

            _Mode = enMode.Update;

        }

        bool _Update()
        {
            return clsAccessLicenseClasses.UpdatelicenseClass(this.LicenseClassID,this.ClassName,this.ClassDescription,this.MinimumAllowedAge,this.DefaultValidityLength,this.ClassFees);
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

        public static bool IsPersonAgeAllowedMinimumAgeOfSelectedLicenseClass(short PersonAge ,int LicenseClassID)
        {

            PersonAge = (short)(DateTime.Now.Year - PersonAge);
            return (PersonAge >= clsAccessLicenseClasses.GetMinimumAllowAgeOflicenseClassByID(LicenseClassID));

        }
        public static DataTable GetAlllicenseClasses()
        {
            return clsAccessLicenseClasses.GetAllLicenseClassesInof();
        }
        public static clsLicenseClasses Find(int LicenseClassID)
        {


            string ClassName = "";
            string classDescription = "";
            short MinimumAllowedAge = 0;
            short DefaultValidityLength = 0;
            float ClassFees = 0;

            if (clsAccessLicenseClasses.GetLicenseClassInfoByID(LicenseClassID,ref ClassName,ref classDescription,ref MinimumAllowedAge,ref DefaultValidityLength,ref ClassFees))
                return new clsLicenseClasses(LicenseClassID, ClassName, classDescription,MinimumAllowedAge,DefaultValidityLength,ClassFees);

            else
                return null;

        }
        public static clsLicenseClasses Find(string ClassName)
        {


            int LicenseClassID = -1;
            string classDescription = "";
            short MinimumAllowedAge = 0;
            short DefaultValidityLength = 0;
            float ClassFees = 0;

            if (clsAccessLicenseClasses.GetLicenseClassInfoByClassName(ref LicenseClassID, ClassName,ref classDescription,ref MinimumAllowedAge,ref DefaultValidityLength,ref ClassFees))
                return new clsLicenseClasses(LicenseClassID, ClassName, classDescription,MinimumAllowedAge,DefaultValidityLength,ClassFees);

            else
                return null;

        }











    }
}
