
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PesquisaAPI.DB;
using PesquisaAPI.Models;
using PesquisaAPI.Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PesquisaAPI.Repository
{
    public class PesquisaRepository : IPesquisa
    {
        private readonly PesquisaSatisfacaoContext _banco;
        public PesquisaRepository(PesquisaSatisfacaoContext banco)
        {
            _banco = banco;
        }
        public Perguntas Atualizar(Perguntas pergunta)
        {
            var idPesquisa = _banco.Pesquisa.AsNoTracking().FirstOrDefault(a => a.Id == pergunta.Id);
            if (idPesquisa != null && idPesquisa.Id == pergunta.Id)
            {
                _banco.Pesquisa.Update(pergunta);
            }
            _banco.SaveChanges();
            return pergunta;
        }

        public Perguntas Buscar(int id)
        {
            var perguntaEspecifica = _banco.Pesquisa.AsNoTracking().FirstOrDefault(a => a.Id == id);
            return perguntaEspecifica;
        }

        public List<Perguntas> BuscarTodasPerguntas()
        {
            var listaPerguntas = _banco.Pesquisa;
            return listaPerguntas.ToList();
        }

        public Perguntas Cadastrar(Perguntas pergunta)
        {
            if (pergunta != null)
            {
                _banco.Add(pergunta);
                _banco.SaveChanges();
            }
            return pergunta;

        }

        public void Excluir(int id)
        {
            var idPesquisa = _banco.Pesquisa.Find(id);
            if (idPesquisa != null)
            {
                _banco.Pesquisa.Remove(idPesquisa);
                _banco.SaveChanges();
            }
        }
    }
}
