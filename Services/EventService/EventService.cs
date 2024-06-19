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

            EventDTOBuilder builder = new EventDTOBuilder(eventObj, _disciplineRepo);
            builder = builder.AddLocationDTO(await _eventRepo.GetLocation(eventObj.IdLocation));
            builder = builder.AddCategoryDTO(await _categoryRepo.GetCategory(eventObj.IdCategory));
            builder = await builder.AddAthletesDTO(await _personRepo.GetEventAthletes(eventObj.Id));

            return builder.Build();
        }

        public async Task<List<EventDTO>> GetEvents()
        {
            List<Event> events = await _eventRepo.GetEvents();
            
            List<EventDTO> eventsDTO = new List<EventDTO>();

            foreach (Event eventObj in events)
            {
                EventDTOBuilder builder = new EventDTOBuilder(eventObj, _disciplineRepo);
                builder = builder.AddLocationDTO(await _eventRepo.GetLocation(eventObj.IdLocation));
                builder = builder.AddCategoryDTO(await _categoryRepo.GetCategory(eventObj.IdCategory));
                builder = await builder.AddAthletesDTO(await _personRepo.GetEventAthletes(eventObj.Id));

                eventsDTO.Add(builder.Build());
            }

            return eventsDTO;
        }

        #endregion
    }
}
