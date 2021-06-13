using EntityFlus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataFlus.Utilities
{
    public class SentencesDT
    {
        public List<ICollection<BankAccount>> GetBanksUserAccounts(string identity)
        {
            using (var db = new FlusBankEntities())
            {
                return (from userFilter in db.Users
                        where userFilter.DNI == identity
                        select userFilter.BankAccounts).ToList();
            }
        }

        //public List<BankAccount> GetBanksAccounts(List<ICollection<BankAccount>> accounts)
        //{
        //    List<BankAccount> listAccount = new List<BankAccount>();
        //    foreach(var account in accounts.ToList())
        //    {
        //        var code = account.Select(db => db.Code).FirstOrDefault();
        //        var aux = code.Substring(code.Length - 4, 4);
        //    }
        //    return listAccount;
        //}

        public User GetUser(int UserId)
        {
            using (var db = new FlusBankEntities())
            {
                return (from user in db.Users
                        where user.Id == UserId
                        select user).FirstOrDefault();
            }
        }

        public List<Transaction> GetAccountTransactions(string code)
        {
            using (var db = new FlusBankEntities())
            {
                var id = (from idAccount in db.BankAccounts
                         where idAccount.Code == code
                         select idAccount.Id).FirstOrDefault();

                return (from transactions in db.Transactions
                        where transactions.Addressee == code || transactions.BankAccointId == id
                        select transactions).ToList();
            }
        }

        public BankAccount GetAccount(int id)
        {
            using (var db = new FlusBankEntities())
            {
                return (from account in db.BankAccounts
                          where account.Id == id
                          select account).FirstOrDefault();
            }
        }
    }
}
