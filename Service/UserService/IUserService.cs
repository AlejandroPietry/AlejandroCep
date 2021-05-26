using Domain.Models;
using System;
using System.Linq.Expressions;

namespace Service.UserService
{
    public interface IUserService
    {
        User GetUser(Expression<Func<User, bool>> expression);

        void CreateUser(User user);
    }
}
