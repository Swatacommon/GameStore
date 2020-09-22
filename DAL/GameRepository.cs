using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL {
    public class GameRepository : IRepository<Games> {

        GameStoreContext _dbContext;
        public GameRepository(GameStoreContext dbContext) {
            _dbContext = dbContext;
        }

        public IEnumerable<Games> GetAll() {
            return _dbContext.Games;
        }
        public IEnumerable<Games> GetAllWithIncludes() {
            return _dbContext.Games.Include(game => game.Publisher)
                .Include(game => game.GamePlatforms)
                                   .ThenInclude(gamePlatforms => gamePlatforms.Platform)
                                   .Include(game => game.GameMethodActivations)
                                   .ThenInclude(gameMethodActivations => gameMethodActivations.MethodActivation)
                                   .Include(game => game.GameGenres).ThenInclude(gameGenres => gameGenres.Genre)
                                   .Include(game => game.GameImages).ThenInclude(gameImages => gameImages.ImageNameNavigation)
                                   .AsNoTracking();
        }

        public Games Add(Games item) {
            _dbContext.Games.Add(item);
            return item;
        }

        public Games GetById(double id) {
            return _dbContext.Games.Find(id);
        }

        public Games RemoveById(double id) {
            var gameRemove = _dbContext.Games.Find(id);
            if (gameRemove == null)
                return gameRemove;
            _dbContext.Games.Remove(gameRemove);
            _dbContext.SaveChangesAsync();
            return gameRemove;
        }

        public Games Update(Games item) {
            throw new NotImplementedException();
        }

        public Games Get(Games item) {
            return _dbContext.Games.Find(item);
        }
    }
}
