using ParisApp.Entities;
using System.Data;

namespace ParisApp.Helpers
{
    public static class PersonFactory
    {
        public static Person CreatePerson(IDataReader reader)
        {
            string personType = (string)reader["PersonType"];

            Person person;
            if (personType == "Athlete")
            {
                person = new Athlete();
            }
            else if (personType == "Judge")
            {
                person = new Judge();
            }
            else
            {
                throw new Exception("Invalid person type");
            }

            person.Id = (int)reader["Id"];
            person.Identification = (string)reader["Identification"];
            person.FirstName = (string)reader["FirstName"];
            person.LastName = (string)reader["LastName"];
            person.BirthDate = (DateTime)reader["BirthDate"];
            person.Country = (string)reader["Country"];
            person.Age = CalculateAge((DateTime)reader["BirthDate"]);

            return person;
        }

        private static int CalculateAge(DateTime birthDate)
        {
            var today = DateTime.Today;
            var age = today.Year - birthDate.Year;
            if (birthDate.Date > today.AddYears(-age)) age--;

            return age;
        }
    }
}
