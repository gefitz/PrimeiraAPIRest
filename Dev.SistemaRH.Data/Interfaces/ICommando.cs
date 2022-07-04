using Dev.SistemaRH.Data.Models;
using System.Threading.Tasks;

namespace Dev.SistemaRH.Data.Interfaces
{
    public interface ICommando
    {
        #region Select
        public Task<string> Select(string tabela);
        public Task<string> Select(int? indicador, string tabela);
        #endregion
        #region UpdateTable
        public Task<bool> UpDateTable(int id, string coluna, string alteracao, string tabela);
        #endregion
        #region InsertTable
        public void InsertTable(Candidato candidato, string tabela);
        public void InsertTable(Vaga vaga, string tabela);
        #endregion
        #region delete

        public Task<bool> Delete(int id, string tabela);
        #endregion

    }

}

