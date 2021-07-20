﻿using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UI.Security;

namespace UI.Areas.User.Controllers
{
    [CustomAuthenticationFilter]
    [CustomAuthorizationFilter(Roles = "User")]
    public class BaseController : Controller
    {
        public CustomPrinciple CurrentUser
        {
            get
            {
                return HttpContext.User as CustomPrinciple;
            }
        }
        protected IUnitOfWork uow;
        public BaseController(IUnitOfWork _uow)
        {
            uow = _uow;
        }
    }
}