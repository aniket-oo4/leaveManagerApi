using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LM.Data
{
    public class DbConnectionHelper
    {
        private readonly string _connectionString;

        public DbConnectionHelper()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["LeaveManagementDB"].ConnectionString;
        }

        public SqlConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
