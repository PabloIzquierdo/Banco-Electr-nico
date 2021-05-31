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

        public static void Create(BanksOperation operation)
        {
            obj.Create(operation);
        }

        public static BanksOperation Details(int id)
        {
            return obj.Details(id);
        }

        public static void Edit(BanksOperation operationEdit)
        {
            obj.Edit(operationEdit);
        }

        public static void Delete(int id)
        {
            obj.Delete(id);
        }
    }
}
