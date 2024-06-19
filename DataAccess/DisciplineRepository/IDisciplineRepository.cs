using ParisApp.Entities;

namespace ParisApp.DataAccess.DisciplineRepository
{
    public interface IDisciplineRepository
    {
        Task<List<Discipline>> GetDisciplines();
        Task<Discipline> GetDisciplineById(int id);
    }
}
