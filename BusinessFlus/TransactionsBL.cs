using DataFlus;
using EntityFlus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessFlus
{
    public class TransactionsBL
    {
        private static TransactionsDT obj = new TransactionsDT();
        public static List<Transaction> TransactionsList()
        {
            return obj.TransactionsList();
        }

        public static async Task Create(Transaction transaction)
        {
            obj.ComprobateAccountWithAddress(transaction.Addressee);
            await obj.Create(transaction);
        }

        public static Transaction Details(int id)
        {
            return obj.Details(id);
        }
        public static bool Exists(int id)
        {
            return obj.Exists(id);
        }

    }
}
