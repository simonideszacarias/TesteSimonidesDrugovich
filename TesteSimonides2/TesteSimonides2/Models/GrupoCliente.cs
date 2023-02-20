using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TesteSimonides2.Models
{
    public class GrupoCliente
    {
        [Key]
        public int Codigo { get; set; }
        [ForeignKey("GrupoCodigo")]
        public int GrupoCodigo { get; set; }
        [ForeignKey("ClienteCodigo")]
        public int ClienteCodigo { get; set; }
    }
}
