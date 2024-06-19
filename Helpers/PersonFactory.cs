using ParisApp.DTOs;
using ParisApp.Entities;

namespace ParisApp.Helpers
{
    public class PersonFactory
    {
        public PersonDTO CreatePersonDTO(Person person)
        {
            if (person == null)
            {
                return null;
            }
            if (person.Type.Equals("Athlete"))
            {
                return new AthleteDTO
                {
                    Id = person.Id,
                    Identification = person.Identification,
                    FirstName = person.FirstName,
                    LastName = person.LastName,
                    BirthDate = person.BirthDate.ToString("dd/MM/yyyy"),
                    Country = person.Country,
                    Type = person.Type,
                };
            }
            else if (person.Type.Equals("Judge"))
            {
                return new JudgeDTO
                {
                    Id = person.Id,
                    Identification = person.Identification,
                    FirstName = person.FirstName,
                    LastName = person.LastName,
                    BirthDate = person.BirthDate.ToString("dd/MM/yyyy"),
                    Country = person.Country,
                    Type = person.Type,
                };
            }

            return null;
        }
    }
}
