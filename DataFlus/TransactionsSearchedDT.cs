using EntityFlus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataFlus
{
    public class TransactionsSearchedDT
    {
        public List<BankAccount> Searcher(string identity)
        {
            using (var db = new FlusBankEntities())
            {
                int idUser = (from user in db.Users
                              where user.DNI == identity
                              select user.Id).FirstOrDefault();

                return (from account in db.BankAccounts
                        where account.UserId == idUser
                        select account).ToList();
            }
        }

        public List<Transaction> GetAllMovements(string account, string InitialDate, string EndDate, string Movement, string InitialAmount, string EndAmount)
        {
            string accountCode = this.GetAccountCode(account);
            using (var db = new FlusBankEntities())
            {
                IQueryable<Transaction> query = db.Transactions;

                if (Movement == "IncomeExpenses")
                {
                    query = db.Transactions.Where(transaction => transaction.BankAccointId.ToString() == account || transaction.Addressee.Trim().ToString() == accountCode.Trim());
                }
                else if (Movement == "Income")
                {
                    query = db.Transactions.Where(transaction => transaction.Addressee.Trim().ToString() == accountCode.Trim());
                }
                else
                {
                    query = db.Transactions.Where(transaction => transaction.BankAccointId.ToString() == account);
                }

                if (!Utilities.Utilities.IsNullOrEmpty(InitialDate) && !Utilities.Utilities.IsNullOrEmpty(EndDate))
                {
                    Utilities.Utilities.ValidateDates(InitialDate, EndDate);

                    query = query.Where(transaction => transaction.Date.ToString().CompareTo(InitialDate) != -1
                    && transaction.Date.ToString().CompareTo(EndDate) != 1);
                }
                else if (!Utilities.Utilities.IsNullOrEmpty(InitialDate) || !Utilities.Utilities.IsNullOrEmpty(EndDate))
                {
                    if (!Utilities.Utilities.IsNullOrEmpty(InitialDate))
                    {
                        query = query.Where(transaction => transaction.Date.ToString().CompareTo(InitialDate) != -1);
                    }
                    else
                    {
                        query = query.Where(transaction => transaction.Date.ToString().CompareTo(EndDate) != 1);
                    }
                }

                if (!Utilities.Utilities.IsNullOrEmpty(InitialAmount) && !Utilities.Utilities.IsNullOrEmpty(EndAmount))
                {
                    int InitialAmountConver = Convert.ToInt32(InitialAmount);
                    int EndAmountConver = Convert.ToInt32(EndAmount);

                    Utilities.Utilities.ValidateAmount(InitialAmountConver, EndAmountConver);

                    query = query.Where(transaction => transaction.Amount >= InitialAmountConver && transaction.Amount <= EndAmountConver);
                }
                else if (!Utilities.Utilities.IsNullOrEmpty(InitialAmount) || !Utilities.Utilities.IsNullOrEmpty(EndAmount))
                {
                    if (!Utilities.Utilities.IsNullOrEmpty(InitialAmount))
                    {
                        int InitialAmountConver = Convert.ToInt32(InitialAmount);
                        query = query.Where(transaction => transaction.Amount >= InitialAmountConver);
                    }
                    else
                    {
                        int EndAmountConver = Convert.ToInt32(EndAmount);
                        query = query.Where(transaction => transaction.Amount <= EndAmountConver);
                    }
                }



                return new List<Transaction>(query.ToList());
            }
        }
        private string GetAccountCode(string account)
        {
            using (var db = new FlusBankEntities())
            {
                return (from acc in db.BankAccounts
                        where acc.Id.ToString() == account
                        select acc.Code).FirstOrDefault();
            }
        }
    }
}
