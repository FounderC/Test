using Лаб2.DbContext;

namespace Лаб2.Repository
{
    public class PlayerRepository : IPlayerRepository
    {
        private DbContext.DbContext dbContext;
        
        public PlayerRepository(DbContext.DbContext context)
        {
            dbContext = context;
        }

        public void CreatePlayer(Player player)
        {
            dbContext.Players.Add(player);
        }

        public Player ReadPlayer(int id)
        {
            return dbContext.GetPlayerById(id);
        }

        public void UpdatePlayer(Player player)
        {
            Player oldPlayer = dbContext.GetPlayerById(player.Id);
            if (oldPlayer != null)
            {
                oldPlayer.Name = player.Name;
                oldPlayer.Rating = player.Rating;
                oldPlayer.AccountType = player.AccountType;
            }
        }

        public void DeletePlayer(int id)
        {
            Player player = dbContext.GetPlayerById(id);
            if (player != null)
            {
                dbContext.Players.Remove(player);
            }
        }

        public void UpdatePlayerRating(int id, int newRating)
        {
            Player player = dbContext.GetPlayerById(id);
            if (player != null)
            {
                player.Rating = newRating;
            }
        }
    }
}