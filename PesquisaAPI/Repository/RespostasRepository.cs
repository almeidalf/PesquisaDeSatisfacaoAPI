using PesquisaAPI.DB;
using PesquisaAPI.Models;
using PesquisaAPI.Repository.Interfaces;
using System.Collections.Generic;
using System.Net;

namespace PesquisaAPI.Repository
{
    public class RespostasRepository : IRespostas
    {
        private readonly PesquisaSatisfacaoContext _banco;
        public RespostasRepository(PesquisaSatisfacaoContext banco)
        {
            _banco = banco;
        }
        public HttpStatusCode Cadastrar(List<InformacoesRespostas> conteudoRespostas)
        {
            {
                foreach (var resp in conteudoRespostas)
                {
                    _banco.Informacoes.Add(resp);
                }
                _banco.SaveChanges();
                return HttpStatusCode.OK;
            }
        }
    }
}
