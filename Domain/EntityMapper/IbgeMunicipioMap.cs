using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.EntityMapper
{
    public class IbgeMunicipioMap : IEntityTypeConfiguration<IbgeMunicipio>
    {
        public void Configure(EntityTypeBuilder<IbgeMunicipio> builder)
        {
            builder.HasKey(x => x.id)
                .HasName("pk_IbgeId");

            builder.Property(x => x.id)
                .HasColumnName("id");

            builder.Property(x => x.nome)
                .HasColumnName("nome")
                .IsRequired();

            builder.Property(x => x.DateCreated)
                .HasColumnName("dateCreated")
                .HasColumnType("datetime")
                .IsRequired();

            builder.Property(x => x.IsActive)
                .HasColumnName("isActive")
                .HasColumnType("bit")
                .IsRequired();
        }
    }
}
