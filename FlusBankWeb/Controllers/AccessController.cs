using BusinessFlus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FlusBankWeb.Controllers
{
    public class AccessController : Controller
    {
        // GET: Access
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string Dni, string Password)
        {
            try
            {
                Session["User"] = AccessBL.Login(Dni, Password);
                Session["DNI"] = Dni;
                Session["Rol"] = AccessBL.GetRol(Dni);

                return RedirectToAction("../Home/Index");

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View("Login");
            }
        }

        [HttpPost]
        public ActionResult LogOut()
        {
            Session["User"] = null;
            return RedirectToAction("Login");
        }
    }
}