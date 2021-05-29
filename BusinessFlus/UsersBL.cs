using DataFlus;
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
