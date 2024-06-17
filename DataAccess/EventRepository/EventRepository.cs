using ParisApp.Entities;

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

        public Task<Event> GetEvent(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Event>> GetEvents()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Private Methods



        #endregion
    }
}
