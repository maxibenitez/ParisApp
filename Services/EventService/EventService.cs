using ParisApp.DataAccess.EventRepository;
using ParisApp.DataAccess.PersonRepository;
using ParisApp.Entities;

namespace ParisApp.Services.EventService
{
    public class EventService : IEventService
    {
        #region Properties

        private readonly IEventRepository _eventRepo;
        private readonly IPersonRepository _personRepo;

        #endregion

        #region Builders

        public EventService(IEventRepository eventRepo, IPersonRepository personRepo)
        {
            _eventRepo = eventRepo;
            _personRepo = personRepo;
        }

        #endregion

        #region Implementation

        public Task<Event> GetEvent(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Event>> GetEvents()
        { 
            throw new NotImplementedException(); 
        }

        #endregion

        #region Private Methods

        #endregion
    }
}
