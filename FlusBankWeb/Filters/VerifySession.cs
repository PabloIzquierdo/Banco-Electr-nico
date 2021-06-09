using EntityFlus;
using FlusBankWeb.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FlusBankWeb.Filters
{
    public class VerifySession : ActionFilterAttribute
    {

        private User currentUser;
        public override void OnActionExecuting (ActionExecutingContext filterContext)
        {
            try
            {
                base.OnActionExecuting(filterContext);

                currentUser = (User)HttpContext.Current.Session["User"];
                if(currentUser == null)
                {
                    if (filterContext.Controller is AccessController == false)
                        filterContext.HttpContext.Response.Redirect("/Access/Login");
                }

            }catch
            {
                filterContext.Result = new RedirectResult("~/Access/Login");
            }
        }
    }
}