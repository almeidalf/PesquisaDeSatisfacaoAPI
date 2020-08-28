using Microsoft.EntityFrameworkCore;
using PesquisaAPI.DB;
using PesquisaAPI.Models;
using PesquisaAPI.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace PesquisaAPI.Repository
{
    public class TiposRespostasRepository : ITiposRespostas
    {
        private readonly PesquisaSatisfacaoContext _banco;
        public TiposRespostasRepository(PesquisaSatisfacaoContext banco)
        {
            _banco = banco;
        }
        public HttpStatusCode Atualizar(Respostas tipoResposta)
        {
            var idTipoResposta = _banco.Respostas.AsNoTracking().FirstOrDefault(a => a.Id == tipoResposta.Id);
            if (idTipoResposta != null)
            {
                _banco.Respostas.Update(tipoResposta);
                _banco.SaveChanges();
                return HttpStatusCode.OK;
            }
            else
            {
                return HttpStatusCode.NotFound;
            }
        }

        public List<Respostas> BuscarTodosTiposDeRespostas()
        {
            var todosTiposRespostas = _banco.Respostas;
            if (todosTiposRespostas != null)
            {
                return todosTiposRespostas.ToList();
            }
            else
            {
                return new List<Respostas>();
            }
        }

        public HttpStatusCode Cadastrar(Respostas tipoResposta)
        {
            _banco.Add(tipoResposta);
            _banco.SaveChanges();
            return HttpStatusCode.OK;
        }

        public void Excluir(int id)
        {
            var idTipoResposta = _banco.Respostas.AsNoTracking().FirstOrDefault(a => a.Id == id);
            if (idTipoResposta != null)
            {
                _banco.Respostas.Remove(idTipoResposta);
                _banco.SaveChanges();
            }
        }

        public Respostas TipoRespostaEspecifica(int id)
        {
            var existeTipoResposta = _banco.Respostas.AsNoTracking().FirstOrDefault(a => a.Id == id);
            if(existeTipoResposta != null)
            {
                return existeTipoResposta;
            }
            else
            {
                return new Respostas();
            }
        }
    }
}
