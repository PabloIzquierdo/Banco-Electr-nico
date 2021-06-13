using DataFlus;
using EntityFlus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessFlus
{
    public class TransactionsSearchedBL
    {
        private static TransactionsSearchedDT obj = new TransactionsSearchedDT();

        public static List<BankAccount> Searcher(string identity)
        {
            return obj.Searcher(identity);
        }

        public static List<Transaction> GetAllMovements(string account, string InitialDate, string EndDate, string Movement, string InitialAmount, string EndAmount)
        {
            return obj.GetAllMovements(account, InitialDate, EndDate, Movement, InitialAmount, EndAmount);
        }
    }
}