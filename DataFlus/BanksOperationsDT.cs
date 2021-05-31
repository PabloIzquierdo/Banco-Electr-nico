using EntityFlus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataFlus
{
    public class BanksOperationsDT
    {
        public List<BanksOperation> BanksOperationsList()
        {
            using (var db = new FlusBankContext())
            {
                return db.BanksOperations.ToList();
            }
        }

        public void Create(BanksOperation operation)
        {
            using (var db = new FlusBankContext())
            {
                int countOp = db.BanksOperations.Where(op => op.Operation == operation.Operation).Count();
                if (countOp == 0)
                {
                    db.BanksOperations.Add(operation);
                    db.SaveChanges();
                }
                else
                    throw new Exception("La operación ya existe");
            }
        }

        public BanksOperation Details(int id)
        {
            using (var db = new FlusBankContext())
            {
                return db.BanksOperations.Where(op => op.Id == id).FirstOrDefault();
            }
        }

        public void Edit(BanksOperation operationEdit)
        {
            using (var db = new FlusBankContext())
            {
                var oldOperation = db.BanksOperations.Where(op => op.Id == operationEdit.Id).FirstOrDefault();
                oldOperation = operationEdit;
                db.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var db = new FlusBankContext())
            {
                var removeOperation = db.BanksOperations.Where(op => op.Id == id).FirstOrDefault();
                db.BanksOperations.Remove(removeOperation);
                db.SaveChanges();
            }
        }

    }
}
