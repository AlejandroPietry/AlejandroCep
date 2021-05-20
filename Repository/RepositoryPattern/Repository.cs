using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Repository.DbContextFolder;
using System.Linq;

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

        public T Get(int id)
        {
            return _entity.SingleOrDefault(x => x.Id == id);
        }

        public void Insert(T entity)
        {
            _entity.Add(entity);
            _dbContext.SaveChanges();
        }
    }
}
