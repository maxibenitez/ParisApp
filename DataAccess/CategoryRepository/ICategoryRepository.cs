using ParisApp.Entities;

namespace ParisApp.DataAccess.CategoryRepository
{
    public interface ICategoryRepository
    {
        Task<Category> GetCategory(int id);
        Task<List<Category>> GetCategoriesByCompetition(int id);
    }
}
