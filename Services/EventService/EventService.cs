using ParisApp.DataAccess.CategoryRepository;
using ParisApp.DataAccess.DisciplineRepository;
using ParisApp.DataAccess.EventRepository;
using ParisApp.DataAccess.PersonRepository;
using ParisApp.DTOs;
using ParisApp.Entities;
using ParisApp.Helpers;

namespace ParisApp.Services.EventService
{
    public class EventService : IEventService
    {
        #region Properties

        private readonly IEventRepository _eventRepo;
        private readonly ICategoryRepository _categoryRepo;
        private readonly IPersonRepository _personRepo;
        private readonly IDisciplineRepository _disciplineRepo;

        #endregion

        #region Builders

        public EventService(IEventRepository eventRepo, IPersonRepository personRepo, ICategoryRepository categoryRepo, IDisciplineRepository disciplineRepo)
        {
            _eventRepo = eventRepo;
            _personRepo = personRepo;
            _categoryRepo = categoryRepo;
            _disciplineRepo = disciplineRepo;
        }

        #endregion

        #region Implementation

        public async Task<EventDTO> GetEvent(int id)
        {
            Event eventObj = await _eventRepo.GetEvent(id);
            return await BuildEventDTO(eventObj);
        }

        public async Task<List<EventDTO>> GetEvents()
        {
            List<Event> events = await _eventRepo.GetEvents();
            
            List<EventDTO> eventsDTO = new List<EventDTO>();

            foreach (Event eventObj in events)
            {
                eventsDTO.Add(await BuildEventDTO(eventObj));
            }

            return eventsDTO;
        }

        #endregion

        #region Private Methods

        private async Task<EventDTO> BuildEventDTO(Event eventObj)
        {
            Location location = await _eventRepo.GetLocation(eventObj.IdLocation);
            Category category = await _categoryRepo.GetCategory(eventObj.IdCategory);
            List<Person> persons = await _personRepo.GetEventAthletes(eventObj.Id);
            List<PersonDTO> athletes = await BuildPersonDTOs(persons);

            EventDTO eventDTO = EventDTOBuilder(eventObj);
            eventDTO.Location = LocationDTOBuilder(location);
            eventDTO.Category = CategoryDTOBuilder(category);
            eventDTO.Athletes = athletes;

            return eventDTO;
        }

        private async Task<List<PersonDTO>> BuildPersonDTOs(List<Person> persons)
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

        private EventDTO EventDTOBuilder(Event eventObj)
        {
            EventDTO eventDTO = new EventDTO
            {
                Id = eventObj.Id,
                Date = eventObj.Date,
                Genre = eventObj.Genre,
            };

            return eventDTO;
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
