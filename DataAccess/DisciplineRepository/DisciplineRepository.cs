﻿using MySql.Data.MySqlClient;
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

        public async Task<List<Discipline>> GetDisciplines()
        {
            List<Discipline> disciplines = new List<Discipline>();

            using (var connection = _db.CreateConnection())
            {
                connection.Open();

                string query = "SELECT * FROM Disciplines";

                using (var command = new MySqlCommand(query, (MySqlConnection)connection))
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

        public async Task<Discipline> GetDisciplineById(int id)
        {
            Discipline discipline = new Discipline();

            using (var connection = _db.CreateConnection())
            {
                connection.Open();

                string query = @"SELECT * FROM Disciplines WHERE Id = @Id";

                using (var command = new MySqlCommand(query, (MySqlConnection)connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            discipline = DisciplineBuilder(reader);
                        }
                    }
                }
            }

            return discipline;
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
