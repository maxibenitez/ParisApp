using MySql.Data.MySqlClient;
using ParisApp.Entities;
using ParisApp.Helpers;

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
            using (var connection = _db.CreateConnection())
            {
                connection.Open();

                using (var command = new MySqlCommand("SELECT * FROM Persons WHERE Id = @Id", (MySqlConnection)connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            return PersonFactory.CreatePerson(reader);
                        }
                    }
                }
            }

            return null;
        }

        #endregion

    }
}
