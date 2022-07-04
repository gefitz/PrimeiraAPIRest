using System;
using System.ComponentModel.DataAnnotations;

namespace Dev.SistemaRH.API.Models
{
    public class VagaModel
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
        public EmpresaModel Empresa { get; set; }
    }
}
