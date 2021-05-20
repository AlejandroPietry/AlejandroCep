using Domain.Models;
using System.Linq.Expressions;
using System;

namespace Repository.RepositoryPattern
{
    public interface IRepository<T> where T : BaseEntity
    {
        T Get(Expression<Func<T, bool>> expression);
        void Insert(T entity);
    }
}
