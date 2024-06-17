using MySql.Data.MySqlClient;
using ParisApp.Entities;
using System.Data;

namespace ParisApp.DataAccess.DisciplineRepository
{
    public class DisciplineRepository : IDisciplineRepository
    {
        #region Properties

        private readonly DBConnection _db;

        #endregion

        #region Builders

        public DisciplineRepository(DBConnection db)
        {
            _db = db;
        }

        #endregion

        #region Implementation

        public async Task<IEnumerable<Discipline>> GetDisciplines()
        {
            List<Discipline> disciplines = null;

            using (var connection = _db.CreateConnection())
            {
                connection.Open();

                using (var command = new MySqlCommand("SELECT * FROM Athletes WHERE Id = @Id", (MySqlConnection)connection))
                {
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            disciplines.Add(DisciplineBuilder(reader));
                        }
                    }
                }
            }

            return disciplines;
        }

        #endregion

        #region Private Methods

        private Discipline DisciplineBuilder(IDataReader reader)
        {
            Discipline discipline = new Discipline
            {
                Id = (int)reader["Id"],
                Name = (string)reader["Name"],
                Description = (string)reader["Description"],
            };

            return discipline;
        }

        #endregion
    }
}
