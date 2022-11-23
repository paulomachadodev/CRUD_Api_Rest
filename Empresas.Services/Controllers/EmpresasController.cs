using Empresas.Data.Entities;
using Empresas.Data.Repositories;
using Empresas.Services.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Empresas.Services.Controllers
{
    [Route("api/[controller]")] //ENDPOINT (endereço)
    [ApiController]
    public class EmpresasController : ControllerBase
    {
        //Método para cadastro de empresas na API
        [HttpPost]
        public IActionResult Post(EmpresasPostModel model)
        {
            try
            {
                var empresaRepository = new EmpresaRepository();

                //Verificar se a razão social informada já está cadastrada
                if (empresaRepository.GetByRazaoSocial(model.RazaoSocial) != null)
                    return StatusCode(400, new { mensagem = "A razão social informada já está cadastrada no sistema." });

                //Verificar se o cnpj informado já está cadastrado
                if (empresaRepository.GetByCnpj(model.Cnpj) != null)
                    return StatusCode(400, new { mensagem = "O CNPJ informado já está cadastrado no sistema." });

                var empresa = new Empresa
                {
                    IdEmpresa = Guid.NewGuid(),
                    NomeFantasia = model.NomeFantasia,
                    RazaoSocial = model.RazaoSocial,
                    Cnpj = model.Cnpj,
                    DataHoraCadastro = DateTime.Now,
                };

                //Inserindo no banco de dados
                empresaRepository.Create(empresa);

                //retornando status de sucesso CREATED (201)
                return StatusCode(201, new { mensagem = "Empresa cadastrada com sucesso.", empresa });
            }
            catch (Exception e)
            {
                //retornando status de erro do servidor (500 - INTERNAL SERVER ERROR)
                return StatusCode(500, new { mensagem = $"Falha ao cadastrar empresa: {e.Message}" });
            }
        }

        //Método para edição de empresas na API
        [HttpPut]
        public IActionResult Put(EmpresasPutModel model)
        {
            try
            {
                var empresaRepository = new EmpresaRepository();

                //buscar a empresa no banco de dados através do ID
                var empresa = empresaRepository.GetById(model.IdEmpresa);

                //verificar se a empresa não foi encontrada
                if (empresa == null)
                    return StatusCode(400, new { mensagem = "Empresa não encontrada, verifique o ID informado." });

                //atualizando os dados da empresa
                empresa.NomeFantasia = model.NomeFantasia;

                empresaRepository.Update(empresa);

                //retornando status de sucesso OK (200)
                return StatusCode(200, new { mensagem = "Empresa atualizada com sucesso.", empresa });
            }
            catch (Exception e)
            {
                //retornando status de erro do servidor (500 - INTERNAL SERVER ERROR)
                return StatusCode(500, new { mensagem = $"Falha ao atualizar empresa: {e.Message}" });
            }
        }

        //Método para exclusão de empresas na API
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var empresaRepository = new EmpresaRepository();

                //buscar a empresa no banco de dados através do ID
                var empresa = empresaRepository.GetById(id);

                //verificar se a empresa não foi encontrada
                if (empresa == null)
                    return StatusCode(400, new { mensagem = "Empresa não encontrada, verifique o ID informado." });

                //excluindo a empresa
                empresaRepository.Delete(empresa);

                //retornando status de sucesso OK (200)
                return StatusCode(200, new { mensagem = "Empresa excluída com sucesso.", empresa });
            }
            catch (Exception e)
            {
                //retornando status de erro do servidor (500 - INTERNAL SERVER ERROR)
                return StatusCode(500, new { mensagem = $"Falha ao excluir empresa: {e.Message}" });
            }
        }

        //Método para consultar todas as empresas na API
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<EmpresasGetModel>))]
        public IActionResult GetAll()
        {
            try
            {
                var empresaRepository = new EmpresaRepository();

                var model = new List<EmpresasGetModel>();

                //consultando todas as empresas no banco de dados
                foreach (var item in empresaRepository.GetAll())
                {
                    model.Add(new EmpresasGetModel
                    {
                        IdEmpresa = item.IdEmpresa,
                        NomeFantasia = item.NomeFantasia,
                        RazaoSocial = item.RazaoSocial,
                        Cnpj = item.Cnpj,
                        DataHoraCadastro = item.DataHoraCadastro
                    });
                }

                //retornando status de sucesso OK (200)
                return StatusCode(200, model);
            }
            catch (Exception e)
            {
                //retornando status de erro do servidor (500 - INTERNAL SERVER ERROR)
                return StatusCode(500, new { mensagem = $"Falha ao consultar empresas: {e.Message}" });
            }
        }

        //Método para consultar 1 empresa baseado no ID
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(EmpresasGetModel))]
        public IActionResult GetById(Guid id)
        {
            try
            {
                var empresaRepository = new EmpresaRepository();

                //buscar a empresa no banco de dados através do id
                var empresa = empresaRepository.GetById(id);

                //verificar se a empresa não foi encontrada
                if (empresa == null)
                    return StatusCode(204); //HTTP 204 - NO CONTENT (vazio)

                var model = new EmpresasGetModel
                {
                    IdEmpresa = empresa.IdEmpresa,
                    NomeFantasia = empresa.NomeFantasia,
                    RazaoSocial = empresa.RazaoSocial,
                    Cnpj = empresa.Cnpj,
                    DataHoraCadastro = empresa.DataHoraCadastro
                };

                //retornando status de sucesso OK (200)
                return StatusCode(200, model);
            }
            catch (Exception e)
            {
                //retornando status de erro do servidor (500 - INTERNAL SERVER ERROR)
                return StatusCode(500, new { mensagem = $"Falha ao obter empresa: {e.Message}" });
            }
        }
    }
}



