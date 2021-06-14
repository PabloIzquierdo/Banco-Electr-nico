using BusinessFlus;
using EntityFlus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public async Task<ActionResult> Create(User user)
        {
            try
            {
                await UsersBL.Create(user);
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(user);
            }
        }      

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null || !UsersBL.Exists(id.Value))
            {
                return RedirectToAction("Index");
            }

            User editUser = UsersBL.Details(id.Value);
            return View(editUser);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(User user)
        {
            try
            {
                if (Utilities.Utilities.IsNullOrEmpty(user.Email) && Utilities.Utilities.IsNullOrEmpty(user.PhoneNumber))
                    return View(user);

                await UsersBL.Edit(user);
                return RedirectToAction("Index");
            }
            catch
            {
                ModelState.AddModelError("", "Ocurrió un error");
                return View(user);
            }

        }

        public ActionResult Details(int? id)
        {
            if (id == null || !UsersBL.Exists(id.Value))
            {
                return RedirectToAction("Index");
            }

            return View(UsersBL.Details(id.Value));
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null || !UsersBL.Exists(id.Value))
            {
                return RedirectToAction("Index");
            }

            var user = UsersBL.Details(id.Value);
            return View(user);
        }

        [HttpPost]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await UsersBL.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                ModelState.AddModelError("", "No se pudo eliminar este usuario");
                var user = UsersBL.Details(id);
                return View(user);
            }
        }
    }
}