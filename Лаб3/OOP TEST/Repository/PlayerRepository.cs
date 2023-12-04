using System;
using System.Collections.Generic;
using System.Linq;
using OOP_TEST.DbContext;

namespace OOP_TEST.Repository
{
    public class PlayerRepository
    {
        private readonly DbContext.DbContext _dbContext;

        public PlayerRepository(DbContext.DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Create(PlayerEntity player)
        {
            // Генеруємо унікальний ідентифікатор гравця
            player.Id = _dbContext.Players.Count + 1;

            // Додаємо гравця до списку в DbContext
            _dbContext.Players.Add(player);
        }

        public List<PlayerEntity> ReadAll()
        {
            return _dbContext.Players;
        }

        public PlayerEntity ReadById(int playerId)
        {
            return _dbContext.Players.FirstOrDefault(p => p.Id == playerId);
        }

        public void Update(PlayerEntity player)
        {
            // Знаходимо гравця в списку по його Id та оновлюємо інформацію
            var existingPlayer = _dbContext.Players.FirstOrDefault(p => p.Id == player.Id);
            if (existingPlayer != null)
            {
                existingPlayer.UserName = player.UserName;
                existingPlayer.CurrentRating = player.CurrentRating;
                existingPlayer.GamesCount = player.GamesCount;
                // Наче ничего не забув, якщо забув то потрібно добавить додаткову логіку оновлення інших полів
            }
        }

        public void Delete(int playerId)
        {
            // Знаходимо гравця в списку по його Id та видаляємо його
            var playerToDelete = _dbContext.Players.FirstOrDefault(p => p.Id == playerId);
            if (playerToDelete != null)
            {
                _dbContext.Players.Remove(playerToDelete);
            }
        }
    }
}