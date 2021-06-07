using DataFlus;
using EntityFlus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessFlus
{
    public class BanksOperationsBL
    {
        private static BanksOperationsDT obj = new BanksOperationsDT();

        public static List<BanksOperation> BanksOperationsList()
        {
            return obj.BanksOperationsList();
        }

        public static async Task Create(BanksOperation operation)
        {
            await obj.Create(operation);
        }

        public static BanksOperation Details(int id)
        {
            return obj.Details(id);
        }

        public static async Task Edit(BanksOperation operationEdit)
        {
            await obj.Edit(operationEdit);
        }

        public static async Task Delete(int id)
        {
            await obj.Delete(id);
        }
    }
}
