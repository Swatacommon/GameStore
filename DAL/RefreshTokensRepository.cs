using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL {
    class RefreshTokensRepository : IRepository<RefreshTokens> {

        GameStoreContext _dbContext;
        public RefreshTokensRepository(GameStoreContext dbContext) {
            _dbContext = dbContext;
        }

        public IEnumerable<RefreshTokens> GetAll() {
            return _dbContext.RefreshTokens;
        }
        public IEnumerable<RefreshTokens> GetAllWithIncludes() {
            return _dbContext.RefreshTokens;
        }

        public RefreshTokens Add(RefreshTokens item) {
            _dbContext.RefreshTokens.Add(item);
            return item;
        }

        public RefreshTokens GetById(double id) {
            return _dbContext.RefreshTokens.Find(id);
        }

        public RefreshTokens RemoveById(double id) {
            var tokenRemove = _dbContext.RefreshTokens.Find(id);
            if (tokenRemove == null)
                return tokenRemove;
            _dbContext.RefreshTokens.Remove(tokenRemove);
            _dbContext.SaveChangesAsync();
            return tokenRemove;
        }

        public RefreshTokens Update(RefreshTokens item) {
            throw new NotImplementedException();
        }

        public RefreshTokens Get(RefreshTokens item) {
            return _dbContext.RefreshTokens.Find(item);
        }
    }
}
