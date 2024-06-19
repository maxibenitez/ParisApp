using ParisApp.Entities;

namespace ParisApp.Helpers
{
    public interface IEventDTOBuilder
    {
        EventDTOBuilder AddLocationDTO(Location location);
        EventDTOBuilder AddCategoryDTO(Category category);
        Task<EventDTOBuilder> AddAthletesDTO(List<Person> athletes);
    }
}
