namespace Empresas.Services.Models
{
    /// <summary>
    /// Modelo de dados para consulta de empresas
    /// </summary>
    public class EmpresasGetModel
    {
        public Guid IdEmpresa { get; set; }
        public string NomeFantasia { get; set; }
        public string RazaoSocial { get; set; }
        public string Cnpj { get; set; }
        public DateTime DataHoraCadastro { get; set; }
    }
}
