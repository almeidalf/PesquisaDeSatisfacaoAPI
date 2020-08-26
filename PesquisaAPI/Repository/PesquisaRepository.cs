
using PesquisaAPI.DB;
using PesquisaAPI.Models;
using PesquisaAPI.Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace PesquisaAPI.Repository
{
    public class PesquisaRepository : IPesquisa
    {
        private readonly PesquisaSatisfacaoContext _banco;
        public PesquisaRepository(PesquisaSatisfacaoContext banco)
        {
            _banco = banco;
        }
        public Perguntas Atualizar(int id, Perguntas pesquisa)
        {
            if (id == pesquisa.Id)
            {
                _banco.Update(pesquisa);
            }
            _banco.SaveChanges();
            return pesquisa;
        }

        public List<Perguntas> BuscarPesquisas()
        {
            var listaPesquisas = _banco.Pesquisa;
            return listaPesquisas.ToList();
        }

        public Perguntas Cadastrar(Perguntas pesquisa)
        {
            if(pesquisa != null)
            {
                _banco.Add(pesquisa);
                _banco.SaveChanges();
            }
            return pesquisa;

        }

        public void Excluir(int id)
        {
            var idPesquisa = _banco.Pesquisa.Find(id);
            if(idPesquisa != null)
                _banco.Pesquisa.Remove(idPesquisa);
                _banco.SaveChanges();
            }
        }
    }
