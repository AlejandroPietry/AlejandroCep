using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Domain.EntityMapper
{
    public class HtmlEmailsMap : IEntityTypeConfiguration<HtmlEmails>
    {
        public void Configure(EntityTypeBuilder<HtmlEmails> builder)
        {
            builder.HasKey(x => x.id)
                .HasName("pk_emailId");

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

            builder.Property(x => x.Html)
                .HasColumnName("html")
                .IsRequired();

            builder.Property(x => x.DescricaoHtml)
                .HasColumnName("descricao")
                .IsRequired();
        }
    }
}
