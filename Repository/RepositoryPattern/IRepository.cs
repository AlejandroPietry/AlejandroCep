using Domain.Models;

namespace Repository.RepositoryPattern
{
    public interface IRepository<T> where T : BaseEntity
    {
        T Get(int id);
        void Insert(T entity);
    }
}
