using System.Linq;
using System.Web.Mvc;
using Shop.Domain.Entities;
using Shop.Domain.Abstract;
using Shop.WebUI.Models;
using System;

namespace GameStore.WebUI.Controllers
{
    public class CartController : Controller
    {
        private IWareRepository repos;
        private IOrderProcessor orderProcessor;
        private IUserRepository userrepos;
        private IOrderRepository orderrepos;
        private IOrderWaresRepository orwarrepos;
        public CartController(IWareRepository repos, IOrderProcessor orderProcessor, IUserRepository userrepos, IOrderRepository orderrepos, IOrderWaresRepository orwarrepos)
        {
            this.repos = repos;
            this.orderProcessor = orderProcessor;
            this.userrepos = userrepos;
            this.orderrepos = orderrepos;
            this.orwarrepos = orwarrepos;
        }

        public ViewResult Checkout()
        {
            return View(new ShippingDetails());
        }      

        [HttpPost]
        public ViewResult Checkout(Cart cart, ShippingDetails shippingDetails)
        {
            string userLogin = User.Identity.Name;
            User user = userrepos.Users.FirstOrDefault(u => u.Login == userLogin);
            
            if (cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Извините, ваша корзина пуста!");
            }

            if (ModelState.IsValid)
            {
                if (user != null)
                {
                    DateTime dt = DateTime.Now;
                    Order order = new Order
                    {
                        Date = dt,
                        User1 = user.Login,
                        Sum = cart.ComputeTotalValue()
                    };
                    orderrepos.SaveOrder(order);

                    OrderWare ow;

                    foreach (var item in cart.Lines)
                    {
                        ow = new OrderWare();
                        ow.OrderId = order.Id;
                        ow.UserId = user.ID;
                        ow.WareId = item.Ware.ID;
                        orwarrepos.SaveOrderWare(ow, cart);
                    }
                }
                //foreach (var item in cart.Lines)
                //{
                //    dbEntry.OrderId = orderware.OrderId;
                //    dbEntry.UserId = orderware.UserId;
                //    dbEntry.WareId = item.Ware.ID;
                //    context.SaveChanges();
                //}

                
                //orwarrepos.SaveOrderWare(ow, cart);

                orderProcessor.ProcessOrder(cart, shippingDetails);
                
                cart.Clear();
                return View("Completed");
            }
            else
            {
                return View(shippingDetails);
            }
        }

        public ViewResult Index(Cart cart, string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = cart,
                ReturnUrl = returnUrl
            });
        }

        public RedirectToRouteResult AddToCart(Cart cart, int Id, string returnUrl)
        {
            Ware ware = repos.Wares
                .FirstOrDefault(g => g.ID == Id);

            if (ware != null)
            {
                cart.AddItem(ware, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToRouteResult RemoveFromCart(Cart cart, int Id, string returnUrl)
        {
            Ware ware = repos.Wares
                .FirstOrDefault(g => g.ID == Id);

            if (ware != null)
            {
                cart.RemoveLine(ware);
            }
            return RedirectToAction("Index", new { returnUrl });
        }
        public PartialViewResult Summary(Cart cart)
        {
            return PartialView(cart);
        }       
    }
}