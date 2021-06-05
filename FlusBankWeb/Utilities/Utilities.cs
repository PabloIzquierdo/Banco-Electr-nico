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