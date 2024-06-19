using ParisApp.Entities;

namespace ParisApp.DataAccess.CompetitionRepository
{
    public interface ICompetitionRepository
    {
        Task<List<Competition>> GetCompetitionsByDiscipline(int id);
    }
}
