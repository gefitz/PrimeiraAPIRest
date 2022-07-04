using Bussines.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dev.SistemaRH.Data
{
    public class Connection : IConnection
    {  
        private string _connectionString;

        public Connection(string configuration)
        {
            _connectionString = configuration.ToString();
        }

        public SqlConnection Close()
        {
            SqlConnection connection = new SqlConnection(_connectionString);

            connection.Close();
            return connection;

        }

        public SqlConnection Open()
        {
            SqlConnection connection = new SqlConnection(_connectionString);

            connection.Open();
            return connection;
        }
    }
}
