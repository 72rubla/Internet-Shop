using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.Domain.Abstract;

namespace Shop.WebUI.Controllers
{
    public class NavController : Controller
    {
        private IWareRepository repos;

        public NavController(IWareRepository repos)
        {
            this.repos = repos;
        }

        public PartialViewResult Menu(string category = null)
        {
            ViewBag.SelectedCategory = category;

            IEnumerable<string> categories = repos.Wares
                .Select(ware => ware.Category)
                .Distinct()
                .OrderBy(x => x);
            return PartialView(categories);
        }
    }
}