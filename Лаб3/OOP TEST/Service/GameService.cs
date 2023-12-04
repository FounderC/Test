using System;
using System.Collections.Generic;
using OOP_TEST.DbContext;
using OOP_TEST.Repository;

namespace OOP_TEST.Service
{
    public class GameService
    {
        private readonly GameRepository _gameRepository;

        public GameService(GameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        public void CreateGame(int gameRating)
        {
            var game = new GameEntity { GameRating = gameRating };
            _gameRepository.Create(game);
        }

        public List<GameEntity> GetAllGames()
        {
            return _gameRepository.ReadAll();
        }

        public GameEntity GetGameById(int gameId)
        {
            return _gameRepository.ReadById(gameId);
        }

        public void UpdateGame(GameEntity game)
        {
            _gameRepository.Update(game);
        }

        public void DeleteGame(int gameId)
        {
            _gameRepository.Delete(gameId);
        }
    }
}