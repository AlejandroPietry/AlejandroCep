using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository.DbContextFolder
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<IbgeMunicipio> ibgeMunicipios { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
    }
}
