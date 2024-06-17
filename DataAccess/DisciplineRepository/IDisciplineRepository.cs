using ParisApp.Entities;

namespace ParisApp.DataAccess.DisciplineRepository
{
    public interface IDisciplineRepository
    {
        Task<IEnumerable<Discipline>> GetDisciplines();
    }
}
