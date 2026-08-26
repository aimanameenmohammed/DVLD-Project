using DVLDDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDDataBusinessLayer
{
    public class clsUser
    {



        enum enMode { Addnew = 1, Update = 2 };
        enMode _Mode;

        public int PersonID { get; set; }
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }

        public clsPerson PersonInfo;



        public clsUser()
        {

            this.PersonID = -1;
            this.UserID = -1;
            this.Password = string.Empty;
            this.IsActive = false;
            this.UserName = string.Empty;

            _Mode = enMode.Addnew;

        }


        public bool IsEmpty()
        {
            return (this.UserID == -1);
        }


        clsUser(int UserID,int PersonID,string UserName,string Password,bool IsActive)
        {

            this.PersonID = PersonID;
            this.UserID = UserID;
            this.Password = Password;
            this.IsActive = IsActive;
            this.UserName = UserName;

            PersonInfo = clsPerson.Find(PersonID);
            _Mode = enMode.Update;

        }


        private bool _Addnew()
        {


            this.UserID = clsAccessUsers.AddNewUser(this.PersonID,this.UserName,this.Password,this.IsActive);

            return (this.UserID != -1);
        }


        private bool _Update()
        {
            return clsAccessUsers.UpdateUser(this.UserID, this.UserName, this.Password,this.IsActive);
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

        public static clsUser FindByUserID(int UserID)
        {

            int PersonID = -1;
            string UserName = "";
            string Password = "";
            bool IsActive = false;

            if (clsAccessUsers.GetUserByUserID(UserID, ref PersonID,ref UserName, ref Password, ref IsActive))
                return new clsUser(UserID, PersonID, UserName, Password, IsActive);
            else
                return null;

        }

        public static clsUser Find(string  UserName)
        {

            int PersonID = -1;
            int UserID = -1;
            string Password = "";
            bool IsActive = false;

            if (clsAccessUsers.GetUserByUserName(ref UserID, ref PersonID, UserName, ref Password, ref IsActive))
                return new clsUser(UserID, PersonID, UserName, Password, IsActive);
            else
                return null;

        }

        public static clsUser FindByPersonID(int PersonID)
        {
            int UserID = -1;
            string UserName = "", Password = "";
            bool IsActive = false;

            bool IsFound = clsAccessUsers.GetUserInfoByPersonID
                                (ref UserID,  PersonID, ref UserName, ref Password, ref IsActive);

            if (IsFound)
                //we return new object of that User with the right data
                return new clsUser(UserID,PersonID,UserName,Password,IsActive);
            else
                return null;
        }


        public static clsUser FindByUsernameAndPassword(string UserName, string Password)
        {
            int UserID = -1;
            int PersonID = -1;

            bool IsActive = false;

            bool IsFound = clsAccessUsers.GetUserInfoByUsernameAndPassword
                                (UserName, Password, ref PersonID, ref UserID,ref IsActive);

            if (IsFound)
                //we return new object of that User with the right data
                return new clsUser(UserID, PersonID, UserName, Password, IsActive);
            else
                return null;
        }

        public static  bool IsUserExists(string UserName)
        {
            return clsAccessUsers.IsUserExistsByUserName(UserName);
        }
        public static  bool IsUserExists(int UserID)
        {
            return clsAccessUsers.IsUserExistsByUserID(UserID);
        }


        public static bool DeleteUser(int UserID)
        {
            return clsAccessUsers.DeleteUser(UserID);
        }

        public static bool isUserExistForPersonID(int PersonID)
        {
            return clsAccessUsers.IsUserExistForPersonID(PersonID);
        }

        public static DataTable GetAllUsersData()
        {
            return clsAccessUsers.GetAllUSersInf();
        }
    }
}
