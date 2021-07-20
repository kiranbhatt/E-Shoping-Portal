using DomainModels.Entities;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Service.Controllers
{
    public class StoreController : ApiController
    {
        IUnitOfWork uow = new UnitOfWork();
        public IEnumerable<Product> GetProducts()
        {
            return uow.ProductRepository.GetAll();
        }
    }
}
