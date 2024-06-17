using ParisApp.Entities;

namespace ParisApp.DataAccess.EventRepository
{
    public interface IEventRepository
    {
        Task<Event> GetEvent(int id);
        Task<IEnumerable<Event>> GetEvents();
    }
}
