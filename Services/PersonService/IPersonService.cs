using ParisApp.Entities;

namespace ParisApp.Services.PersonService
{
    public interface IPersonService
    {
        Task<Person> GetPerson(int id);
    }
}
