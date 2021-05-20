using Domain.Models;
using System.Linq.Expressions;
using System;
using System.Linq;

namespace Repository.RepositoryPattern
{
    public interface IRepository<T> where T : BaseEntity
    {
        IQueryable<T> Get(Expression<Func<T, bool>> expression);
        void Insert(T entity);
    }
}
