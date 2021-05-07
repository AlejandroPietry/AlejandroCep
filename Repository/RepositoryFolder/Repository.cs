using Domain.Models;
using Repository.DbContextFolder;
using System.Linq;

namespace Repository.RepositoryFolder
{
    public class Repository : IRepository
    {
        private readonly ApplicationDbContext context;

        public Repository(ApplicationDbContext dbContext)
        {
            context = dbContext;
        }

        public IbgeMunicipio GetMunicipioByIbge(int ibge)
        {
            return context.ibgeMunicipios.Where(x => x.id == ibge).FirstOrDefault();
        }

        public void SaveMunicipio(IbgeMunicipio ibgeMunicipio)
        {
            context.ibgeMunicipios.Add(ibgeMunicipio);
            context.SaveChanges();
        }

        public User GetUser(User user)
        {
            return context.Users.FirstOrDefault(x => x.UserName == user.UserName && x.Password == x.Password);
        }
    }
}