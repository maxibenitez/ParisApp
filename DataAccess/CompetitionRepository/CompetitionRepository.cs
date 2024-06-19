using MySql.Data.MySqlClient;
using ParisApp.Entities;
using System.Data;

namespace ParisApp.DataAccess.CompetitionRepository
{
    public class CompetitionRepository : ICompetitionRepository
    {
        #region Properties

        private readonly DBConnection _db;

        #endregion

        #region Builders

        public CompetitionRepository(DBConnection db)
        {
            _db = db;
        }

        #endregion

        #region Implementation

        public async Task<List<Competition>> GetCompetitionsByDiscipline(int id)
        {
            List<Competition> competitions = new List<Competition>();

            using (var connection = _db.CreateConnection())
            {
                connection.Open();

                string query = @"SELECT * FROM Competitions WHERE IdDiscipline = @Id";

                using (var command = new MySqlCommand(query, (MySqlConnection)connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            competitions.Add(CompetitionBuilder(reader));
                        }
                    }
                }
            }

            return competitions;
        }

        #endregion

        #region Private Methods

        private Competition CompetitionBuilder(IDataReader reader)
        {
            Competition competition = new Competition
            {
                Id = (int)reader["Id"],
                Name = (string)reader["Name"],
                Description = (string)reader["Description"],
                IdDiscipline = (int)reader["IdDiscipline"],
            };

            return competition;
        }

        #endregion
    }
}
