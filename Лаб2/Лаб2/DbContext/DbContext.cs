using System.Collections.Generic;

namespace Лаб2.DbContext
{
    public class DbContext
    {
        public List<Player> Players { get; set; }
        public List<GameData> Games { get; set; }

        public DbContext()
        {
            Players = new List<Player>();
            Games = new List<GameData>();
            SeedData();
        }
        
        private void SeedData()
        {
            Players.Add(new Player { Id = 1, Name = "Гравець1", Rating = 100, AccountType = "Стандартний" });
            Players.Add(new Player { Id = 2, Name = "Гравець2", Rating = 100, AccountType = "Зі зменшеними втратами" });
            Players.Add(new Player { Id = 3, Name = "Гравець3", Rating = 100, AccountType = "З бонусами за серію перемог" });

            Games.Add(new GameData { Id = 1, Rating = 10, GameType = "Стандартна гра" });
            Games.Add(new GameData { Id = 2, Rating = 0, GameType = "Тренувальна гра" });
            Games.Add(new GameData { Id = 3, Rating = 20, GameType = "Гра з одним гравцем" });
        }
        
        public Player GetPlayerById(int id)
        {
            return Players.Find(p => p.Id == id);
        }
        
        public GameData GetGameById(int id)
        {
            return Games.Find(g => g.Id == id);
        }
        
        public void UpdatePlayerRating(int id, int newRating)
        {
            Player player = GetPlayerById(id);
            if (player != null)
            {
                player.Rating = newRating;
            }
        }
    }
}