// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Repository.DbContextFolder;

namespace Repository.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.5");

            modelBuilder.Entity("Domain.Models.HtmlEmails", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime")
                        .HasColumnName("dateCreated");

                    b.Property<string>("DescricaoHtml")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("descricao");

                    b.Property<string>("Html")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("html");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit")
                        .HasColumnName("isActive");

                    b.Property<int>("TypeEmail")
                        .HasColumnType("INTEGER");

                    b.HasKey("id")
                        .HasName("pk_emailId");

                    b.ToTable("HtmlEmails");
                });

            modelBuilder.Entity("Domain.Models.IbgeMunicipio", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime")
                        .HasColumnName("dateCreated");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit")
                        .HasColumnName("isActive");

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("nome");

                    b.HasKey("id")
                        .HasName("pk_IbgeId");

                    b.ToTable("IbgeMunicipio");
                });

            modelBuilder.Entity("Domain.Models.UrlRecoveryPassword", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime")
                        .HasColumnName("dateCreated");

                    b.Property<string>("Guild")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(100)")
                        .HasColumnName("guild");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit")
                        .HasColumnName("isActive");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("user_id");

                    b.HasKey("id")
                        .HasName("pk_urlRecovery");

                    b.ToTable("UrlRecoveryPassword");
                });

            modelBuilder.Entity("Domain.Models.User", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime")
                        .HasColumnName("dateCreated");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(200)")
                        .HasColumnName("email");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit")
                        .HasColumnName("isActive");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("password");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(50)")
                        .HasColumnName("role");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(200)")
                        .HasColumnName("username");

                    b.HasKey("id")
                        .HasName("pk_user");

                    b.ToTable("User");
                });
#pragma warning restore 612, 618
        }
    }
}
