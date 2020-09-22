using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL {
    public class UnitOfWork : IUnitOfWork {
        private readonly GameStoreContext _dbContext;
        private IRepository<Games> _gameRepository;
        private IRepository<Users> _userRepository;
        private IRepository<Publishers> _publisherRepository;

        public UnitOfWork(GameStoreContext dbConext) {
            _dbContext = dbConext;
        }

        public IRepository<Games> GameRepository {
            get {
                return _gameRepository = _gameRepository ?? new GameRepository(_dbContext);
            }
        }
        public IRepository<Publishers> PublisherRepository {
            get {
                return null;// _publisherRepository = _publisherRepository ?? new Repository<Book>(_databaseContext);
            }
        }
        public IRepository<Users> UserRepository {
            get {
                return _userRepository = _userRepository ?? new UserRepository(_dbContext);
            }
        }

        public void Commit() {
            _dbContext.SaveChanges();
        }

        public void Rollback() {
            _dbContext.Dispose();
        }
    }
}
