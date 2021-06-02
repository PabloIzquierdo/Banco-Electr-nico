﻿using EntityFlus;
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

        public void Create(BanksOperation BankOperation)
        {
            using (var db = new FlusBankEntities())
            {
                int countOp = db.BanksOperations.Where(op => op.Name == BankOperation.Name).Count();
                if (countOp == 0)
                {
                    int id = 0;
                    while(BankOperation.Id == 0)
                    {
                        var currentId = db.BanksOperations.Where(op => op.Id == id).FirstOrDefault();
                        if(currentId == null)
                        {
                            BankOperation.Id = id;
                        }
                        id = Utilities.Utilities.generateIndex(id);
                    }
                    db.BanksOperations.Add(BankOperation);
                    db.SaveChanges();
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

        public void Edit(BanksOperation operationEdit)
        {
            using (var db = new FlusBankEntities())
            {
                var oldOperation = db.BanksOperations.Where(op => op.Id == operationEdit.Id).FirstOrDefault();

                int countOp = db.BanksOperations.Where(op => op.Name == operationEdit.Name).Count();
                if (countOp == 0)
                {
                    oldOperation.Name = operationEdit.Name;
                    db.SaveChanges();
                }
                else
                    throw new Exception("La operación ya existe");
            }
        }

        public void Delete(int id)
        {
            using (var db = new FlusBankEntities())
            {
                var removeOperation = db.BanksOperations.Where(op => op.Id == id).FirstOrDefault();
                db.BanksOperations.Remove(removeOperation);
                db.SaveChanges();
            }
        }

    }
}