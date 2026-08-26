using DVLDDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DVLDDataBusinessLayer
{
    public class clsPerson
    {



        enum enMode { Addnew = 1, Update = 2 };
        enMode _Mode;

        public int PersonID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }

        public string FullName
        {
            get
            {
                return FirstName + " " + SecondName + " " + ThirdName + " " + LastName;
            }
        }

        public string NationalNo {  get; set; }
        public DateTime DateOfBirth { get; set; }
       public  short Gender { get; set; }
       public  string Address { get; set; }
       public  string Phone { get; set; }
       public  string Email { get; set; }
       public  int NationalityCountryID { get; set; }
       public  string ImagePath { get; set; }


        public clsCountry countryInfo;



        public clsPerson()
        {

            this.PersonID = -1;
            this.FirstName = string.Empty;
            this.SecondName = string.Empty;
            this.ThirdName = string.Empty;
            this.LastName = "";
            this.DateOfBirth = DateTime.Now;
            this.Gender = -1;
            this.ImagePath = "";
            this.Address = "";
            this.Email = "";
            this.NationalityCountryID = -1;
            this.Phone = "";
            this.NationalNo = "";
            _Mode = enMode.Addnew;

        }

        clsPerson(int PersonID, string FirstName, string SecondName, string ThirdName, string LastName, DateTime DateOfBirth, short Gender, string ImagePath,
            string Address, int NationalityCountryID, string Phone, string NationalNo, string Email)
        {

            this.PersonID = PersonID;
            this.FirstName = FirstName;
            this.SecondName = SecondName;
            this.ThirdName = ThirdName;
            this.LastName = LastName;
            this.DateOfBirth = DateOfBirth;
            this.Gender = Gender;
            this.ImagePath = ImagePath;
            this.countryInfo = clsCountry.Find(NationalityCountryID);
            this.Address = Address;
            this.Email = Email;
            this.NationalityCountryID = NationalityCountryID;
            this.Phone = Phone;
            this.NationalNo = NationalNo;

            _Mode = enMode.Update;

        }

       
        private bool _Addnew()
        {
           

            this.PersonID = clsAccessPerson.AddNewPerson(this.FirstName, this.SecondName, this.ThirdName, this.LastName, this.DateOfBirth, this.Gender, this.ImagePath,
                this.Address, this.NationalityCountryID, this.Phone, this.NationalNo, this.Email);

            return (this.PersonID != -1);
        }

      


      

        private bool _Update()
        {
            return clsAccessPerson.UpdatePerson(this.PersonID,this.FirstName, this.SecondName, this.ThirdName, this.LastName, this.DateOfBirth, this.Gender, this.ImagePath,
                this.Address, this.NationalityCountryID, this.Phone, this.NationalNo, this.Email);
        }


        public static DataTable GetAllPeopleData()
        {
            return clsAccessPerson.GetAllPeopleInf();
        }

        public static clsPerson Find(int PersonID )
        {

            string FirstName="", SecondName="", ThirdName = "", LastName = "";
            string ImagePath = "", Email = "", Address = "", Phone = "";
            short Gender = -1;
            string NationalNo = "";
            DateTime DateOfBirth = DateTime.Now;
            int NationalityCountryID = -1;

            if (clsAccessPerson.GetPersonInfoByID(PersonID, ref FirstName, ref SecondName, ref ThirdName, ref LastName, ref DateOfBirth, ref Gender,
                ref ImagePath, ref Address, ref NationalityCountryID, ref Phone, ref NationalNo, ref Email))
                return new clsPerson(PersonID, FirstName, SecondName, ThirdName, LastName, DateOfBirth, Gender, ImagePath, Address, NationalityCountryID, Phone, NationalNo, Email);


            else
                return null;

        }
        public static clsPerson Find(string NationalNo)
        {

            string FirstName = "", SecondName = "", ThirdName = "", LastName = "";
            string ImagePath = "", Email = "", Address = "", Phone = "";
            short Gender = -1;
            int PersonID = -1;
            DateTime DateOfBirth = DateTime.Now;
            int NationalityCountryID = -1;


            if (clsAccessPerson.GetPersonInfoByNationalNo(ref PersonID, ref FirstName, ref SecondName, ref ThirdName, ref LastName, ref DateOfBirth, ref Gender,
                ref ImagePath, ref Address, ref NationalityCountryID, ref Phone,  NationalNo, ref Email))
                return new clsPerson(PersonID, FirstName, SecondName, ThirdName, LastName, DateOfBirth, Gender, ImagePath, Address, NationalityCountryID, Phone, NationalNo, Email);


            else
                return null;

        }






        public static bool ISPersonExists(string NationalNo)
        {
            return clsAccessPerson.IsPersonExist(NationalNo);
        }



        public static bool DeletePerson(int PersonID)
        {
            return clsAccessPerson.DeletePerson(PersonID);
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






    }
}
