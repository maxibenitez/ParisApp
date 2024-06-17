using ParisApp.Entities;

namespace ParisApp.Services.DisciplineService
{
    public interface IDisciplineService
    {
        Task<IEnumerable<Discipline>> GetDisciplines();
    }
}
