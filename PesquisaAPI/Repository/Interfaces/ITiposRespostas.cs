
using PesquisaAPI.Models;
using System.Collections.Generic;
using System.Net;


namespace PesquisaAPI.Repository.Interfaces
{
    public interface ITiposRespostas
    {
        HttpStatusCode Cadastrar(Respostas tipoResposta);
        HttpStatusCode Atualizar(Respostas tipoResposta);
        Respostas TipoRespostaEspecifica(int id);
        List<Respostas> BuscarTodosTiposDeRespostas();
        void Excluir(int id);

    }
}
