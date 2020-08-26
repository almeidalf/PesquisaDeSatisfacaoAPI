using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PesquisaAPI.Models;
using PesquisaAPI.Repository.Interfaces;

namespace PesquisaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CadastroRespostasController : ControllerBase
    {
        private readonly IRespostas _respostasRepository;
        public CadastroRespostasController(IRespostas respostasRepository)
        {
            _respostasRepository = respostasRepository;
        }

        [HttpPost]
        public ActionResult CadastroRespostas([FromBody] List<InformacoesRespostas> infoRespostas)
        {
            if (infoRespostas != null)
            {
                _respostasRepository.Cadastrar(infoRespostas);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
