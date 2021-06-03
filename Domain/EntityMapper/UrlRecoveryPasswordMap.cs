using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.EntityMapper
{
    public class UrlRecoveryPasswordMap : IEntityTypeConfiguration<UrlRecoveryPassword>
    {
        public void Configure(EntityTypeBuilder<UrlRecoveryPassword> builder)
        {
            builder.HasKey(x => x.id)
                .HasName("pk_urlRecovery");
            builder.Property(x => x.id)
                .HasColumnName("id");

            builder.Property(x => x.DateCreated)
                .HasColumnName("dateCreated")
                .HasColumnType("datetime")
                .IsRequired();

            builder.Property(x => x.IsActive)
                .HasColumnName("isActive")
                .HasColumnType("bit")
                .IsRequired();

            builder.Property(x => x.UserId)
                .HasColumnName("user_id")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(x => x.Guild)
                .HasColumnName("guild")
                .HasColumnType("NVARCHAR(100)")
                .IsRequired();
        }
    }
}
