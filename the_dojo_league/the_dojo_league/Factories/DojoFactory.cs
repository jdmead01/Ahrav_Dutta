using System.Collections.Generic;
using System.Linq;
using Dapper;
using System.Data;
using MySql.Data.MySqlClient;
using the_dojo_league.Models;
 
namespace DapperApp.Factory
{
    public class DojoFactory : IFactory<Dojo>
    {
        private string connectionString;
        public DojoFactory()
        {
            connectionString = "server=localhost;userid=root;password=root;port=8889;database=dojo_league;SslMode=None";
        }
        internal IDbConnection Connection
        {
            get {
                return new MySqlConnection(connectionString);
            }
        }
        public IEnumerable<Dojo> AllDojos()
        {
            using (IDbConnection dbConnection = Connection)
            {
                string query = "SELECT * FROM Dojos";
                dbConnection.Open();
                return dbConnection.Query<Dojo>(query);
            }
        }
    }
}