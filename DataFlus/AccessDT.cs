using EntityFlus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataFlus
{
    public class AccessDT
    {
        public User Login(string DNI, string Password)
        {
            using (var db = new FlusBankEntities())
            {
                var User = (from d in db.Users
                                            where d.DNI == DNI.Trim()
                                            select d).FirstOrDefault();
                if (User == null)
                {
                    throw new Exception("El identificador no existe");
                }

                Password = Utilities.Utilities.setKeySHA1(Password.Trim());
                User = (from d in db.Users
                        where d.DNI == DNI.Trim() && d.PasswordHash == Password
                        select d).FirstOrDefault();

                if (User == null)
                {
                    throw new Exception("Contraseña incorrecta");
                }

                return User;
            }
        }

        public int GetRol(string Dni)
        {
            using( var db = new FlusBankEntities())
            {
                return (from d in db.Users
                        where d.DNI == Dni
                        select d.Rol).FirstOrDefault();
            }
        }
    }
}
