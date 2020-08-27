using Microsoft.AspNetCore.Http;
using PesquisaAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PesquisaAPI.Repository.Interfaces
{
    public interface ITiposRespostas
    {
        Task<HttpResponse> Cadastrar(Respostas resposta);
        Task<HttpResponse> Atualizar(int id, Respostas resposta);
        List<Respostas> BuscarTodos();
        void Excluir(int id);

    }
}
