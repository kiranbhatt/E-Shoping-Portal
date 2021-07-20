﻿using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UI.Security;

namespace UI.Controllers
{
    public class BaseController : Controller
    {
        protected IUnitOfWork uow;
        public CustomPrinciple CurrentUser
        {
            get
            {
                return HttpContext.User as CustomPrinciple;
            }
        }
        public BaseController(IUnitOfWork _uow)
        {
            uow = _uow;
        }
    }
}