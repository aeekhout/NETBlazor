using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorCurso.Data
{
    public class SqlConfiguracion
    {
        private string connectionString;
        public string ConnectionString { get => connectionString; }
        public SqlConfiguracion(string Connection)
        {
            connectionString = Connection;
        }

    }
}
