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

        public long GetTotalBalance(string Identity)
        {
            using (var db = new FlusBankEntities())
            {
                int userId = (from users in db.Users
                              where users.DNI == Identity
                              select users.Id).FirstOrDefault();

                List<long> accounts = (from account in db.BankAccounts
                                       where account.UserId == userId
                                       select account.Balance).ToList();
                long balance = 0;
                foreach (long currentBalance in accounts)
                {
                    balance += currentBalance;
                }

                return balance;
            }
        }

        public long GetIncomes(string code)
        {
            List<Transaction> list = GetAccountTransactions(code);
            long incomes = 0;
            foreach (Transaction transaction in list)
            {
                if (transaction.Addressee.ToString() == code)
                    incomes += (long)transaction.Amount;
                else
                    continue;
            }

            return incomes;
        }

        public long GetExpenses(string code)
        {
            List<Transaction> list = GetAccountTransactions(code);
            using (var db = new FlusBankEntities())
            {
                int accountId = (from account in db.BankAccounts
                                 where account.Code.ToString() == code
                                 select account.Id).FirstOrDefault();

                long expenses = 0;
                foreach(Transaction transaction in list)
                {
                    if (transaction.BankAccointId == accountId)
                        expenses += Convert.ToInt64(transaction.Amount);
                    else
                        continue;
                }

                return expenses;
            }
        }
    }
}
