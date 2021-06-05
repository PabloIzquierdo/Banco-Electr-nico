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

        public static void Create(Transaction transaction)
        {
            try
            {
                int idAccount = obj.ComprobateAccount(transaction.Addressee);
                transaction.BankAccointId = idAccount;
                obj.Create(transaction);
            }
            catch
            {
                throw new Exception("La cuenta destino no está registrada");
            }
        }

        public static Transaction Details(int id)
        {
            return obj.Details(id);
        }
    }
}
