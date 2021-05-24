using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.EntityMapper
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id)
                .HasName("pk_user");

            builder.Property(x => x.Id)
                .HasColumnName("id");

            builder.Property(x => x.DateCreated)
                .HasColumnName("dateCreated")
                .HasColumnType("datetime")
                .IsRequired();

            builder.Property(x => x.IsActive)
                .HasColumnName("isActive")
                .HasColumnType("bit")
                .IsRequired();

            builder.Property(x => x.Password)
                .HasColumnName("password")
                .HasColumnType("text")
                .IsRequired();

            builder.Property(x => x.Role)
                .HasColumnName("role")
                .HasColumnType("NVARCHAR(50)")
                .IsRequired();

            builder.Property(x => x.UserName)
                .HasColumnName("username")
                .HasColumnType("NVARCHAR(200)")
                .IsRequired();
        }
    }
}
