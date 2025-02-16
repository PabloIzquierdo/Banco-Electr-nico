﻿using EntityFlus;
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
                    editUser.Email = user.Email.Trim();
                if (!Utilities.Utilities.IsNullOrEmpty(user.PhoneNumber))
                    editUser.PhoneNumber = user.PhoneNumber.Trim();
                editUser.Password = editUser.PasswordHash;
                editUser.PasswordConfirm = editUser.PasswordHash;

                await db.SaveChangesAsync();
            }
        }

        public async Task Delete(int id)
        {
            using (var db = new FlusBankEntities())
            {
                var accounts = from account in db.BankAccounts
                               where account.UserId == id
                               select account;

                if (accounts.Any())
                    throw new Exception("Primero debe cerrar las cuentas bancarias");

                var deleteUser = db.Users.Where(us => us.Id == id).FirstOrDefault();
                db.Users.Remove(deleteUser);
                await db.SaveChangesAsync();
            }
        }

        public bool RegistryPhone(string phone)
        {
            using (var db = new FlusBankEntities())
            {
                var query = from user in db.Users
                            where user.PhoneNumber == phone
                            select user;

                if (query.FirstOrDefault() == null)
                    return false;
                else
                    return true;
            }
        }

        public bool RegistryIdentity(string identity)
        {
            using (var db = new FlusBankEntities())
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

        public bool Exists(int id)
        {
            using (var db = new FlusBankEntities())
            {
                var user = (from usr in db.Users
                            where usr.Id == id
                            select usr).FirstOrDefault();

                if (user == null)
                    return false;

                return true;
            }
        }
    }
}
