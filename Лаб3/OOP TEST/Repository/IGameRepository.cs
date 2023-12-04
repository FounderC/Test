using System;
using System.Collections.Generic;
using OOP_TEST.DbContext;

namespace OOP_TEST.Repository
{
    public interface IGameRepository
    {
        void Create(GameEntity game);
        List<GameEntity> ReadAll();
        GameEntity ReadById(int gameId);
        void Update(GameEntity game);
        void Delete(int gameId);
    }
}