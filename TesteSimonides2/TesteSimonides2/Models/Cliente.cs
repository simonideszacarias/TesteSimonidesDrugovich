using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;

namespace TesteSimonides2.Models
{
    public class Cliente
    {
        [Key]
        public int Codigo { get; set; }
        public string Nome { get; set; } = string.Empty;
        public DateTime DataFundacao { get; set; }
    }
}
