using DomainModels.ViewModels;
using Newtonsoft.Json;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace UI.Controllers
{
    public class AccountController : BaseController
    {

        public AccountController(IUnitOfWork _uow) : base(_uow)
        {

        }
        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Login");
        }


        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                UserViewModel user = uow.AuthenticateRepository.ValidateUser(model);
                if (user != null)
                {
                    string data = JsonConvert.SerializeObject(user);
                    FormsAuthenticationTicket ticket =
                        new FormsAuthenticationTicket
                        (1, model.Username, DateTime.Now, DateTime.Now.AddMinutes(20), false, data);
                    string encTicket = FormsAuthentication.Encrypt(ticket);
                    HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);
                    Response.Cookies.Add(cookie);
                    if (user.Roles.Contains("Admin"))
                    {
                        return RedirectToAction("Index", "Home", new { area = "Admin" });
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home", new { area = "User" });

                    }
                }
            }
            return View();
        }


        public ActionResult SignUp()
        {
            return View();
        }


        public ActionResult UnAuthorize()
        {
            return View();
        }

    }
}