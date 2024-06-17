using ParisApp.Entities;

namespace ParisApp.DataAccess.ScoreRepository
{
    public interface IScoreRepository
    {
        Task<bool> InsertScore(InsertScoreParameters parameters);
    }
}
