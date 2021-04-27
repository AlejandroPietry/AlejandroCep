using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository.DbContextFolder
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<IbgeMunicipio> ibgeMunicipios { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<LogLogin> Logs_Login { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
    }
}
