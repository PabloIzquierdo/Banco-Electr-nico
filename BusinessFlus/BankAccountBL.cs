using DataFlus;
using EntityFlus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessFlus
{
    public class BankAccountBL
    {
        private static BankAccountDT obj = new BankAccountDT();

        public static List<BankAccount> BankAccountList()
        {
            return obj.BankAccountList();
        }
        public static void Create(BankAccount account)
        {
            obj.Create(account);
        }

        public static BankAccount Details(int id)
        {
            return obj.Details(id);
        }

        public static void Edit(BankAccount account)
        {
            obj.Edit(account);
        }

        public static void Delete(int id)
        {
            obj.Delete(id);
        }

        public static User GetUser(string iden)
        {
            return obj.GetUser(iden);
        }

        public static bool ValidateCode(string code)
        {
            return obj.ValidateCode(code);
        }

        public static bool ComprobateIdentify(string dni)
        {
            return obj.ComprobateIdentify(dni);
        }

    }
}
