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
            string code = "ES121234";
            Random number = new Random();

            for (int i = 0; i < 16; i++)
            {
                code += number.Next(0,10).ToString();
            }

            return code;
        }
    }
}