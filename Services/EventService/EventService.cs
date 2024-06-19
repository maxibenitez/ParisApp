using ParisApp.DataAccess.CategoryRepository;
using ParisApp.DataAccess.EventRepository;
using ParisApp.DataAccess.PersonRepository;
using ParisApp.DTOs;
using ParisApp.Entities;

namespace ParisApp.Services.EventService
{
    public class EventService : IEventService
    {
        #region Properties

        private readonly IEventRepository _eventRepo;
        private readonly ICategoryRepository _categoryRepo;
        private readonly IPersonRepository _personRepo;

        #endregion

        #region Builders

        public EventService(IEventRepository eventRepo, IPersonRepository personRepo, ICategoryRepository categoryRepo)
        {
            _eventRepo = eventRepo;
            _personRepo = personRepo;
            _categoryRepo = categoryRepo;
        }

        #endregion

        #region Implementation

        public async Task<EventDTO> GetEvent(int id)
        {
            Event eventObj = await _eventRepo.GetEvent(id);

            Location location = await _eventRepo.GetLocation(eventObj.IdLocation);

            Category category = await _categoryRepo.GetCategory(eventObj.IdCategory);

            List<Person> persons = await _personRepo.GetEventAthletes(eventObj.Id);

            List<AthleteDTO> athletes = new List<AthleteDTO>();

            foreach (Person person in persons) 
            {
                
            }

            EventDTO eventDTO = EventDTOBuilder(eventObj);

            eventDTO.Location = LocationDTOBuilder(location);
            eventDTO.Category = CategoryDTOBuilder(category);
            eventDTO.Athletes = athletes;

            return eventDTO;
        }

        public async Task<List<EventDTO>> GetEvents()
        { 
            List<Event> events = await _eventRepo.GetEvents();

            throw new NotImplementedException(); 
        }

        #endregion

        #region Private Methods

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
