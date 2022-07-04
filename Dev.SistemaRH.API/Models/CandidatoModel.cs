using System;
using System.ComponentModel.DataAnnotations;

namespace Dev.SistemaRH.API.Models
{
    public class CandidatoModel
    {
        public int? id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Nome { get; set; }
        [Required]
        
        [RegularExpression(@"\d{3}\.\d{3}\.\d{3}\-\d{2}", ErrorMessage = "CPF invalido")]
        [MaxLength(15)]
        public string CPF { get; set; }
        [Required]
        [RegularExpression(@"\(\d.\)\d*", ErrorMessage = "Numero Invalido")]
        [MaxLength(20)]
        public string  Teleone { get; set; }
        [Required]
        [RegularExpression(@"\w*\@\w*\.\w*",ErrorMessage ="Email invalido")]
        [MaxLength(100)]
        public string Email { get; set; }
        [Required]
        public string Conhecimento { get; set; }
        [DataType("dd/mm/yyyy")]
        public DateTime Nascimento { get; set; }
        public string Descricao { get; set; }
        public int Ativo { get; set; }
    }
}
