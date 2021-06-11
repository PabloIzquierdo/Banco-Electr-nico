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
        public static async Task Create(BankAccount account)
        {
            await obj.Create(account);
        }

        public static BankAccount Details(int id)
        {
            return obj.Details(id);
        }

        public static async Task Edit(BankAccount account)
        {
            await obj.Edit(account);
        }

        public static async Task Delete(int id)
        {
            await obj.Delete(id);
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

        public static bool ExistsAccount(int id)
        {
            return obj.ExistsAccount(id);
        }
    }
}
