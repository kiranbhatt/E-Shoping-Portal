using ApplicationCore;
using DomainModels.Entities;
using Repository.Abstraction;
using Repository.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        DatabaseContext db;
        public UnitOfWork()
        {
            db = new DatabaseContext();
        }

        private IAuthenticateRepository _AuthenticateRepository;

        public IAuthenticateRepository AuthenticateRepository
        {
            get
            {
                if (_AuthenticateRepository == null)
                {
                    _AuthenticateRepository = new AuthenticateRepository(db);
                }
                return _AuthenticateRepository;
            }

        }
        private IRepository<Category> _CategoryRepository;

        public IRepository<Category> CategoryRepository
        {
            get
            {
                if (_CategoryRepository == null)
                {
                    _CategoryRepository = new Repository<Category>(db);
                }
                return _CategoryRepository;
            }

        }
        private IRepository<Product> _ProductRepository;

        public IRepository<Product> ProductRepository
        {
            get
            {
                if (_ProductRepository == null)
                {
                    _ProductRepository = new Repository<Product>(db);
                }
                return _ProductRepository;
            }

        }

        
        public int SaveChanges()
        {
            return db.SaveChanges();
        }
    }
}
