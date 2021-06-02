using EntityFlus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataFlus
{
    public class UsersDT
    {
        public List<User> UserList()
        {
            using (var db = new FlusBankEntities())
            {
                return db.Users.ToList();
            }
        }

        public void Create(User user)
        {
            using (var db = new FlusBankEntities())
            {
                db.Users.Add(user);
                db.SaveChanges();
            }
        }

        public User Details(int id)
        {
            using (var db = new FlusBankEntities())
            {
                return db.Users.Where(us => us.Id == id).FirstOrDefault();
            }
        }

        public void Edit(User user)
        {
            using (var db = new FlusBankEntities())
            {
                var editUser = db.Users.Where(us => us.Id == user.Id).FirstOrDefault();

                if (!Utilities.Utilities.IsNullOrEmpty(user.Email))
                    editUser.Email = user.Email;
                if (!Utilities.Utilities.IsNullOrEmpty(user.PhoneNumber))
                    editUser.PhoneNumber = user.PhoneNumber;
                editUser.Password = editUser.PasswordHash;
                editUser.PasswordConfirm = editUser.PasswordHash;

                db.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var db = new FlusBankEntities())
            {
                var deleteUser = db.Users.Where(us => us.Id == id).FirstOrDefault();
                db.Users.Remove(deleteUser);
                db.SaveChanges();
            }
        }
    }
}
