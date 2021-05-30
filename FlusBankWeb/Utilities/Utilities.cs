using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace FlusBankWeb.Utilities
{
    public class Utilities
    {
        public bool ValidatePassword(string pass, string passConfirm)
        {
            if (pass.CompareTo(passConfirm) == 0)
                return true;

            else
                return false;
        }

        public string setKeySHA1(string cadena)
        {

            UTF8Encoding enc = new UTF8Encoding();
            byte[] data = enc.GetBytes(cadena);
            byte[] result;

            SHA1CryptoServiceProvider sha = new SHA1CryptoServiceProvider();

            result = sha.ComputeHash(data);


            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {

                // Convert values to hexadecimal
                // when it has a digit it has to fill it with zero
                // so that they always occupy two digits.
                if (result[i] < 16)
                {
                    sb.Append("0");
                }
                sb.Append(result[i].ToString("x"));
            }

            //Return string
            return sb.ToString();
        }

        public int GetRol(string rol)
        {
            if (rol == "Admin")
                return 1;
            else
                return 0;
        }


        public static bool IsNullOrEmpty(string cadena)
        {
            if (cadena == null || cadena == "")
                return true;

            return false;
        }

        public static string GenerateCode()
        {
            string code = "";
            for (int i = 0; i < 16; i++)
            {
                Random number = new Random();
                code += number.Next(9).ToString();
                if (code.Length == 4 || code.Length == 9 || code.Length == 14)
                    code += " ";
            }

            return code;
        }
    }
}