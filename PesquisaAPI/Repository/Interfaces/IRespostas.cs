using Microsoft.AspNetCore.Mvc;
using PesquisaAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace PesquisaAPI.Repository.Interfaces
{
    public interface IRespostas
    {
        HttpStatusCode Cadastrar(List<InformacoesRespostas> respostas);
    }
}
