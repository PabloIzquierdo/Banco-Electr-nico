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

        public static async Task Create(User user)
        {
            if (obj.RegistryMail(user.Email))
                throw new Exception("El correo electrónico ya esta registrado");
            if (Utilities.ValidateEmail(user.Email))
                user.Email = user.Email.ToLower().Trim();

            if(obj.RegistryPhone(user.PhoneNumber.Trim()))
                throw new Exception("El DNI/Pasaporte ya esta registrado");
            user.PhoneNumber = user.PhoneNumber.Trim();

            if (obj.RegistryIdentity(user.DNI.Trim()))
                throw new Exception("El DNI/Pasaporte ya esta registrado");
            user.DNI = user.DNI.Trim();

            user.Name = user.Name.Substring(0, 1).ToUpper() + user.Name.Substring(1, user.Name.Length - 1).ToLower().Trim();
            user.Surname = user.Surname.Substring(0, 1).ToUpper() + user.Surname.Substring(1, user.Surname.Length - 1).ToLower().Trim();
            user.UserName = user.Name.Substring(0, 1).ToUpper() + user.Surname.Substring(0, 1).ToUpper();

            user.EmailConfirmed = false;
            user.PhoneNumberConfirmed = false;

            if (Utilities.ValidatePassword(user.Password.Trim(), user.PasswordConfirm.Trim()))
                user.PasswordHash = Utilities.setKeySHA1(user.Password.Trim());

            await obj.Create(user);
        }

        public static User Details(int id)
        {
            return obj.Details(id);
        }

        public static async Task Edit(User user)
        {
            await obj.Edit(user);
        }

        public static async Task Delete(int id)
        {
            await obj.Delete(id);
        }

        public static bool Exists(int id)
        {
            return obj.Exists(id);
        }

    }
}
