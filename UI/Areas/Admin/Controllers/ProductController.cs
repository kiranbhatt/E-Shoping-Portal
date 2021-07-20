using DomainModels.Entities;
using DomainModels.ViewModels;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace UI.Areas.Admin.Controllers
{
    public class ProductController : BaseController
    {
        public ProductController(IUnitOfWork _uow) : base(_uow)
        {

        }
        // GET: Admin/Product
        public ActionResult Index()
        {
            IEnumerable<Product> data = uow.ProductRepository.GetAll();
            return View(data);
        }
        public ActionResult Create()
        {
            ViewBag.Categories = uow.CategoryRepository.GetAll();
            return View();
        }
        [HttpPost]
        public ActionResult Create(ProductViewModel model)
        {
            try
            {
                string folderPath = "~/Uploads/";
                bool exists = Directory.Exists(Server.MapPath(folderPath));
                if (!exists)
                {
                    Directory.CreateDirectory(Server.MapPath(folderPath));
                }
                string fileName = Path.GetFileName(model.file.FileName);
                string path = Path.Combine(Server.MapPath(folderPath), fileName);
                model.file.SaveAs(path);
                model.ImageName = fileName;
                model.ImagePath = "/Uploads/" + fileName;
                Product product = new Product();
                product.ProductId = model.ProductId;
                product.Name = model.Name;
                product.UnitPrice = model.UnitPrice;
                product.CategoryId = model.CategoryId;
                product.Description = model.Description;
                product.ImageName = model.ImageName;
                product.ImagePath = model.ImagePath;
                uow.ProductRepository.Add(product);
                uow.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

            }
            ViewBag.Categories = uow.CategoryRepository.GetAll();
            return View();
        }
    }
}