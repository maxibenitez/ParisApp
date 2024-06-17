using ParisApp.DataAccess.PersonRepository;
using ParisApp.Entities;
using System.Globalization;

namespace ParisApp.Services.PersonService
{
    public class PersonService : IPersonService
    {
        #region Properties

        private readonly IPersonRepository _personRepo;

        #endregion

        #region Builders

        public PersonService(IPersonRepository personRepo)
        {
            _personRepo = personRepo;
        }

        #endregion

        #region Implementation

        public async Task<Person> GetPerson(int id)
        {
            return await _personRepo.GetPerson(id);
        }

        #endregion

        #region Private Methods

        #endregion
    }
}
