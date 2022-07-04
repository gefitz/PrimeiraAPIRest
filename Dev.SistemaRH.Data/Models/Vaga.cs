using System;
using System.ComponentModel.DataAnnotations;

namespace Dev.SistemaRH.Data.Models
{
    public class Vaga
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Nome { get; set; }
        [Required]
        public string Conhecimento { get; set; }
        [Required]
        public string Descricao { get; set; }
        public int EmpresaId { get; set; }
    }
}
