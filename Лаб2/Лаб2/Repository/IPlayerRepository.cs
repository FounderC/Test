using Лаб2.DbContext;

namespace Лаб2.Repository
{
    public interface IPlayerRepository
    {
        // Методи CRUD для класу Player
        void CreatePlayer(Player player);
        Player ReadPlayer(int id);
        void UpdatePlayer(Player player);
        void DeletePlayer(int id);
        void UpdatePlayerRating(int id, int newRating); // Додав оголошення методу UpdatePlayerRating
    }
}