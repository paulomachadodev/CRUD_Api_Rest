using Empresas.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empresas.Data.Mappings
{
    /// <summary>
    /// Classe de mapeamento ORM para a entidade Empresa
    /// </summary>
    public class EmpresaMap : IEntityTypeConfiguration<Empresa>
    {
        public void Configure(EntityTypeBuilder<Empresa> builder)
        {
            //nome da tabela
            builder.ToTable("EMPRESA");

            //chave primária
            builder.HasKey(e => e.IdEmpresa);

            //mapeando o campo IdEmpresa
            builder.Property(e => e.IdEmpresa)
                .HasColumnName("IDEMPRESA");

            //mapeando o campo NomeFantasia
            builder.Property(e => e.NomeFantasia)
                .HasColumnName("NOMEFANTASIA")
                .HasMaxLength(150)
                .IsRequired();

            //mapeando o campo RazaoSocial
            builder.Property(e => e.RazaoSocial)
                .HasColumnName("RAZAOSOCIAL")
                .HasMaxLength(150)
                .IsRequired();

            //definindo o campo RazaoSocial como único
            builder.HasIndex(e => e.RazaoSocial)
                .IsUnique();

            //mapeando o campo Cnpj
            builder.Property(e => e.Cnpj)
                .HasColumnName("CNPJ")
                .HasMaxLength(25)
                .IsRequired();

            //definindo o campo Cnpj como único
            builder.HasIndex(e => e.Cnpj)
                .IsUnique();

            //mapeando o campo DataHoraCadastro
            builder.Property(e => e.DataHoraCadastro)
                .HasColumnName("DATAHORACADASTRO")
                .HasColumnType("datetime")
                .IsRequired();
        }
    }
}


