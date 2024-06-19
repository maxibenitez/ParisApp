using MySql.Data.MySqlClient;
using ParisApp.Entities;
using System.Data;

namespace ParisApp.DataAccess.CategoryRepository
{
    public class CategoryRepository : ICategoryRepository
    {
        #region Properties

        private readonly DBConnection _db;

        #endregion

        #region Builders

        public CategoryRepository(DBConnection db)
        {
            _db = db;
        }

        #endregion

        #region Implementation

        public async Task<List<Category>> GetCategoriesByCompetition(int id)
        {
            List<Category> categories = new List<Category>();

            using (var connection = _db.CreateConnection())
            {
                connection.Open();

                string query = @"SELECT * FROM Categories WHERE IdCompetition = @Id";

                using (var command = new MySqlCommand(query, (MySqlConnection)connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            categories.Add(CategoryBuilder(reader));
                        }
                    }
                }
            }

            return categories;
        }

        public async Task<Category> GetCategory(int id)
        {
            Category category = new Category();

            using (var connection = _db.CreateConnection())
            {
                connection.Open();

                string query = @"SELECT * FROM Categories WHERE Id = @Id";

                using (var command = new MySqlCommand(query, (MySqlConnection)connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            category = CategoryBuilder(reader);
                        }
                    }
                }
            }

            return category;
        }

        #endregion

        #region Private Methods

        private Category CategoryBuilder(IDataReader reader)
        {
            Category category = new Category
            {
                Id = (int)reader["Id"],
                Name = (string)reader["Name"],
                Description = (string)reader["Description"],
                IdCompetition = (int)reader["IdCompetition"],
            };

            return category;
        }

        #endregion
    }
}
