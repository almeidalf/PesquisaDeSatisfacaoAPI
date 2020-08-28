using Microsoft.AspNetCore.Mvc;
using PesquisaAPI.Models;
using PesquisaAPI.Repository.Interfaces;
using System;

namespace PesquisaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TiposDeRespostasController : ControllerBase
    {
        private readonly ITiposRespostas _tiposRespostasRepository;
        public TiposDeRespostasController(ITiposRespostas tiposRespostasRepository)
        {
            _tiposRespostasRepository = tiposRespostasRepository;
        }

        [HttpPost]
        public ActionResult Cadastrar([FromBody] Respostas tipoRes)
        {
            if (tipoRes == null)
            {
                return BadRequest();
            }
            else
            {
                var retorno = _tiposRespostasRepository.Cadastrar(tipoRes);
                return Ok(retorno);
            }
        }

        [HttpGet]
        public ActionResult BuscarTodosTiposRespostas()
        {
            return Ok(_tiposRespostasRepository.BuscarTodosTiposDeRespostas());
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult TipoRespostaEspecifica(int id)
        {
            return Ok(_tiposRespostasRepository.TipoRespostaEspecifica(id));
        }

        [HttpPut]
        [Route("{id}")]
        public ActionResult AtualizarTipoResposta(int id,[FromBody] Respostas tipoRes)
        {
            if(tipoRes != null)
            {
                tipoRes.Id = id;
                return Ok(_tiposRespostasRepository.Atualizar(tipoRes));
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public void ExcluirResposta(int id)
        {
            _tiposRespostasRepository.Excluir(id);
        }
    }
}
