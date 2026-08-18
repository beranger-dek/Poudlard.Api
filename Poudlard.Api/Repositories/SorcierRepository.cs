using Dapper;
using Microsoft.Data.SqlClient;
using Poudlard.Api.Models.Dtos;
using Poudlard.Api.Models.Entities;

namespace Poudlard.Api.Repositories
{
    public class SorcierRepository
    {
        private readonly string _connectionString;

        public SorcierRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Poudlard")!;
        }
        public int Creer(CreerSorcierDto dto) 
        { 
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                int rows = connection.Execute("""
                    INSERT INTO Sorcier (Nom, Prenom, MaisonId)
                    VALUES (@Nom, @Prenom, @MaisonId)
                    """, param: dto);

                return rows;
            }
        }

        public Sorcier? GetById(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                Sorcier? sorcier = connection.QueryFirstOrDefault<Sorcier>("""
                    SELECT Id, Nom, Prenom, MaisonId
                    FROM Sorcier
                    WHERE Id = @Id
                    """, new { Id = id });

                return sorcier;
            }
        }
        
        public List<Sorcier> GetAllByMaisonId(Guid maisonId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                IEnumerable<Sorcier> sorciers = connection.Query<Sorcier>("""
            SELECT Id, Nom, Prenom, MaisonId
            FROM Sorcier
            WHERE MaisonId = @MaisonId
            """, new { MaisonId = maisonId });

                return sorciers.ToList();
            }
        }
    }
}
