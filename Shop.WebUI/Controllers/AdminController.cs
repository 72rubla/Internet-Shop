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
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        IWareRepository repos;
        IUserRepository userrepos;
        IOrderRepository orderrepos;
        IOrderWaresRepository orderWaresRepository;
        public AdminController(IWareRepository repos, IUserRepository userrepos, IOrderRepository orderrepos, IOrderWaresRepository orderWaresRepository)
        {
            this.repos = repos;
            this.userrepos = userrepos;
            this.orderrepos = orderrepos;
            this.orderWaresRepository = orderWaresRepository;
        }
        public ViewResult Index()
        {
            //return View(repos.Wares);
            return View();
        }

        public ActionResult GetWares()
        {
            return PartialView(repos.Wares);
        }
        public ActionResult GetUsers()
        {
            return PartialView(userrepos.Users);
        }

        public ActionResult GetOrders()
        {
            History model = new History
            {
                //Orders = orderrepos.Orders.Where(u => u.User1=="user"),
                Users = userrepos.Users,
                Orders = orderrepos.Orders,
                OrderWares = orderWaresRepository.OrderWares,
                Wares = repos.Wares
            };
            

            return PartialView(model);
        }

        //public ActionResult List(string category, int page = 1)
        //{
        //    WaresListViewModel model = new WaresListViewModel
        //    {
        //        Wares = repos.Wares
        //    .Where(p => category == null || p.Category == category)
        //    .OrderBy(game => game.ID)
        //    .Skip((page - 1) * pageSize)
        //    .Take(pageSize),
        //        PagingInfo = new PagingInfo
        //        {
        //            CurrentPage = page,
        //            ItemsPerPage = pageSize,
        //            TotalItems = category == null ?
        //repos.Wares.Count() :
        //repos.Wares.Where(game => game.Category == category).Count()
        //        },
        //        CurrentCategory = category
        //    };
        //    return View(model);
        //}

        public ViewResult EditWare(int Id)
        {
            Ware ware = repos.Wares
                .FirstOrDefault(g => g.ID == Id);
            return View(ware);
        }
        public ViewResult EditUser(int Id)
        {
            User user = userrepos.Users
                .FirstOrDefault(u => u.ID == Id);
                return View(user);
        }

        //[HttpPost]


        [HttpPost]
        public ActionResult EditWare(Ware ware, HttpPostedFileBase image = null)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    ware.ImageMimeType = image.ContentType;
                    ware.ImageData = new byte[image.ContentLength];
                    image.InputStream.Read(ware.ImageData, 0, image.ContentLength);
                }
                repos.SaveWare(ware);
                TempData["message"] = string.Format("Зміни в товарі \"{0}\" були збережені", ware.Name);
                return RedirectToAction("Index");
            }
            else
            {
                // Что-то не так со значениями данных
                return View(ware);
            }
        }
        [HttpPost]
        public ActionResult EditUser(User user, HttpPostedFileBase image = null)
        {            
            if (ModelState.IsValid)
            {                
                if (image != null)
                {
                    user.ImageMimeType = image.ContentType;
                    user.ImageData = new byte[image.ContentLength];
                    image.InputStream.Read(user.ImageData, 0, image.ContentLength);
                }                
                userrepos.SaveUser(user);
                TempData["message"] = string.Format("Зміни в юзері \"{0}\" були збережені", user.Login);
                return RedirectToAction("Index");
            }
            else
            {
                // Что-то не так со значениями данных
                return View(user);
            }
        }

        public ViewResult CreateWare()
        {
            return View("EditWare", new Ware());
        }
        public ViewResult CreateUser()
        {
            return View("EditUser", new User());
        }

        [HttpPost]
        public ActionResult DeleteWare(int Id)
        {
            Ware deletedWare = repos.DeleteWare(Id);
            if (deletedWare != null)
            {
                TempData["message"] = string.Format("Товар \"{0}\" був видалений",
                    deletedWare.Name);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult DeleteUser(int Id)
        {
            User deletedUser = userrepos.DeleteUser(Id);
            if (deletedUser != null)
            {
                TempData["message"] = string.Format("Користувач \"{0}\" був видалений",
                    deletedUser.Login);
            }
            return RedirectToAction("Index");
        }
    }
}