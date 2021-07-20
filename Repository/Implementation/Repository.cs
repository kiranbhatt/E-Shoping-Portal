using Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Implementation
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected DbContext db;
        public Repository(DbContext _db)
        {
            db = _db;
        }
        public void Add(T entity)
        {
            db.Set<T>().Add(entity);
        }

        public void DeleteById(object Id)
        {
            var entity = db.Set<T>().Find(Id);
            if (entity != null)
            {
                db.Set<T>().Remove(entity);
            }
        }

        public IEnumerable<T> GetAll()
        {
            return db.Set<T>().ToList();
        }

        public T GetById(object Id)
        {
            return db.Set<T>().Find(Id);
        }

        public void Update(T entity)
        {
            db.Entry<T>(entity).State = EntityState.Modified;
        }
    }
}
