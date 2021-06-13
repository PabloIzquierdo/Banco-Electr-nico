using System.Text;
using System.Security.Cryptography;
using System;

namespace DataFlus.Utilities
{
    public class Utilities
    {
        public static int generateIndex(int id)
        {
            return id += 1;
        }

        public static bool ValidatePassword(string pass, string passConfirm)
        {
            bool ContainNumber = false, ContainUpper = false, ContainLower = false;
            char[] key = pass.ToCharArray();
            for (int i = 0; i < key.Length; i++)
            {
                if (char.IsNumber(key[i]))
                    ContainNumber = true;
                else if (char.IsUpper(key[i]))
                    ContainUpper = true;
                else if (char.IsLower(key[i]))
                    ContainLower = true;
            }

            if (pass.CompareTo(passConfirm) == 0)
                if (ContainNumber && ContainUpper && ContainLower)
                    return true;
                else
                {
                    throw new Exception("La contraseña debe contener un número, una letra minúscula y una letra mayúscula");
                }

            else
            {
                throw new Exception("Las contraseñas no coinciden");
            }
        }

        public static bool ValidateEmail(string mail)
        {
            if (mail.Contains("@") && mail.Contains("."))
                return true;

            throw new Exception("El email no es válido");
        }

        public static string setKeySHA1(string cadena)
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
            cadena = cadena != null ? cadena.Trim() : cadena;
            if (cadena == null || cadena == "")
                return true;

            return false;
        }
        public static bool ValidateDates(string InitialDate, string EndDate)
        {
            if (InitialDate.CompareTo(EndDate) == 1)
                throw new Exception("La fecha inicial debe ser menor o igual que la fecha final");

            return true;
        }

        public static bool ValidateAmount(int InitialAmount, int EndAmount)
        {
            if (InitialAmount > EndAmount)
                throw new Exception("El importe mínimo no puede ser mayor que el importe máximo");

            return true;
        }
    }
}
