using Microsoft.Data.SqlClient;
using Dapper;
using Poudlard.Api.Models.Entities;

namespace Poudlard.Api.Repositories
{
    public class MaisonRepository
    {
        private readonly string _connectionString;

        public MaisonRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Poudlard")!;
        }

        public List<Maison> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                IEnumerable<Maison> maisons = connection.Query<Maison>("""
                    SELECT Id, Nom, Fondateur, Couleur, Embleme
                    FROM Maison
                    """);

                return maisons.ToList();
            }
        }

        public Maison? GetById(Guid id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                Maison? maison = connection.QueryFirstOrDefault<Maison>("""
                    SELECT Id, Nom, Fondateur, Couleur, Embleme
                    FROM Maison
                    WHERE Id = @Id
                    """, new { Id = id });

                return maison;
            }
        }
    }
}