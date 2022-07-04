using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Dev.SistemaRH.Data.Models
{
    public class Empresa
    {
        [Required]
        [Key]
        [RegularExpression(@"\d{2}\.\d{3}.\d{3}\/\d{4}-\d{1}",ErrorMessage ="CNPJ Invalido")]
        [MaxLength(15)]
        public string CNPJ { get; set; }
        [Required]
        [MaxLength(150)]
        public string Nome { get; set; }
        
        public string Descricao { get; set; }
        [Required]
        [RegularExpression(@"\(\d.\)\d*", ErrorMessage = "Numero Invalido")]
        [MaxLength(12)]
        public string Telefone { get; set; }
        [Required]
        [RegularExpression(@"\w *\@\w *\.\w *", ErrorMessage = "Email invalido")]
        [MaxLength(100)]
        public string Email { get; set; }

        public IEnumerable<Vaga> Vagas { get; set; }
    }
}
