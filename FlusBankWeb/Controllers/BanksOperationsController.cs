using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessFlus;
using EntityFlus;

namespace FlusBankWeb.Controllers
{
    public class BanksOperationsController : Controller
    {
        // GET: BanksOperations
        public ActionResult Index()
        {
            return View(BanksOperationsBL.BanksOperationsList());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(BanksOperation BanksOperation)
        {
            try
            {
                BanksOperationsBL.Create(BanksOperation);
                return View("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(BanksOperation);
            }
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            BanksOperation operation = BanksOperationsBL.Details(id);
            return View(operation);
        }

        [HttpPost]
        public ActionResult Edit(BanksOperation editOperation)
        {
            try
            {
                BanksOperationsBL.Edit(editOperation);
                return RedirectToAction("Index");
            }
            catch
            {
                ModelState.AddModelError("","No se pudo editar");
                return View(editOperation);
            }
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            BanksOperation operation = BanksOperationsBL.Details(id);
            return View(operation);
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                ModelState.AddModelError("", "Se necesita seleccionar una operación");
                return RedirectToAction("Index");
            }
            BanksOperation operation = BanksOperationsBL.Details(id.Value);
            return View(operation);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                BanksOperationsBL.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                ModelState.AddModelError("", "No se puedo eliminar la operación");
                return View(id);
            }
        }

    }
}