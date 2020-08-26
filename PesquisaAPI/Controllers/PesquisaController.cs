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
        public ActionResult Cadastrar([FromBody] Perguntas pesquisa)
        {
            if (pesquisa == null) return BadRequest();
            return Ok(_pesquisaRepository.Cadastrar(pesquisa));
        }
        [HttpGet]
        public ActionResult BuscarPesquisas()
        {
            return Ok(_pesquisaRepository.BuscarPesquisas());
        }

        [HttpPut]
        [Route("{id}")]
        public ActionResult Atualizar(int id,[FromBody] Perguntas pesquisa)
        {
            if (pesquisa == null) return BadRequest();
            return Ok(_pesquisaRepository.Atualizar(id, pesquisa));
        }

        [HttpDelete]
        [Route("{id}")]
        public void Excluir(int id)
        {
            _pesquisaRepository.Excluir(id);
        }
    }
}
