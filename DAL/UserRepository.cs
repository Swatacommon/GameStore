using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL {
    class UserRepository : IRepository<Users> {

        GameStoreContext _dbContext;
        public UserRepository(GameStoreContext dbContext) {
            _dbContext = dbContext;
        }

        public Users Add(Users item) {
            throw new NotImplementedException();
        }

        public IEnumerable<Users> GetAll() {
            return _dbContext.Users.AsNoTracking();
        }

        public IEnumerable<Users> GetAllWithIncludes() {
            throw new NotImplementedException();
        }

        public Users Get(Users user) {
            return _dbContext.Users.Find(user.Email);
        }

        public Users GetById(long id) {
            throw new NotImplementedException();
        }

        public Users RemoveBy(Users item) {
            throw new NotImplementedException();
        }

        public Users RemoveById(long item) {
            throw new NotImplementedException();
        }

        public Users Update(Users item) {
            throw new NotImplementedException();
        }
    }
}
