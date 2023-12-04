using System;
using System.Collections.Generic;
using OOP_TEST.DbContext;

namespace OOP_TEST.Service
{
    public interface IPlayerService
    {
        void CreatePlayer(string userName, int initialRating);
        List<PlayerEntity> GetAllPlayers();
        PlayerEntity GetPlayerById(int playerId);
        void UpdatePlayer(PlayerEntity player);
        void DeletePlayer(int playerId);
    }
}