using ParisApp.DTOs;

namespace ParisApp.Services.DisciplineService
{
    public interface IDisciplineService
    {
        Task<List<DisciplineDTO>> GetDisciplines();
    }
}
