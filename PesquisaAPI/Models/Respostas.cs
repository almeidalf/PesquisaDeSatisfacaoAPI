using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PesquisaAPI.Models
{
    public class Respostas
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "varchar(3500)")]
        public string Resposta { get; set; }
        [Column(TypeName = "varchar(25)")]
        [MaxLength(25)]
        public string TipoCampo { get; set; }
        public ICollection<InformacoesRespostas> Informacoes { get; set; }
    }
}
