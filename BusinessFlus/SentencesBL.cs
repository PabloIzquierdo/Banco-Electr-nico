using DataFlus.Utilities;
using EntityFlus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessFlus
{
    public class SentencesBL
    {
        private SentencesDT obj = new SentencesDT();

        public List<ICollection<BankAccount>> GetBanksUserAccounts(string identity)
        {
            return obj.GetBanksUserAccounts(identity);
        }

        //public List<BankAccount> GetBanksAccounts(List<ICollection<BankAccount>> accounts)
        //{
        //    return obj.GetBanksAccounts(accounts);
        //}

        public User GetUser(int UserId)
        {
            return obj.GetUser(UserId);
        }

        public List<Transaction> GetAccountTransactions(string code)
        {
            return obj.GetAccountTransactions(code);
        }

        public BankAccount GetAccount(int id)
        {
            return obj.GetAccount(id);
        }
    }
}
