using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.WebUI.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ViewResult About()
        {
            return View();
        }

        public ViewResult Contacts()
        {
            return View();
        }
    }
}