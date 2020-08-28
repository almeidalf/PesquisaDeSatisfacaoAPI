using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PesquisaAPI.Models;
using PesquisaAPI.Repository.Interfaces;

namespace PesquisaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PesquisaController : ControllerBase
    {
        private readonly IPesquisa _pesquisaRepository;
        public PesquisaController(IPesquisa pesquisaRepository)
        {
            _pesquisaRepository = pesquisaRepository;
        }

        [HttpPost]
        public ActionResult Cadastrar([FromBody] Perguntas pergunta)
        {
            if (pergunta == null) return BadRequest();
            return Ok(_pesquisaRepository.Cadastrar(pergunta));
        }
        [HttpGet]
        public ActionResult BuscarTodasPerguntas()
        {
            return Ok(_pesquisaRepository.BuscarTodasPerguntas());
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult BuscarPergunta(int id)
        {
            var retorno = _pesquisaRepository.Buscar(id);
            if (retorno.Id != 0)
            {
                return Ok(retorno);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPut]
        [Route("{id}")]
        public ActionResult Atualizar(int id, [FromBody] Perguntas pergunta)
        {
            if (pergunta == null) return BadRequest();

            pergunta.Id = id;
            return Ok(_pesquisaRepository.Atualizar(pergunta));
        }

        [HttpDelete]
        [Route("{id}")]
        public void Excluir(int id)
        {
            _pesquisaRepository.Excluir(id);
        }
    }
}
