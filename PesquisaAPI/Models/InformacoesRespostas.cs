using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PesquisaAPI.Models
{
    public class InformacoesRespostas
    {
        [Key]
        public int Id { get; set; }
        public DateTime DataResposta { get; set; }
        [ForeignKey("Respostas")]
        public int RespostasId { get; set; }
        public virtual Respostas Respostas { get; set; }
        [ForeignKey("Perguntas")]
        public int PerguntasId { get; set; }
        public virtual Perguntas Perguntas { get; set; }
        [Column(TypeName = "varchar(3500)")]
        public string Observacoes { get; set; }
    }
}
