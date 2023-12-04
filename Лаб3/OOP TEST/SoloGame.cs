namespace OOP_TEST
{
    public class SoloGame : Game
    {
        private int playerRating;

        public SoloGame(int playerRating)
        {
            this.playerRating = playerRating;
        }

        public override int GetGameRating()
        {
            return playerRating;
        }
    }
}