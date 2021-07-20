using DomainModels.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using UI.Security;

namespace UI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            UnityConfig.RegisterComponents();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
        protected void Application_PostAuthenticateRequest(object sender, EventArgs e)
        {
            HttpCookie authcookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authcookie != null)
            {
                FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authcookie.Value);
                if (!ticket.Expired)
                {
                    UserViewModel model = JsonConvert.DeserializeObject<UserViewModel>(ticket.UserData);
                    CustomPrinciple user = new CustomPrinciple(model.Username);
                    user.UserId = model.UserId;
                    user.Username = model.Username;
                    user.Name = model.Name;
                    user.Roles = model.Roles;
                    user.ContactNo = model.ContactNo;
                    HttpContext.Current.User = user;

                }
                else
                {
                    FormsAuthentication.SignOut();
                    Response.Redirect("~/Account/Login");
                }
            }
        }
    }
}
