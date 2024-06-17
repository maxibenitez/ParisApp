using MySql.Data.MySqlClient;
using ParisApp.DataAccess.DisciplineRepository;
using ParisApp.Entities;
using System.Data;

namespace ParisApp.Services.DisciplineService
{
    public class DisciplineService : IDisciplineService
    {
        #region Properties

        private readonly IDisciplineRepository _disciplineRepo;

        #endregion

        #region Builders

        public DisciplineService(IDisciplineRepository disciplineRepo)
        {
            _disciplineRepo = disciplineRepo;
        }

        #endregion

        #region Implementation

        public Task<IEnumerable<Discipline>> GetDisciplines()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Private Methods



        #endregion
    }
}
