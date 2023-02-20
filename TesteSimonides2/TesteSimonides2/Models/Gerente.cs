using System.ComponentModel.DataAnnotations;

namespace TesteSimonides2.Models
{
    public class Gerente
    {
        [Key]
        public int Codigo { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int Nivel { get; set; }
    }
}
