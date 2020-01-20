using Shop.Domain.Abstract;
using Shop.Domain.Concrete;
using Shop.Domain.Entities;
using Shop.WebUI.Infrastructure.Abstract;
using Shop.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Shop.WebUI.Controllers
{
    public class AccountController : Controller
    {
        IAuthProvider authProvider;
        IUserRepository repo;

        public AccountController(IAuthProvider auth, IUserRepository repository)
        {
            authProvider = auth;
            repo = repository;
        }

        public ViewResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                User user = null;
                user = repo.Users.FirstOrDefault(u => u.Login == model.Login && u.Password == model.Password);

                if (user!=null)
                {
                    FormsAuthentication.SetAuthCookie(model.Login, true);
                    return RedirectToAction("List", "Ware");
                }
                else
                {
                    ModelState.AddModelError("", "Неправильный логин или пароль");
                    return View();
                }                               
            }
            return View(model);
        }
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                //FormsAuthentication.SignOut();
                User user = null;
                //EFDbContext context = new EFDbContext();
                user = repo.Users.FirstOrDefault(u => u.Login == model.Login);
                if (user == null)
                {
                    //context.Users.Add(new User { FirstName = model.FirstName, SecondName = model.SecondName, LastName = model.LastName, Login = model.Login, Password = model.Password });
                    //context.SaveChanges();
                    user = new User
                    {
                        FirstName = model.FirstName,
                        SecondName = model.SecondName,
                        LastName = model.LastName,
                        Login = model.Login,
                        Password = model.Password,
                        RoleId = 2
                        
                    };
                    repo.SaveUser(user);
                    user = repo.Users.Where(u => u.Login == model.Login && u.Password == model.Password).FirstOrDefault();

                    if (user != null)
                    {
                        FormsAuthentication.SetAuthCookie(model.Login, true);
                        return RedirectToAction("List", "Ware");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Користувач існує!");
                }
            }
            return View(model);
        }
        
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            //FormsAuthentication.RedirectToLoginPage();
            return RedirectToAction("Login", "Account");
        }
    }
}
/*protected void SignOut_Click(object sender, EventArgs e)
{
        FormsAuthentication.SignOut();
        FormsAuthentication.RedirectToLoginPage();
}*/