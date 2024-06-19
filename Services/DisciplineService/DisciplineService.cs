using ParisApp.DataAccess.CategoryRepository;
using ParisApp.DataAccess.CompetitionRepository;
using ParisApp.DataAccess.DisciplineRepository;
using ParisApp.DTOs;
using ParisApp.Entities;
using System.Data;

namespace ParisApp.Services.DisciplineService
{
    public class DisciplineService : IDisciplineService
    {
        #region Properties

        private readonly IDisciplineRepository _disciplineRepo;
        private readonly ICategoryRepository _categoryRepo;
        private readonly ICompetitionRepository _competitionRepo;

        #endregion

        #region Builders

        public DisciplineService(IDisciplineRepository disciplineRepo, ICategoryRepository categoryRepo, ICompetitionRepository competitionRepo)
        {
            _disciplineRepo = disciplineRepo;
            _categoryRepo = categoryRepo;
            _competitionRepo = competitionRepo;
        }

        #endregion

        #region Implementation

        public async Task<List<DisciplineDTO>> GetDisciplines()
        {
            List<Discipline> disciplines = await _disciplineRepo.GetDisciplines();

            List<DisciplineDTO> disciplinesDTO = new List<DisciplineDTO>();

            foreach (Discipline discipline in disciplines)
            {
                List<Competition> competitions = await _competitionRepo.GetCompetitionsByDiscipline(discipline.Id);

                List<CompetitionDTO> competitionsDTO = new List<CompetitionDTO>();

                foreach (Competition competition in competitions)
                {
                    List<Category> categories = await _categoryRepo.GetCategoriesByCompetition(competition.Id);

                    List<CategoryDTO> categoriesDTO = new List<CategoryDTO>();

                    foreach (Category category in categories)
                    {
                        categoriesDTO.Add(CategoryDTOBuilder(category));
                    }

                    var competitionDTO = CompetitionDTOBuilder(competition);

                    competitionDTO.Categories = categoriesDTO;

                    competitionsDTO.Add(competitionDTO);
                }

                var disciplineDTO = DisciplineDTOBuilder(discipline);

                disciplineDTO.Competitions = competitionsDTO;

                disciplinesDTO.Add(disciplineDTO);
            }

            return disciplinesDTO;
        }

        #endregion

        #region Private Methods

        private DisciplineDTO DisciplineDTOBuilder (Discipline discipline)
        {
            DisciplineDTO disciplineDTO = new DisciplineDTO
            {
                Id = discipline.Id,
                Name = discipline.Name,
                Description = discipline.Description,
            };

            return disciplineDTO;
        }

        private CompetitionDTO CompetitionDTOBuilder(Competition competition)
        {
            CompetitionDTO competitionDTO = new CompetitionDTO
            {
                Id = competition.Id,
                Name = competition.Name,
                Description = competition.Description,
            };

            return competitionDTO;
        }

        private CategoryDTO CategoryDTOBuilder(Category category)
        {
            CategoryDTO categoryDTO = new CategoryDTO
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description,
            };

            return categoryDTO;
        }

        #endregion
    }
}
