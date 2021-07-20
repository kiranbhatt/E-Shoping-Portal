using ApplicationCore;
using DomainModels.Entities;
using DomainModels.ViewModels;
using Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Implementation
{
    public class AuthenticateRepository : Repository<User>, IAuthenticateRepository
    {
        private DatabaseContext context
        {
            get
            {
                return db as DatabaseContext;
            }
        }
        public AuthenticateRepository(DatabaseContext _db) : base(_db)
        {

        }
        public UserViewModel ValidateUser(LoginViewModel model)
        {
            User data = context.Users.Include("Roles").Where(u => u.Username == model.Username && u.Password == model.Password).FirstOrDefault();
            if (data != null)
            {
                UserViewModel obj = new UserViewModel
                {
                    UserId = data.UserId,
                    Username = data.Username,
                    Name = data.Name,
                    ContactNo = data.ContactNo,
                    Address = data.Address,
                    Roles = data.Roles.Select(x => x.Name).ToArray()
                };
                return obj;
            }
            else
            {
                return null;
            }
        }
    }
}
