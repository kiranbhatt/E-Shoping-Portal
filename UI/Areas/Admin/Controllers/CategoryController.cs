using DomainModels.Entities;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.Areas.Admin.Controllers
{
    public class CategoryController : BaseController
    {

        public CategoryController(IUnitOfWork _uow) : base(_uow)
        {

        }
        // GET: Admin/Category
        public ActionResult Index()
        {
            IEnumerable<Category> data = uow.CategoryRepository.GetAll();
            return View(data);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Category model)
        {
            try
            {
                uow.CategoryRepository.Add(model);
                uow.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                return View();
            }

        }
    }
}