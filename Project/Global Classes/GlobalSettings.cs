using DVLDDataBusinessLayer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace FullRealLifeProject19
{
    public static class GlobalSettings
    {

        public static clsUser CurrenctUser;


        public static bool RememberUsernameAndPassword(string UserName, string Password)
        {


            try
            {

                string currentDirectory = System.IO.Directory.GetCurrentDirectory();
                string FilePath = currentDirectory + "\\UserData.txt";

                if (UserName == "" && File.Exists(FilePath))
                {
                    File.Delete(FilePath);
                    return true;
                }

                string dataToSave = UserName + "#//#" + Password;

                using (StreamWriter write = new StreamWriter(FilePath))
                {

                    write.WriteLine(dataToSave);
                    return true;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
                return false;
            }



        }


        public static bool GetStoredCredential(ref string Username, ref string Password)
        {


            try
            {

                string currentDirectory = System.IO.Directory.GetCurrentDirectory();
                string FilePath = currentDirectory + "\\UserData.txt";

                if (!File.Exists(FilePath))
                {
                    return false;
                }



                using (StreamReader reader = new StreamReader(FilePath))
                {
                    string Line;
                    while ((Line = reader.ReadLine()) != null)
                    {

                        string[] result = Line.Split(new string[] { "#//#" }, StringSplitOptions.RemoveEmptyEntries);
                        Username = result[0];
                        Password = result[1];

                    }
                    return true;

                }



            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
                return false;
            }

        }











    }














}

