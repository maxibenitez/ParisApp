using Microsoft.AspNetCore.Mvc;
using ParisApp.Entities;

namespace ParisApp.Services.EventService
{
    public interface IEventService
    {
        Task<Event> GetEvent(int id);
        Task<IEnumerable<Event>> GetEvents();
    }
}
