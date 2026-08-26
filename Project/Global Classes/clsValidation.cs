using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FullRealLifeProject19
{
    public class clsValidation
    {


        public static bool ValidateEmail(string EmailFormat)
        {

            var pattern = @"^[a-zA-Z0-9.!#$%&'*+-/=?^_`{|}~]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$";

            var regex = new Regex(pattern);
            return regex.IsMatch(EmailFormat);
        }


        public static bool ValidateFloat(string FloatFormat)
        {

            var Pattern = @"^[0-9]*(?:\.[0-9]*)?$";
            Regex rg=new Regex(Pattern);
            return rg.IsMatch(FloatFormat);

        }


        public static bool ValidateInteger(string IntgerFormat)
        {

            var Pattern = @"^[0-9]*(?:\.[0-9]*)?$";
            Regex rg = new Regex(Pattern);
            return rg.IsMatch(IntgerFormat);

        }

        public static bool IsNumber(string NumberFormat)
        {
            return ValidateInteger(NumberFormat)||ValidateFloat(NumberFormat);
        }



    }
}
