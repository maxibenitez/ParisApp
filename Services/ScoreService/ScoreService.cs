using ParisApp.DataAccess.ScoreRepository;
using ParisApp.Entities;

namespace ParisApp.Services.ScoreService
{
    public class ScoreService : IScoreService
    {
        #region Properties

        private readonly IScoreRepository _scoreRepo;

        #endregion

        #region Builders

        public ScoreService(IScoreRepository scoreRepo)
        {
            _scoreRepo = scoreRepo;
        }

        #endregion

        #region Implementation

        public async Task<bool> InsertScore(InsertScoreParameters parameters)
        {
            return await _scoreRepo.InsertScore(parameters);
        }

        #endregion
    }
}
