using MySql.Data.MySqlClient;
using ParisApp.Entities;
using System.Data;

namespace ParisApp.DataAccess.PersonRepository
{
    public class PersonRepository : IPersonRepository
    {
        #region Properties

        private readonly DBConnection _db;

        #endregion

        #region Builders

        public PersonRepository(DBConnection db)
        {
            _db = db;
        }

        #endregion

        #region Implementation

        public async Task<Person> GetPerson(int id)
        {
            Person person = new Person();

            using (var connection = _db.CreateConnection())
            {
                connection.Open();

                string query = @"SELECT * FROM Persons WHERE Id = @Id";

                using (var command = new MySqlCommand(query, (MySqlConnection)connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            person = PersonBuilder(reader);
                        }
                    }
                }
            }

            return person;
        }

        public async Task<List<Person>> GetEventAthletes(int id)
        {
            List<Person> persons = new List<Person>();

            using (var connection = _db.CreateConnection())
            {
                connection.Open();

                string query = "SELECT IdAthlete FROM EventAthletes WHERE IdEvent = @Id";

                using (var command = new MySqlCommand(query, (MySqlConnection)connection))
                {
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            Person person = await GetPerson((int)reader["IdAthlete"]);

                            persons.Add(person);
                        }
                    }
                }
            }

            return persons;
        }

        #endregion

        #region Private Methods

        private Person PersonBuilder(IDataReader reader)
        {
            Person person = new Person
            {
                Id = (int)reader["Id"],
                Identification = (string)reader["Identification"],
                FirstName = (string)reader["FirstName"],
                LastName = (string)reader["LastName"],
                BirthDate = (DateTime)reader["BirthDate"],
                Country = (string)reader["Country"],
                IdDiscipline = (int)reader["IdDiscipline"],
                Type = (string)reader["Type"],
            };

            return person;
        }

        #endregion

    }
}
