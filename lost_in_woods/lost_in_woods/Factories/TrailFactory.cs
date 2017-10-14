using System.Collections.Generic;
using System.Linq;
using Dapper;
using System.Data;
using MySql.Data.MySqlClient;
using lost_in_woods.Models;

namespace lost_in_woods.Factories
{
    public class TrailFactory
    {
        private string connectionString;
        public TrailFactory()
        {
            connectionString = "server=localhost;userid=root;password=root;port=8889;database=trails;SslMode=None";
        }
        internal IDbConnection Connection
        {
            get {
                return new MySqlConnection(connectionString);
            }
        }
        public List<Trail> ShowAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                string query = "SELECT * FROM trails";
                dbConnection.Open();
                return dbConnection.Query<Trail>(query).ToList();
            }
        }
        public void AddTrail(Trail newTrail)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string query = "INSERT trails (name, description, length, elevationChange, longitude, latitude, createdAt, updatedAt ) VALUES(@name, @description, @length, @elevationChange, @longitude, @latitude, NOW(), NOW() )";
                dbConnection.Open();
                dbConnection.Execute(query, newTrail);
            }
        }
        public Trail FindByID(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string query = "SELECT * FROM trails WHERE id = @Id";
                dbConnection.Open();
                return dbConnection.Query<Trail>(query, new {Id = id}).FirstOrDefault();
            }
        }
    }
}
