using Domain.Models;
using Repository.RepositoryPattern;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Service.UserService
{
    public class UserService : IUserService
    {
        private IRepository<User> _context;

        public UserService(IRepository<User> context)
        {
            _context = context;
        }
        public void CreateUser(User user)
        {
            _context.Insert(user);
        }

        public User GetUser(Expression<Func<User, bool>> expression)
        {
            return _context.Get(expression).FirstOrDefault();
        }
    }
}
