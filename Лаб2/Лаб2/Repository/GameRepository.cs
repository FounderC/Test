using Лаб2.DbContext;

namespace Лаб2.Repository
{
    public class GameRepository : IGameRepository
    {
        private DbContext.DbContext dbContext;

        // Конструктор
        public GameRepository(DbContext.DbContext context)
        {
            dbContext = context;
        }

        // Методи CRUD для класу GameData
        public void CreateGame(GameData game)
        {
            dbContext.Games.Add(game);
        }

        public GameData ReadGame(int id)
        {
            return dbContext.GetGameById(id);
        }

        public void UpdateGame(GameData game)
        {
            GameData oldGame = dbContext.GetGameById(game.Id);
            if (oldGame != null)
            {
                oldGame.Rating = game.Rating;
                oldGame.GameType = game.GameType;
            }
        }

        public void DeleteGame(int id)
        {
            GameData game = dbContext.GetGameById(id);
            if (game != null)
            {
                dbContext.Games.Remove(game);
            }
        }
    }
}