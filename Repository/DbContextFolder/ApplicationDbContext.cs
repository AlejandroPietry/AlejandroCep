using Domain.EntityMapper;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository.DbContextFolder
{
    public class ApplicationDbContext : DbContext
    {
        //public DbSet<IbgeMunicipio> ibgeMunicipios { get; set; }
        //public DbSet<User> Users { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new IbgeMunicipioMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
