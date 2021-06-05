using BusinessFlus;
using EntityFlus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FlusBankWeb.Controllers
{
    public class UsersController : Controller
    {
        // GET: Users
        public ActionResult Index()
        {
            return View(UsersBL.UserList());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(User user)
        {
            try
            {
                UsersBL.Create(user);
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(user);
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            User editUser = UsersBL.Details(id);
            return View(editUser);
        }

        [HttpPost]
        public ActionResult Edit(User user)
        {
            try
            {
                if (Utilities.Utilities.IsNullOrEmpty(user.Email) && Utilities.Utilities.IsNullOrEmpty(user.PhoneNumber))
                    return View(user);

                UsersBL.Edit(user);
                return RedirectToAction("Index");
            }
            catch
            {
                ModelState.AddModelError("", "Ocurrió un error");
                return View(user);
            }

        }

        public ActionResult Details(int id)
        {
            return View(UsersBL.Details(id));
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                ModelState.AddModelError("", "Se necesita seleccionar un usuario");
                return RedirectToAction("Index");
            }
            var user = UsersBL.Details(id.Value);
            return View(user);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                UsersBL.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                ModelState.AddModelError("", "No se pudo eliminar este usuario");
                return View();
            }
        }
    }
}