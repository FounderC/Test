﻿namespace Лаб2
{
    public class WinningStreakGameAccount : GameAccount
    {
        private int consecutiveWins;
        
        public WinningStreakGameAccount(string userName, int initialRating) : base(userName, initialRating)
        {
            consecutiveWins = 0;
        }
        
        public override int CalculateRatingForWin(int gameRating)
        {
            consecutiveWins++;
            int bonus = consecutiveWins;
            return gameRating + bonus;
        }
        
        public override int CalculateRatingForLoss(int gameRating)
        {
            consecutiveWins = 0;
            return gameRating;
        }
        
        public override string GetAccountType()
        {
            return "З бонусами за серію перемог";
        }
    }
}