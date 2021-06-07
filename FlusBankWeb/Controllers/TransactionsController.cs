using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using BusinessFlus;
using EntityFlus;

namespace FlusBankWeb.Controllers
{
    public class TransactionsController : Controller
    {
        // GET: Transactions
        public ActionResult Index()
        {
            return View(TransactionsBL.TransactionsList());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(Transaction transaction)
        {
            try
            {
                transaction.Date = DateTime.Now.ToString();
                await TransactionsBL.Create(transaction);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(transaction);
            }
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            return View(TransactionsBL.Details(id));
        }
    }
}