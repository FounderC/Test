using System;
using System.Collections.Generic;
using System.Linq;
using OOP_TEST.DbContext;

namespace OOP_TEST.Repository
{
    public class GameRepository
    {
        private readonly DbContext.DbContext _dbContext;

        public GameRepository(DbContext.DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Create(GameEntity game)
        {
            // Генерація ідентифікатора
            game.Id = _dbContext.Games.Count + 1;

            // ADD PLAY to DbContext
            _dbContext.Games.Add(game);
        }

        public List<GameEntity> ReadAll()
        {
            return _dbContext.Games;
        }

        public GameEntity ReadById(int gameId)
        {
            return _dbContext.Games.FirstOrDefault(g => g.Id == gameId);
        }

        public void Update(GameEntity game)
        {
            // Знаходимо гру в списку по її Id та оновлюємо інформацію
            var existingGame = _dbContext.Games.FirstOrDefault(g => g.Id == game.Id);
            if (existingGame != null)
            {
                existingGame.GameRating = game.GameRating;
            }
        }

        public void Delete(int gameId)
        {
            // Ну тут зрозуміло наче, знаходимо гру в списку по її Id та видаляємо її, как-то так
            var gameToDelete = _dbContext.Games.FirstOrDefault(g => g.Id == gameId);
            if (gameToDelete != null)
            {
                _dbContext.Games.Remove(gameToDelete);
            }
        }
    }
}