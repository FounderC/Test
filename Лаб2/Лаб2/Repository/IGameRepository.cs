using Лаб2.DbContext;

namespace Лаб2.Repository
{
    public interface IGameRepository
    {
        // Методи CRUD для класу GameData
        void CreateGame(GameData game);
        GameData ReadGame(int id);
        void UpdateGame(GameData game);
        void DeleteGame(int id);
    }
}