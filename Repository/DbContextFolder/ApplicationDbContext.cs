using Domain.EntityMapper;
using Microsoft.EntityFrameworkCore;

namespace Repository.DbContextFolder
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new IbgeMunicipioMap());
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new UrlRecoveryPasswordMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
