using Dev.SistemaRH.Data.Interfaces;
using Dev.SistemaRH.Data.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Helpers;

namespace Dev.SistemaRH.Data
{
    public class Commando : ICommando
    {
        private readonly Connection _connection;

        public Commando(string connection)
        {
            _connection = new Connection(connection);

        }
        #region Metodo para fazer Dele no Banco
        public async Task<bool> Delete(int id,string tabela)
        {
            string query = $"use SisRh;Delete tbl_{tabela} where col_Id = {id};";
            var banco = _connection.Open();
            try
            {
                SqlCommand command = new SqlCommand(query, banco);
                await command.ExecuteReaderAsync();
                _connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion
        #region Metodos para fazer Insert no banco
        public async void InsertTable(Candidato candidato, string tabela)
        {
            string query = $"use SisRh;INSERT INTO tbl_Candidato(col_cpf,col_nome,col_email,col_telefone,col_conhecimento,col_ativo) VALUES(" +
                $"'{candidato.CPF}'," +
                $"'{candidato.Nome}'," +
                $"'{candidato.Email}'," +
                $"'{candidato.Teleone}'," +
                $"'{candidato.Conhecimento}'," +
                $"{candidato.Ativo});";


            var banco = _connection.Open();
            try
            {
                await new Create(_connection).CreateTable(tabela);
                SqlCommand command = new SqlCommand(query, banco);
                await command.ExecuteReaderAsync();
                _connection.Close();
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Já existe um objeto com nome 'tbl_Candidato'"))
                {
                    SqlCommand command = new SqlCommand(query, banco);
                    await command.ExecuteReaderAsync();
                    _connection.Close();
                }
            }


        }

        public async void InsertTable(Vaga vaga, string tabela)
        {
            string query = $"use SisRh;INSERT INTO tbl_Vaga(col_nome,col_email,col_descricao,col_conhecimento) VALUES(" +
                $"'{vaga.Nome}'," +
                $"'{vaga.Descricao}'," +
                $"'{vaga.EmpresaId}'," +
                $"'{vaga.Descricao}'," +
                $"'{vaga.Conhecimento}');";


            var banco = _connection.Open();
            try
            {
                await new Create(_connection).CreateTable(tabela);
                SqlCommand command = new SqlCommand(query, banco);
                await command.ExecuteReaderAsync();
                _connection.Close();
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Já existe um objeto com nome 'tbl_Vaga'"))
                {
                    SqlCommand command = new SqlCommand(query, banco);
                    await command.ExecuteReaderAsync();
                    _connection.Close();
                }
            }

        }
        #endregion
        #region Metodos para fazer select do Banco
        public async Task<string> Select(string tabela)
        {
            
            string candidato = null;
            string query = $"use SisRh;Select * from tbl_{tabela}";
            var banco = _connection.Open();
            SqlCommand command = new SqlCommand(query, banco);
            try
            {
                SqlDataReader reader = await command.ExecuteReaderAsync();
                var data = new DataTable();
                data.Load(reader);
                candidato = JsonConvert.SerializeObject(data);
                
                _connection.Close();
            }
            catch (Exception ex)
            {

            }
            return candidato;
        }

        public async Task<string> Select(int? indicador, string tabela)
        {
            string candidato = "";
            string query = $"use SisRh;Select * from tbl_{tabela} where col_Id = {indicador}";
            var banco = _connection.Open();
            SqlCommand command = new SqlCommand(query, banco);
            try
            {
                SqlDataReader reader = await command.ExecuteReaderAsync();
                var data = new DataTable();
                data.Load(reader);
                candidato = JsonConvert.SerializeObject(data);
                _connection.Close();
            }
            catch (Exception ex)
            {

            }
            return candidato;
        }
        #endregion
        #region Metodo para UpDate no banco
        public async Task<bool> UpDateTable(int id,string coluna,string alteracao,string tabela)
        {
            string query = $"use SisRh;Update tbl_{tabela}  set col_{coluna} = '{alteracao}' where col_Id = {id};";
            var banco = _connection.Open();
            try
            {
                SqlCommand command = new SqlCommand(query, banco);
                await command.ExecuteReaderAsync();
                _connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }


        }
        #endregion

    }
}
