using MySql.Data.MySqlClient;
using ParisApp.Entities;
using System.Data;

namespace ParisApp.DataAccess.EventRepository
{
    public class EventRepository : IEventRepository
    {
        #region Properties

        private readonly DBConnection _db;

        #endregion

        #region Builders

        public EventRepository(DBConnection db)
        {
            _db = db;
        }

        #endregion

        #region Implementation

        public async Task<Event> GetEvent(int id)
        {
            Event eventObj = new Event();

            using (var connection = _db.CreateConnection())
            {
                connection.Open();

                string query = @"SELECT * FROM Events WHERE Id = @Id";

                using (var command = new MySqlCommand(query, (MySqlConnection)connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            eventObj = EventBuilder(reader);
                        }
                    }
                }
            }

            return eventObj;
        }

        public async Task<List<Event>> GetEvents()
        {
            List<Event> events = new List<Event>();

            using (var connection = _db.CreateConnection())
            {
                connection.Open();

                string query = "SELECT * FROM Events";

                using (var command = new MySqlCommand(query, (MySqlConnection)connection))
                {
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            events.Add(EventBuilder(reader));
                        }
                    }
                }
            }

            return events;
        }

        public async Task<Location> GetLocation(int id)
        {
            Location location = new Location();

            using (var connection = _db.CreateConnection())
            {
                connection.Open();

                string query = @"SELECT * FROM Events WHERE Id = @Id";

                using (var command = new MySqlCommand(query, (MySqlConnection)connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            location = LocationBuilder(reader);
                        }
                    }
                }
            }

            return location;
        }

        #endregion

        #region Private Methods

        private Event EventBuilder(IDataReader reader)
        {
            Event eventObj = new Event
            {
                Id = (int)reader["Id"],
                IdDiscipline = (int)reader["IdDiscipline"],
                IdCompetition = (int)reader["IdCompetition"],
                IdCategory = (int)reader["IdCategory"],
                Date = (DateTime)reader["Date"],
                Genre = (string)reader["Genre"],
                IdLocation = (int)reader["IdPlace"],
            };

            return eventObj;
        }

        private Location LocationBuilder(IDataReader reader)
        {
            Location location = new Location
            {
                Id = (int)reader["Id"],
                Name = (string)reader["Name"],
                Description = (string)reader["Description"],
                Address = (string)reader["Address"],
            };

            return location;
        }

        #endregion
    }
}
