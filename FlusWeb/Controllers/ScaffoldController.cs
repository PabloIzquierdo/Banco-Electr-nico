using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace FlusWeb.Controllers
{
    public class ScaffoldController : Controller
    {
        //
        //GET: /Scaffold/
        public string Index()
        {
            return "This is my default action...";
        }

        //GET: /Scaffold/Welcome/
        public string Welcome(string name, int ID = 1)
        {
            return HtmlEncoder.Default.Encode($"Hello {name}, ID : {ID}");
        }
    }
}
