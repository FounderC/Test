using System;
using System.Collections.Generic;
using OOP_TEST.DbContext;

namespace OOP_TEST.Repository
{
    public interface IPlayerRepository
    {
        void Create(PlayerEntity player);
        List<PlayerEntity> ReadAll();
        PlayerEntity ReadById(int playerId);
        void Update(PlayerEntity player);
        void Delete(int playerId); 
    }
}