using EntityFlus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataFlus
{
    public class TransactionsDT
    {
        public List<Transaction> TransactionsList()
        {
            using(var db = new FlusBankEntities())
            {
                return db.Transactions.ToList();
            }
        }

        public void Create(Transaction transaction)
        {
            using (var db = new FlusBankEntities())
            {
                int id = 0;
                while (transaction.Id == 0)
                {
                    var currentId = db.Transactions.Where(op => op.Id == id).FirstOrDefault();
                    if (currentId == null)
                    {
                        transaction.Id = id;
                    }
                    id = Utilities.Utilities.generateIndex(id);
                }
                db.Transactions.Add(transaction);
                db.SaveChanges();
            }
        }

        public Transaction Details(int id)
        {
            using (var db = new FlusBankEntities())
            {
                return db.Transactions.Where(tr => tr.Id == id).FirstOrDefault();
            }
        }

        public int ComprobateAccount(string address)
        {
            using(var db = new FlusBankEntities())
            {
                var query = from account in db.BankAccounts
                            where account.Code == address
                            select account.Id;

                return query.FirstOrDefault();
            }
        }
    }
}
