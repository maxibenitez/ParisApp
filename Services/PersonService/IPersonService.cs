using ParisApp.DTOs;

namespace ParisApp.Services.PersonService
{
    public interface IPersonService
    {
        Task<PersonDTO> GetPerson(int id);
    }
}
