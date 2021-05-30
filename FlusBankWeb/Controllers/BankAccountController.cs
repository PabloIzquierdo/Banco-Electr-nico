using BusinessFlus;
using EntityFlus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FlusBankWeb.Utilities;

namespace FlusBankWeb.Controllers
{
    public class BankAccountController : Controller
    {
        // GET: BankAccount
        public ActionResult Index()
        {
            var bankAccounts = BankAccountBL.BankAccountList();
            return View(bankAccounts);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(BankAccount account)
        {
            try
            {
                if (!BankAccountBL.ComprobateIdentify(account.User.DNI))
                {
                    ModelState.AddModelError("", "El DNI/Pasaporte no está registrado");
                    return View(account);
                }

                account.User = BankAccountBL.GetUser(account.User.DNI);
                account.UserId = BankAccountBL.GetUser(account.User.DNI).Id;
                account.TimeStamp = DateTime.Now;
                account.Balance = 0;

                var comission = new Enums();
                comission.SetComission(account.Type);
                account.Commission = comission.GetComissionValue(comission.comission);
                account.Code = Utilities.Utilities.GenerateCode();
                while (!BankAccountBL.ValidateCode(account.Code))
                {
                    account.Code = Utilities.Utilities.GenerateCode();
                }

                BankAccountBL.Create(account);

                return RedirectToAction("Index");
            }
            catch
            {
                return View(account);
            }
        }

        public ActionResult Details(int id)
        {
            BankAccount account = BankAccountBL.Details(id);
            return View(account);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            BankAccount account = BankAccountBL.Details(id);
            return View(account);
        }

        [HttpPost]
        public ActionResult Edit(BankAccount account)
        {
            BankAccountBL.Edit(account);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                ModelState.AddModelError("", "Se necesita seleccionar un usuario");
                return RedirectToAction("Index");
            }
            BankAccount account = BankAccountBL.Details(id.Value);
            return View(account);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                BankAccountBL.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                ModelState.AddModelError("", "No se pudo eliminar esta cuenta");
                return View();
            }
        }
    }
}