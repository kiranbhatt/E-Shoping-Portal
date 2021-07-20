using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.Areas.User.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(IUnitOfWork _uow) : base(_uow)
        {

        }
        // GET: User/Home
        public ActionResult Index()
        {
            int userId = CurrentUser.UserId;
            return View();
        }
    }
}