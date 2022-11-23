using System.ComponentModel.DataAnnotations;

namespace Empresas.Services.Models
{
    /// <summary>
    /// Modelo de dados para o serviço de edição de empresas
    /// </summary>
    public class EmpresasPutModel
    {
        [Required(ErrorMessage = "Por favor, informe o id da empresa.")]
        public Guid IdEmpresa { get; set; }

        [MinLength(6, ErrorMessage = "Informe no mínimo {1} caracteres.")]
        [MaxLength(150, ErrorMessage = "Informe no máximo {1} caracteres.")]
        [Required(ErrorMessage = "Por favor, informe o nome fantasia da empresa.")]
        public string NomeFantasia { get; set; }
    }
}