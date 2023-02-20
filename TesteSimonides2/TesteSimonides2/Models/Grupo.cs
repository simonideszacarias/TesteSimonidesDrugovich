using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TesteSimonides2.Models
{
    public class Grupo
    {
        [Key]
        public int Codigo { get; set; }
        public string Nome { get; set; } = string.Empty;

    }
}
