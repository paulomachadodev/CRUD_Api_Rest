using Empresas.Data.Contexts;
using Empresas.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empresas.Data.Repositories
{
    /// <summary>
    /// Classe de repositório para operações com a entidade Empresa
    /// </summary>
    public class EmpresaRepository
    {
        /// <summary>
        /// Método para inserir uma empresa no banco de dados
        /// </summary>
        public void Create(Empresa empresa)
        {
            using (var context = new SqlServerContext())
            {
                context.Entry(empresa).State = EntityState.Added;
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Método para atualizar uma empresa no banco de dados
        /// </summary>
        public void Update(Empresa empresa)
        {
            using (var context = new SqlServerContext())
            {
                context.Entry(empresa).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Método para excluir uma empresa no banco de dados
        /// </summary>
        public void Delete(Empresa empresa)
        {
            using (var context = new SqlServerContext())
            {
                context.Entry(empresa).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Método para retornar uma consulta com todas as empresas
        /// </summary>
        public List<Empresa> GetAll()
        {
            using (var context = new SqlServerContext())
            {
                return context.Empresa
                    .OrderBy(e => e.NomeFantasia)
                    .ToList();
            }
        }

        /// <summary>
        /// Método para retornar 1 empresa baseado no ID
        /// </summary>
        public Empresa? GetById(Guid idEmpresa)
        {
            using (var context = new SqlServerContext())
            {
                return context.Empresa.Find(idEmpresa);
            }
        }

        /// <summary>
        /// Método para retornar 1 empresa baseado na razão social
        /// </summary>
        public Empresa? GetByRazaoSocial(string razaoSocial)
        {
            using (var context = new SqlServerContext())
            {
                return context.Empresa
                    .FirstOrDefault(e => e.RazaoSocial.Equals(razaoSocial));
            }
        }

        /// <summary>
        /// Método para retornar 1 empresa baseado no CNPJ
        /// </summary>
        public Empresa? GetByCnpj(string cnpj)
        {
            using (var context = new SqlServerContext())
            {
                return context.Empresa
                    .FirstOrDefault(e => e.Cnpj.Equals(cnpj));
            }
        }
    }
}



