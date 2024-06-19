using MySql.Data.MySqlClient;
using ParisApp.Entities;

namespace ParisApp.DataAccess.ScoreRepository
{
    public class ScoreRepository : IScoreRepository
    {
        #region Properties

        private readonly DBConnection _db;

        #endregion

        #region Builders

        public ScoreRepository(DBConnection db)
        {
            _db = db;
        }

        #endregion

        #region Implementation

        public async Task<bool> InsertScore(InsertScoreParameters parameters)
        {
            using (var connection = _db.CreateConnection())
            {
                connection.Open();

                string query = @"
                    INSERT INTO Scores (IdEvent, IdAthlete, IdJudge, Score) 
                    VALUES (@IdEvent, @IdAthlete, @IdJudge, @Score)";

                using (var command = new MySqlCommand(query, (MySqlConnection)connection))
                {
                    command.Parameters.AddWithValue("@IdEvent", parameters.IdEvent);
                    command.Parameters.AddWithValue("@IdAthlete", parameters.IdAthlete);
                    command.Parameters.AddWithValue("@IdJudge", parameters.IdJudge);
                    command.Parameters.AddWithValue("@Score", parameters.Score);

                    var resp = await command.ExecuteNonQueryAsync();

                    return resp > 0;
                }
            }
        }

        #endregion
    }
}
