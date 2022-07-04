using Bussines.Interfaces;
using Dev.SistemaRH.API.Convert;
using Dev.SistemaRH.API.Models;
using Dev.SistemaRH.Data;
using Dev.SistemaRH.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace Dev.SistemaRH.API.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class CandidatoController : ControllerBase
    {
        private Commando _commando;

        public CandidatoController(IConfiguration configuration)
        {
            string connection = configuration.GetConnectionString("Connection").ToString();
            _commando = new  Commando(connection);
        }

        [HttpPost]
        
        public  ActionResult<CandidatoModel> PostCandidato(Candidato candidato)
        {
            _commando.InsertTable(can,"Candidato");
            return candidato;
        }
        [HttpGet]
        public async Task<ActionResult<object>> GetCandidato()
        {
            
            object candidato = await _commando.Select("Candidato");
            return candidato;
        }
        [HttpGet("ID")]
        public async Task<ActionResult<object>> GetCandidato(int id)
        {
            object candidato = await _commando.Select(id, "Candidato");
            return candidato;
        }
        [HttpPut("ID/Coluna/Alteracao")]
        public async Task<bool> PutCandidato(int id,string coluna,string alteracao)
        {
            
           bool succes = await _commando.UpDateTable(id,coluna,alteracao, "Candidato");

            return succes;
        }
        [HttpDelete("ID")]
        public async Task<bool> DeleteCandidato(int id)
        {
            return await _commando.Delete(id, "Candidato");
        }

    }
}
