using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace MajorProjctAPI.Repository
{
    public class DbConnector
    {

        private readonly IConfiguration _configuration;
        //private readonly string _connectionString;

        public DbConnector(IConfiguration configuration) // this is Constructor
        {
            _configuration = configuration;
            //_connectionString = configuration.GetConnectionString("")
        }
        
        public IDbConnection GetConnection()
        {
            string _connectionString = _configuration.GetConnectionString("DefaultConnection");
            return new SqlConnection(_connectionString);
        }

    }
}
