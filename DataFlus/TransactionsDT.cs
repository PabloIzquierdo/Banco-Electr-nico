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
            using (var db = new FlusBankEntities())
            {
                return db.Transactions.ToList();
            }
        }

        public async Task Create(Transaction transaction)
        {
            using (var db = new FlusBankEntities())
            {
                int id = 0;
                var RootAccountId = (from account in db.BankAccounts
                                     where transaction.RootAccount == account.Code
                                     select account.Id).FirstOrDefault();
                ComprobateDistintAccounts(transaction.Addressee, RootAccountId);
                if (RootAccountId == 0)
                    throw new Exception("La cuenta orgien no está registrada");
                else
                    transaction.BankAccointId = RootAccountId;



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
                await db.SaveChangesAsync();
            }
        }

        public Transaction Details(int id)
        {
            using (var db = new FlusBankEntities())
            {
                var dbPull = db.Transactions.Where(tr => tr.Id == id).FirstOrDefault();
                var nameOperation = db.BanksOperations.Where(op => op.Id == dbPull.BankOperationId).FirstOrDefault();
                var codeAccount = db.BankAccounts.Where(op => op.Id == dbPull.BankAccointId).FirstOrDefault();
                dbPull.OperationName = nameOperation.Name;
                dbPull.IBAN = codeAccount.Code;
                return dbPull;
            }
        }

        public void ComprobateAccountWithAddress(string address)
        {
            using (var db = new FlusBankEntities())
            {
                var query = (from account in db.BankAccounts
                            where account.Code == address
                            select account.Id).FirstOrDefault();

                if (query == 0)
                    throw new Exception("La cuenta destino no existe");
            }
        }

        public bool ComprobateDistintAccounts(string code, int id)
        {
            using(var db = new FlusBankEntities())
            {
                BankAccount account = (from currentAccount in db.BankAccounts
                                      where currentAccount.Code == code && currentAccount.Id == id
                                      select currentAccount).FirstOrDefault();
                if (account != null)
                {
                    throw new Exception("No se puede hacer una operación a la misma cuenta");
                }
                else
                    return true;
            }
        }

        public bool Exists(int id)
        {
            using (var db = new FlusBankEntities())
            {
                var transaction = (from trn in db.Transactions
                                   where trn.Id == id
                                   select trn).FirstOrDefault();
                if (transaction == null)
                    return false;

                return true;
            }
        }
    }
}
