using DVLDDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DVLDDataBusinessLayer
{
    public class clsTestTypes
    {


        enum enMode { Addnew = 1, Update = 2 };
        enMode _Mode;

        public enum enTestType { VisionTest = 1, WrittenTest = 2, StreetTest = 3 };
        public clsTestTypes.enTestType ID { get; set; }
        public string TestTypeTitle { get; set; }
        public string TestTypeDescription { get; set; }
        public float TestTypeFees { get; set; }

        public clsTestTypes()
        {

            this.TestTypeFees = 0;
            this.TestTypeTitle = "";
            this.TestTypeDescription = "";
            this.ID = enTestType.VisionTest;

            _Mode = enMode.Addnew;
        }


        bool _Addnew()
        {
            this.ID = (clsTestTypes.enTestType)clsAccessTestTypes.AddNewTestType(this.TestTypeTitle,this.TestTypeDescription,this.TestTypeFees);
            return ((int)this.ID != -1);
        }

        clsTestTypes(clsTestTypes.enTestType ID, string Title,string Description, float TestTypeFees)
        {
            this.ID = ID;
            this.TestTypeTitle = Title;
            this.TestTypeDescription = Description;
            this.TestTypeFees = TestTypeFees;

            _Mode = enMode.Update;
        }

        bool _Update()
        {
            return clsAccessTestTypes.Update((int)this.ID, this.TestTypeTitle,this.TestTypeDescription, this.TestTypeFees);
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


        public static DataTable GetAllTestTypes()
        {
            return clsAccessTestTypes.GetAllTestTypes();
        }
        public static clsTestTypes Find(clsTestTypes.enTestType TestTypeID)
        {


            string TestTypeTitle = "";
            float TestTypeFees = 0;
            string Description = "";


            if (clsAccessTestTypes.FindTestTypeByID((int)TestTypeID,ref TestTypeTitle, ref Description,ref TestTypeFees))
                return new clsTestTypes(TestTypeID, TestTypeTitle,Description, TestTypeFees);

            else
                return null;

        }

    }
}
