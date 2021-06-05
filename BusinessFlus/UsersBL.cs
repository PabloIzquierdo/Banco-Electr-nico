using DataFlus;
using DataFlus.Utilities;
using EntityFlus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessFlus
{
    public class UsersBL
    {
        private static UsersDT obj = new UsersDT();

        public static List<User> UserList()
        {
            return obj.UserList();
        }

        public static void Create(User user)
        {
            if (obj.RegistryMail(user.Email))
                throw new Exception("El correo electrónico ya esta registrado");
            if (Utilities.ValidateEmail(user.Email))
                user.Email = user.Email.ToLower();

            user.Name = user.Name.Substring(0, 1).ToUpper() + user.Name.Substring(1, user.Name.Length - 1).ToLower();
            user.Surname = user.Surname.Substring(0, 1).ToUpper() + user.Surname.Substring(1, user.Surname.Length - 1).ToLower();
            user.UserName = user.Name.Substring(0, 1).ToUpper() + user.Surname.Substring(0, 1).ToUpper();

            if (obj.RegistryIdentity(user.DNI))
                throw new Exception("El DNI/Pasaporte ya esta registrado");

            user.EmailConfirmed = false;
            user.PhoneNumberConfirmed = false;

            if (Utilities.ValidatePassword(user.Password, user.PasswordConfirm))
                user.PasswordHash = Utilities.setKeySHA1(user.Password);

            obj.Create(user);
        }

        public static User Details(int id)
        {
            return obj.Details(id);
        }

        public static void Edit(User user)
        {
            obj.Edit(user);
        }

        public static void Delete(int id)
        {
            obj.Delete(id);
        }



    }
}
