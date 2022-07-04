using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussines.Interfaces
{
    public interface IConnection
    {
        public SqlConnection Open();
        public SqlConnection Close();
    }
}
