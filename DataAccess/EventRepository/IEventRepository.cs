using ParisApp.Entities;

namespace ParisApp.DataAccess.EventRepository
{
    public interface IEventRepository
    {
        Task<Location> GetLocation(int id);
        Task<Event> GetEvent(int id);
        Task<List<Event>> GetEvents();
    }
}
