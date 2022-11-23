using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empresas.Data.Entities
{
    public class Empresa
    {
        #region Propriedades

        public Guid IdEmpresa { get; set; }
        public string NomeFantasia { get; set; }
        public string RazaoSocial { get; set; }
        public string Cnpj { get; set; }
        public DateTime DataHoraCadastro { get; set; }

        #endregion
    }
}
