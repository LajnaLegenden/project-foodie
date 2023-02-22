// Wrapper for all repositories, all other repositories should be accessed from this wrapper.
// ex: repository = new RepositoryWrapper(db)
//     repository.Order.getAllAsync()
using project_foodie.Model;
namespace project_foodie.Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private DatabaseContext _dbContext;
        private IOrderRepository _order;

        public IOrderRepository Order
        {
            get
            {
                if (_order == null)
                {
                    _order = new OrderRepository(_dbContext);
                }

                return _order;
            }
        }

        public RepositoryWrapper(DatabaseContext databaseContext)
        {
            _dbContext = databaseContext;
        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}