using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Repository.DbContextFolder;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Repository.RepositoryPattern
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext _dbContext;
        private DbSet<T> _entity;

        public Repository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _entity = dbContext.Set<T>();
        }

        public T Get(Expression<Func<T, bool>> expression )
        {
            return _entity.FirstOrDefault(expression);
        }

        public void Insert(T entity)
        {
            _entity.Add(entity);
            _dbContext.SaveChanges();
        }
    }
}
