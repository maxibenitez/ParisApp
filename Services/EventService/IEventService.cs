using ParisApp.DTOs;

namespace ParisApp.Services.EventService
{
    public interface IEventService
    {
        Task<EventDTO> GetEvent(int id);
        Task<List<EventDTO>> GetEvents();
    }
}
