using PesquisaAPI.Models;
using System.Collections.Generic;

namespace PesquisaAPI.Repository.Interfaces
{
    public interface IPesquisa
    {
        Perguntas Cadastrar(Perguntas pesquisa);
        Perguntas Atualizar(int id, Perguntas pesquisa);
        List<Perguntas> BuscarPesquisas();
        void Excluir(int id);
    }
}
