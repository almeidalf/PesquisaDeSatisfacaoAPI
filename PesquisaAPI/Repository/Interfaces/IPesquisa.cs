using PesquisaAPI.Models;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace PesquisaAPI.Repository.Interfaces
{
    public interface IPesquisa
    {
        Perguntas Cadastrar(Perguntas pergunta);
        Perguntas Atualizar(Perguntas pergunta);
        Perguntas Buscar(int id);
        List<Perguntas> BuscarTodasPerguntas();
        void Excluir(int id);
    }
}
