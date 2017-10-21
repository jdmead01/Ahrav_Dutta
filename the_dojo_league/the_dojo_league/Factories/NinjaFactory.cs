using System.Collections.Generic;
using System.Linq;
using Dapper;
using System.Data;
using MySql.Data.MySqlClient;
using the_dojo_league.Models;

namespace DapperApp.Factory
{
    public class NinjaFactory : IFactory<Ninja>
    {
        private string connectionString;
        public NinjaFactory()
        {
            connectionString = "server=localhost;userid=root;password=root;port=8889;database=dojo_league;SslMode=None";
        }
        internal IDbConnection Connection
        {
            get {
                return new MySqlConnection(connectionString);
            }
        }
        public void AddNinja(Ninja newNinja)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string query = "INSERT INTO Ninjas ( name, level, description, Dojos_id ) VALUES ( @name, @level, @description, @Dojos_id )";
                dbConnection.Open();
                dbConnection.Execute(query, newNinja);
            }
        }
        public IEnumerable<Ninja> AllNinjas()
        {
            using (IDbConnection dbConnection = Connection)
            {
                // var query = "SELECT Ninjas.name AS ninja_name, Ninjas.id AS ninja_id, Dojos.name AS dojo_name, Dojos.id AS dojo_id FROM Ninjas JOIN Dojos ON Ninjas.Dojos_id WHERE Dojos.id = Ninjas.Dojos_id";
                var query = "SELECT * FROM Ninjas JOIN Dojos ON Ninjas.Dojos_id WHERE Dojos.id = Ninjas.Dojos_id";
                dbConnection.Open();

                var allNinjas = dbConnection.Query<Ninja, Dojo, Ninja>(query, (ninja, dojo) => { ninja.dojo = dojo; return ninja; });
                return allNinjas;
            }
        }
    }
}