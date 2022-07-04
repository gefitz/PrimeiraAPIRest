using Dev.SistemaRH.API.Models;
using Dev.SistemaRH.Data.Models;
using System.Text.RegularExpressions;

namespace Dev.SistemaRH.API.Convert
{
    public class ConvertTo
    {
        public Candidato Model(CandidatoModel candidato)
        {
            return new Candidato
            {
                CPF = candidato.CPF,
                Nome = candidato.Nome,
                Conhecimento = candidato.Conhecimento,
                Ativo = candidato.Ativo,
                Email = candidato.Email,
                Teleone = candidato.Teleone,
                
                
            };
        }
    }
}
