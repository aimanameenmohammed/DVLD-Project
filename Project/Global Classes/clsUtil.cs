using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace FullRealLifeProject19
{
    public class clsUtil
    {

        public static string GenerateGUID()
        {

            Guid guid=Guid.NewGuid();
            return guid.ToString();
        }



        public static string ReplaceFileNameWithGuid(string SourceFile)
        {
            FileInfo f= new FileInfo(SourceFile);
            string Ext = f.Extension;
            return GenerateGUID()+ Ext;
        }


      public static  bool CreateFolderIfDoesNotExists(string Path)
        {

            if(!Directory.Exists(Path))
            {

                try
                {
                    Directory.CreateDirectory(Path);
                    return true;
                }

                catch (Exception ex)
                {
                    //MessageBox.Show("Error creating folder: " + ex.Message);

                    return false;
                }



            }
            return true;
        }



        public static bool DeletePersonImage(string ImagePath)
        {
            if (ImagePath != "")
            {
                try
                {
                    File.Delete(ImagePath);
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
            return false;
        }

        public static  bool CopyImageToProjectImagesFolder(ref string SourceFile)
        {

            string Destination = @"D:\People_Image_DVLD\";

            if (!CreateFolderIfDoesNotExists(Destination))
                return false;

            string destination = Destination + ReplaceFileNameWithGuid(SourceFile);
            try
            {

                File.Copy(SourceFile, destination,true);

            }
            catch (Exception iox)
            {
                //MessageBox.Show(iox.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }


            SourceFile = destination;
            return true;

        }




    }
}
