using Microsoft.EntityFrameworkCore;
using Models;
using System.Collections.Generic;

namespace DAL {
    public class OrderRepository : IRepository<Orders> {

        private GameStoreContext _dbContext;

        public OrderRepository(GameStoreContext dbContext) {
            _dbContext = dbContext;
        }

        public Orders Add(Orders item) {
            throw new System.NotImplementedException();
        }

        public Orders Get(Orders item) {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Orders> GetAll() {
            return _dbContext.Orders.AsNoTracking();
        }

        public IEnumerable<Orders> GetAllWithIncludes() {
            throw new System.NotImplementedException();
        }

        public Orders GetById(long id) {
            throw new System.NotImplementedException();
        }

        public Orders RemoveById(long id) {
            throw new System.NotImplementedException();
        }

        public Orders Update(Orders item) {
            throw new System.NotImplementedException();
        }
    }
}
