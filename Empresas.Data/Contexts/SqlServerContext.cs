using Empresas.Data.Entities;
using Empresas.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empresas.Data.Contexts
{
    /// <summary>
    /// Classe de contexto do projeto EntityFramework
    /// </summary>
    public class SqlServerContext : DbContext
    {
        /// <summary>
        /// Método para mapear a string de conexão do banco de dados
        /// </summary>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BDApiEmpresas;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        /// <summary>
        /// Método para incluirmos cada classe de mapeamento feita no projeto
        /// </summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EmpresaMap());
        }

        /// <summary>
        /// Propriedade para habilitar os métodos de CRUD do EF para a entidade
        /// </summary>
        public DbSet<Empresa> Empresa { get; set; }
    }
}