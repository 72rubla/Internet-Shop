using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.Domain.Abstract;
using Shop.Domain.Entities;
using Shop.WebUI.Models;

namespace Shop.WebUI.Controllers
{
    public class WareController : Controller
    {
        private IWareRepository repos;
        public int pageSize = 6;
        public WareController(IWareRepository repos)
        {
            this.repos = repos;
        }

        public ActionResult List(string category, int page = 1)
        {
            WaresListViewModel model = new WaresListViewModel
            {
                Wares = repos.Wares
            .Where(p => category == null || p.Category == category)
            .OrderBy(game => game.ID)
            .Skip((page - 1) * pageSize)
            .Take(pageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = category == null ?
        repos.Wares.Count() :
        repos.Wares.Where(game => game.Category == category).Count()
                },
                CurrentCategory = category
            };
            return View(model);
        }

        public ActionResult GetCurentWare(int Id)
        {
            Ware ware = repos.Wares.FirstOrDefault(w => w.ID == Id);

            return View(ware); 
        }
        public FileContentResult GetImage(int Id)
        {
            Ware ware = repos.Wares
                .FirstOrDefault(g => g.ID == Id);

            if (ware != null)
            {
                return File(ware.ImageData, ware.ImageMimeType);
            }
            else
            {
                return null;
            }
        }
    }
}