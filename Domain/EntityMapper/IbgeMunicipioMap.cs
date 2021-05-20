using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.EntityMapper
{
    public class IbgeMunicipioMap : IEntityTypeConfiguration<IbgeMunicipio>
    {
        public void Configure(EntityTypeBuilder<IbgeMunicipio> builder)
        {
            builder.Property(x => x.Id)
                .HasColumnName("id");

            builder.Property(x => x.nome)
                .HasColumnName("nome");

            builder.Property(x => x.DateCreated)
                .HasColumnName("datecreated")
                .HasColumnType("datetime");

            builder.Property(x => x.IsActive)
                .HasColumnName("isActive")
                .HasColumnType("bit");
        }
    }
}
