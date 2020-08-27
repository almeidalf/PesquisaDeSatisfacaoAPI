using Microsoft.AspNetCore.Http;
using PesquisaAPI.DB;
using PesquisaAPI.Models;
using PesquisaAPI.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PesquisaAPI.Repository
{
    public class TiposRespostasRepository : ITiposRespostas
    {
        private readonly PesquisaSatisfacaoContext _banco;
        public TiposRespostasRepository(PesquisaSatisfacaoContext banco)
        {
            _banco = banco;
        }
        public Task<HttpResponse> Atualizar(int id, Respostas resposta)
        {
            _banco.Respostas.Update(resposta);
            return null;
        }

        public List<Respostas> BuscarTodos()
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponse> Cadastrar(Respostas resposta)
        {
            throw new NotImplementedException();
        }

        public void Excluir(int id)
        {
            throw new NotImplementedException();
        }
    }
}
