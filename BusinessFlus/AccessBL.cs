using DataFlus;
using EntityFlus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessFlus
{
    public class AccessBL
    {
        public static AccessDT obj = new AccessDT();

        public static User Login(string DNI, string Password)
        {
            return obj.Login(DNI, Password);
        }

        public static int GetRol(string Dni)
        {
            return obj.GetRol(Dni);
        }
    }
}
