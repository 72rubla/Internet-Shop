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
    [Authorize]
    public class UserController : Controller
    {
        private IUserRepository repos;
        IOrderRepository orderrepos;
        IOrderWaresRepository orderWaresRepository;
        public UserController(IUserRepository repos, IOrderRepository orderrepos, IOrderWaresRepository orderWaresRepository)
        {
            this.repos = repos;
            this.orderrepos = orderrepos;
            this.orderWaresRepository = orderWaresRepository;
        }        
        public ViewResult Index()
        {
            ViewBag.Name = User.Identity.Name;
            return View();
        }

        public ActionResult GetOrders()
        {
            string curentUser = User.Identity.Name;
            History model = new History
            {
                Orders = orderrepos.Orders.Where(u => u.User1 == curentUser),
                OrderWares = orderWaresRepository.OrderWares
            };
            return View(model);
        }
    }
}