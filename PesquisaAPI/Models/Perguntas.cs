using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PesquisaAPI.Models
{
    public class Perguntas
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "varchar(500)")]
        public string Descricao { get; set; }
    }
}
