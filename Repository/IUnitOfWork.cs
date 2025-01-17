﻿using DomainModels.Entities;
using Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IUnitOfWork
    {
        IAuthenticateRepository AuthenticateRepository { get; }
        IRepository<Product> ProductRepository { get; }
        IRepository<Category> CategoryRepository { get; }
        int SaveChanges();
    }
}
