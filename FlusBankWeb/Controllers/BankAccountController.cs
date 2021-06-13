using BusinessFlus;
using EntityFlus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FlusBankWeb.Utilities;
using System.Threading.Tasks;

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
        public async Task<ActionResult> Create(BankAccount account)
        {
            try
            {
                if (!BankAccountBL.ComprobateIdentify(account.User.DNI.Trim()))
                {
                    ModelState.AddModelError("", "El DNI/Pasaporte no está registrado");
                    return View(account);
                }

                account.User = BankAccountBL.GetUser(account.User.DNI);
                account.UserId = BankAccountBL.GetUser(account.User.DNI).Id;
                account.TimeStamp = DateTime.Now;
                account.Balance = 1000;

                var comission = new Enums();
                comission.SetComission(account.Type);
                account.Commission = comission.GetComissionValue(comission.comission);
                account.Code = Utilities.Utilities.GenerateCode();
                while (!BankAccountBL.ValidateCode(account.Code))
                {
                    account.Code = Utilities.Utilities.GenerateCode();
                }

                await BankAccountBL.Create(account);

                return RedirectToAction("Index");
            }
            catch
            {
                return View(account);
            }
        }

        public ActionResult Details(int? id)
        {
            if (id == null || !BankAccountBL.ExistsAccount(id.Value))
            {
                return RedirectToAction("Index");
            }
            BankAccount account = BankAccountBL.Details(id.Value);
            return View(account);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null || !BankAccountBL.ExistsAccount(id.Value))
            {
                return RedirectToAction("Index");
            }
            BankAccount account = BankAccountBL.Details(id.Value);
            return View(account);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(BankAccount account)
        {
            await BankAccountBL.Edit(account);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null || !BankAccountBL.ExistsAccount(id.Value))
            {
                return RedirectToAction("Index");
            }
            BankAccount account = BankAccountBL.Details(id.Value);
            return View(account);
        }

        [HttpPost]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await BankAccountBL.Delete(id);
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