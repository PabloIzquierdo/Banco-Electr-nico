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

        public async Task Create(User user)
        {
            using (var db = new FlusBankEntities())
            {
                db.Users.Add(user);
                await db.SaveChangesAsync();
            }
        }

        public User Details(int id)
        {
            using (var db = new FlusBankEntities())
            {
                return db.Users.Where(us => us.Id == id).FirstOrDefault();
            }
        }

        public async Task Edit(User user)
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

                await db.SaveChangesAsync();
            }
        }

        public async Task Delete(int id)
        {
            using (var db = new FlusBankEntities())
            {
                var deleteUser = db.Users.Where(us => us.Id == id).FirstOrDefault();
                db.Users.Remove(deleteUser);
                await db.SaveChangesAsync();
            }
        }

        public bool RegistryIdentity(string identity)
        {
            using(var db = new FlusBankEntities())
            {
                var query = from user in db.Users
                            where user.DNI == identity
                            select user;

                if (query.FirstOrDefault() == null)
                    return false;
                else
                    return true;
            }
        }

        public bool RegistryMail(string mail)
        {
            using (var db = new FlusBankEntities())
            {
                var query = from user in db.Users
                            where user.Email == mail
                            select user;

                if (query.FirstOrDefault() == null)
                    return false;
                else
                    return true;
            }
        }
    }
}
