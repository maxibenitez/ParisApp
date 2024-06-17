using ParisApp.Entities;

namespace ParisApp.Services.ScoreService
{
    public interface IScoreService
    {
        Task<bool> InsertScore(InsertScoreParameters parameters);
    }
}
