using ParisApp.Entities;

namespace ParisApp.DataAccess.PersonRepository
{
    public interface IPersonRepository
    {
        Task<Person> GetPerson(int id);
    }
}
