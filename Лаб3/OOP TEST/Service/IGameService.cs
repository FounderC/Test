using System;
using System.Collections.Generic;
using OOP_TEST.DbContext;

namespace OOP_TEST.Service
{
    public interface IGameService
    {
        void CreateGame(int gameRating);
        List<GameEntity> GetAllGames();
        GameEntity GetGameById(int gameId);
        void UpdateGame(GameEntity game);
        void DeleteGame(int gameId);  
    }
}