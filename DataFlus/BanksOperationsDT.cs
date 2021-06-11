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
            using (var db = new FlusBankEntities())
            {
                return db.BanksOperations.ToList();
            }
        }

        public async Task Create(BanksOperation BankOperation)
        {
            using (var db = new FlusBankEntities())
            {
                int countOp = db.BanksOperations.Where(op => op.Name == BankOperation.Name).Count();
                if (countOp == 0)
                {
                    int id = 0;
                    while (BankOperation.Id == 0)
                    {
                        var currentId = db.BanksOperations.Where(op => op.Id == id).FirstOrDefault();
                        if (currentId == null)
                        {
                            BankOperation.Id = id;
                        }
                        id = Utilities.Utilities.generateIndex(id);
                    }
                    db.BanksOperations.Add(BankOperation);
                    await db.SaveChangesAsync();
                }
                else
                    throw new Exception("La operación ya existe");
            }
        }

        public BanksOperation Details(int id)
        {
            using (var db = new FlusBankEntities())
            {
                return db.BanksOperations.Where(op => op.Id == id).FirstOrDefault();
            }
        }

        public async Task Edit(BanksOperation operationEdit)
        {
            using (var db = new FlusBankEntities())
            {
                var oldOperation = db.BanksOperations.Where(op => op.Id == operationEdit.Id).FirstOrDefault();

                oldOperation.Description = operationEdit.Description;
                await db.SaveChangesAsync();
            }
        }

        public async Task Delete(int id)
        {
            using (var db = new FlusBankEntities())
            {
                var removeOperation = db.BanksOperations.Where(op => op.Id == id).FirstOrDefault();
                db.BanksOperations.Remove(removeOperation);
                await db.SaveChangesAsync();
            }
        }

        public bool Exist(int id)
        {
            using(var db = new FlusBankEntities())
            {
                var Operation = (from oper in db.BanksOperations
                                where oper.Id == id
                                select oper).FirstOrDefault();
                if (Operation == null)
                    return false;

                return true;
            }
        }

    }
}
