using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussines.Interfaces
{
    public interface ICreate
    {
        public Task<bool> CreateTable(string tabela);
        public void CreateUse();

    }
}
