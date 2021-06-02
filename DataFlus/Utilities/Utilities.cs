using System.Text;
using System.Security.Cryptography;

namespace DataFlus.Utilities
{
    public class Utilities
    {
        public static int generateIndex(int id)
        {
            return id+=1;
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
    }
}
