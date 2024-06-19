using ParisApp.DataAccess.DisciplineRepository;
using ParisApp.DataAccess.PersonRepository;
using ParisApp.DTOs;
using ParisApp.Entities;
using ParisApp.Helpers;

namespace ParisApp.Services.PersonService
{
    public class PersonService : IPersonService
    {
        #region Properties

        private readonly IPersonRepository _personRepo;
        private readonly IDisciplineRepository _disciplineRepo;

        #endregion

        #region Builders

        public PersonService(IPersonRepository personRepo, IDisciplineRepository disciplineRepo)
        {
            _personRepo = personRepo;
            _disciplineRepo = disciplineRepo;
        }

        #endregion

        #region Implementation

        public async Task<PersonDTO> GetPerson(int id)
        {
            Person person = await _personRepo.GetPerson(id);

            if (person == null)
            {
                return null;
            }

            Discipline discipline = await _disciplineRepo.GetDisciplineById(person.IdDiscipline);

            PersonFactory personFactory = new PersonFactory();

            PersonDTO personDTO = personFactory.CreatePersonDTO(person);

            if (personDTO is AthleteDTO athleteDTO)
            {
                athleteDTO.Discipline = DisciplineDTOBuilder(discipline);
            }
            else if (personDTO is JudgeDTO judgeDTO)
            {
                judgeDTO.Discipline = DisciplineDTOBuilder(discipline);
            }

            return personDTO;
        }

        #endregion

        #region Private Methods

        private DisciplineDTO DisciplineDTOBuilder(Discipline discipline)
        {
            DisciplineDTO disciplineDTO = new DisciplineDTO
            {
                Id = discipline.Id,
                Name = discipline.Name,
                Description = discipline.Description,
            };

            return disciplineDTO;
        }

        #endregion
    }
}
