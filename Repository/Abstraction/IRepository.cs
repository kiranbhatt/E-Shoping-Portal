using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Abstraction
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(object Id);
        void Add(T entity);
        void Update(T entity);
        void DeleteById(object Id);
    }
}
