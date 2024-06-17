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

                using (var command = new MySqlCommand(" ", (MySqlConnection)connection))
                {
                    command.Parameters.AddWithValue("@AthleteId", parameters.AthleteId);
                    command.Parameters.AddWithValue("@JudgeId", parameters.JudgeId);
                    command.Parameters.AddWithValue("@Score", parameters.Score);

                    var resp = await command.ExecuteNonQueryAsync();

                    return resp < 0;
                }
            }
        }

        #endregion
    }
}
