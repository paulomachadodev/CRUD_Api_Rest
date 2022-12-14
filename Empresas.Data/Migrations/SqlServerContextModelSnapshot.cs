// <auto-generated />
using System;
using Empresas.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Empresas.Data.Migrations
{
    [DbContext(typeof(SqlServerContext))]
    partial class SqlServerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Empresas.Data.Entities.Empresa", b =>
                {
                    b.Property<Guid>("IdEmpresa")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("IDEMPRESA");

                    b.Property<string>("Cnpj")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)")
                        .HasColumnName("CNPJ");

                    b.Property<DateTime>("DataHoraCadastro")
                        .HasColumnType("datetime")
                        .HasColumnName("DATAHORACADASTRO");

                    b.Property<string>("NomeFantasia")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)")
                        .HasColumnName("NOMEFANTASIA");

                    b.Property<string>("RazaoSocial")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)")
                        .HasColumnName("RAZAOSOCIAL");

                    b.HasKey("IdEmpresa");

                    b.HasIndex("Cnpj")
                        .IsUnique();

                    b.HasIndex("RazaoSocial")
                        .IsUnique();

                    b.ToTable("EMPRESA", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
