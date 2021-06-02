using EntityFlus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataFlus
{
    public class BankAccountDT
    {
        public List<BankAccount> BankAccountList()
        {
            using (var db = new FlusBankEntities())
            {
                return db.BankAccounts.ToList();

            }
        }
        public void Create(BankAccount account)
        {
            using (var db = new FlusBankEntities())
            {
                db.BankAccounts.Add(account);
                db.SaveChanges();

            }
        }

        public BankAccount Details(int id)
        {
            using (var db = new FlusBankEntities())
            {
                return db.BankAccounts.Where(acc => acc.Id == id).FirstOrDefault();
            }
        }
        public void Edit(BankAccount account)
        {
            using (var db = new FlusBankEntities())
            {
                var oldAccount = db.BankAccounts.Where(acc => acc.Id == account.Id).FirstOrDefault();
                oldAccount.CurrencyId = account.CurrencyId;
                db.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var db = new FlusBankEntities())
            {
                var account = db.BankAccounts.Where(acc => acc.Id == id).FirstOrDefault();
                db.BankAccounts.Remove(account);
                db.SaveChanges();
            }
        }

        public User GetUser(string iden)
        {
            using (var db = new FlusBankEntities())
            {
                var user = db.Users.Where(usr => usr.DNI == iden).FirstOrDefault();
                return user;
            }
        }

        public bool ValidateCode(string code)
        {
            using (var db = new FlusBankEntities())
            {
                var userCode = db.BankAccounts.Where(acc => acc.Code == code);
                if (userCode.Count() > 0)
                    return false;

                return true;
            }
        }

        public bool ComprobateIdentify(string dni)
        {
            using (var db = new FlusBankEntities())
            {
                var userDni = db.Users.Where(usr => usr.DNI == dni);
                if (userDni.Count() > 0)
                    return true;

                return false;
            }
        }

    }
}
