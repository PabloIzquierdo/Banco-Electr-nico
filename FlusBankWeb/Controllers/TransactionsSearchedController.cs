using BusinessFlus;
using EntityFlus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FlusBankWeb.Utilities;
using System.Web.Routing;

namespace FlusBankWeb.Controllers
{
    public class TransactionsSearchedController : Controller
    {
        // GET: TransactionsSearched
        public ActionResult Searcher()
        {
            if (Session["User"] != null)
            {
                List<BankAccount> lst = TransactionsSearchedBL.Searcher(Session["DNI"].ToString());
                TempData["Accounts"] = lst.ConvertAll(ac =>
                {
                    return new SelectListItem
                    {
                        Text = ac.Code,
                        Value = ac.Id.ToString()
                    };
                });
            }

            return View();
        }

        [HttpPost]
        public ActionResult Searcher(string DropDownListAccounts, string InitialDate, string EndDate, string Movement, string InitialAmount, string EndAmount)
        {
            List<BankAccount> lst = TransactionsSearchedBL.Searcher(Session["DNI"].ToString());
            TempData["Accounts"] = lst.ConvertAll(ac =>
            {
                return new SelectListItem()
                {
                    Text = ac.Code,
                    Value = ac.Id.ToString()
                };
            });

            try
            {
                if (DropDownListAccounts != "")
                {
                    return RedirectToAction("FilteredList", new RouteValueDictionary(new
                    {
                        Controller = "TransactionsSearched",
                        Action = "FilteredList",
                        DropDownListAccounts = DropDownListAccounts,
                        InitialDate = InitialDate,
                        EndDate = EndDate,
                        Movement = Movement,
                        InitialAmount = InitialAmount,
                        EndAmount = EndAmount
                    }));
                }
                else
                {
                    throw new Exception("Debe elegir una cuenta");
                }


            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }

        }

        [HttpGet]
        public ActionResult FilteredList(string DropDownListAccounts, string InitialDate, string EndDate, string Movement, string InitialAmount, string EndAmount)
        {
            ViewBag.Transactions = TransactionsSearchedBL.GetAllMovements(DropDownListAccounts, InitialDate, EndDate, Movement, InitialAmount, EndAmount);
            SentencesBL obj = new SentencesBL();
            ViewBag.Account = Convert.ToInt32(DropDownListAccounts);
            ViewBag.Movement = Movement;
            return View();
        }
    }
}