using Bussines.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dev.SistemaRH.Data
{
    public class Create : ICreate
    {
        private IConnection _connection;
        public Create(IConnection connection)
        {
            _connection = connection;
        }

        public async Task<bool> CreateTable(string tabela)
        {
            #region Query para criacao das tabelas
            string query = "";
            if (tabela == "Candidato")
            {
                query = "use SisRh;CREATE TABLE tbl_Candidato(" +
                    "col_Id int NOT NULL identity(1,1)," +
                    "col_cpf varchar(100)," +
                    "col_nome VARCHAR(150)," +
                    "col_email VARCHAR(100)," +
                    "col_telefone varchar(100)," +
                    "col_conhecimento VARCHAR(1000)," +
                    "col_ativo smallint," +
                    "CONSTRAINT pk_cpf PRIMARY KEY(col_Id));";
            }
            else
            {
                query = "use SisRh;CREATE TABLE tbl_Vaga(" +
                    "ID_vaga int not null increment(1,1)," +
                    "col_nome VARCHAR(150)," +
                    "col_email VARCHAR(100)," +
                    "col_descricao var(1000)" +
                    "col_conhecimento VARCHAR(1000)," +
                    "CONSTRAINT pk_ID_vaga PRIMARY KEY(col_cpf)));";
            }
            #endregion
            var banco = _connection.Open();
            SqlCommand command = new SqlCommand(query, banco);
            try
            {
                CreateUse();
                await command.ExecuteReaderAsync();
                _connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("'SisRh' já existe"))
                {
                    await command.ExecuteReaderAsync();
                    _connection.Close();
                    return true;


                }
                else
                {
                    return false;
                }


            }





        }

        public void CreateUse()
        {

            string query = "CREATE DATABASE SisRh";
            var banco = _connection.Open();
            SqlCommand command = new SqlCommand(query, banco);
            command.ExecuteReader();
            _connection.Close();
            
        }
    }
}
