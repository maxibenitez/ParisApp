using ParisApp.DataAccess.DisciplineRepository;
using ParisApp.DTOs;
using ParisApp.Entities;

namespace ParisApp.Helpers
{
    public class EventDTOBuilder: IEventDTOBuilder
    {
        #region Properties

        private EventDTO _eventDTO;
        private readonly IDisciplineRepository _disciplineRepo;

        #endregion

        #region Builders

        public EventDTOBuilder(Event eventObj, IDisciplineRepository disciplineRepo)
        {
            _eventDTO = new EventDTO
            {
                Id = eventObj.Id,
                Date = eventObj.Date,
                Genre = eventObj.Genre,
            };
            _disciplineRepo = disciplineRepo;
        }

        #endregion

        #region Implementation

        public EventDTOBuilder AddLocationDTO(Location location)
        {
            _eventDTO.Location = LocationDTOBuilder(location);
            return this;
        }

        public EventDTOBuilder AddCategoryDTO(Category category)
        {
            _eventDTO.Category = CategoryDTOBuilder(category);
            return this;
        }

        public async Task<EventDTOBuilder> AddAthletesDTO(List<Person> athletes)
        {
            _eventDTO.Athletes = await PersonsDTOBuilder(athletes);
            return this;
        }

        public EventDTO Build()
        {
            return _eventDTO;
        }

        #endregion

        #region Private Methods

        private async Task<List<PersonDTO>> PersonsDTOBuilder(List<Person> persons)
        {
            List<PersonDTO> personsDTO = new List<PersonDTO>();

            foreach (Person person in persons)
            {
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

                personsDTO.Add(personDTO);
            }

            return personsDTO;
        }

        private LocationDTO LocationDTOBuilder(Location location)
        {
            LocationDTO locationDTO = new LocationDTO
            {
                Id = location.Id,
                Name = location.Name,
                Description = location.Description,
                Address = location.Address,
            };

            return locationDTO;
        }

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
