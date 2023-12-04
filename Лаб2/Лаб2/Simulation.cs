using System;
using System.Collections.Generic;
using Лаб2.DbContext;
using Лаб2.Repository;

namespace Лаб2
{
    public class Simulation
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            GameFactory gameFactory = new GameFactory();
            DbContext.DbContext dbContext = new DbContext.DbContext();

            // Створюємо репозиторії для роботи з базою даних
            IPlayerRepository playerRepository = new PlayerRepository(dbContext);
            IGameRepository gameRepository = new GameRepository(dbContext);

            Console.WriteLine("Виберіть тип гри:");
            Console.WriteLine("1. Стандартна гра");
            Console.WriteLine("2. Тренувальна гра");
            Console.WriteLine("3. Гра з одним гравцем");

            int gameTypeChoice = GetChoice(1, 3);

            Console.WriteLine("\nВиберіть тип аккаунта:");
            Console.WriteLine("1. Стандартний аккаунт");
            Console.WriteLine("2. Аккаунт зі зменшеними втратами");
            Console.WriteLine("3. Аккаунт з бонусами за серію перемог");

            int accountTypeChoice = GetChoice(1, 3);

            Console.WriteLine("\nВиберіть гравця:");
            Console.WriteLine("1. Гравець1");
            Console.WriteLine("2. Гравець2");
            Console.WriteLine("3. Гравець3");

            int playerChoice = GetChoice(1, 3);

            Console.WriteLine("\nВиберіть гру:");
            Console.WriteLine("1. Гра #1");
            Console.WriteLine("2. Гра #2");
            Console.WriteLine("3. Гра #3");

            int gameChoice = GetChoice(1, 3);

            Console.WriteLine("\nСимуляція гри...");

            // Створюємо аккаунт гравця за його вибором
            Player player = playerRepository.ReadPlayer(playerChoice);
            GameAccount playerAccount = CreatePlayer(gameFactory, accountTypeChoice, player.Name, player.Rating);

            // Створюємо аккаунт суперника, який буде мати випадковий тип аккаунта
            Player opponent = GetRandomOpponent(dbContext, playerChoice);
            int opponentAccountType = new Random().Next(1, 4);
            GameAccount opponentAccount =
                CreatePlayer(gameFactory, opponentAccountType, opponent.Name, opponent.Rating);

            // Створюємо гру за її вибором
            GameData game = gameRepository.ReadGame(gameChoice);

            // Визначаємо, хто переміг у грі
            bool playerWon = new Random().Next(0, 2) == 0;

            // Оновлюємо рейтинги гравців в базі даних та в аккаунтах
            if (playerWon)
            {
                playerAccount.WinGame(opponentAccount, game.Rating);
                opponentAccount.LoseGame(playerAccount, game.Rating);
            }
            else
            {
                playerAccount.LoseGame(opponentAccount, game.Rating);
                opponentAccount.WinGame(playerAccount, game.Rating);
            }

            playerRepository.UpdatePlayerRating(player.Id, playerAccount.CurrentRating);
            playerRepository.UpdatePlayerRating(opponent.Id, opponentAccount.CurrentRating);

            Console.WriteLine("\nСтатистика гравців після симуляції:");
            Console.WriteLine();
            playerAccount.GetStats();
            Console.WriteLine();
            opponentAccount.GetStats();

            Console.WriteLine("\nСписок всіх створених гравців:");
            foreach (var p in dbContext.Players)
            {
                Console.WriteLine(
                    $"Ідентифікатор: {p.Id}, Ім'я: {p.Name}, Рейтинг: {p.Rating}, Тип аккаунта: {p.AccountType}");
            }

            Console.WriteLine("\nСписок всіх створених ігор:");
            foreach (var g in dbContext.Games)
            {
                Console.WriteLine($"Ідентифікатор: {g.Id}, Рейтинг: {g.Rating}, Тип гри: {g.GameType}");
            }
        }

        static int GetChoice(int minValue, int maxValue)
        {
            int choice;
            while (true)
            {
                Console.Write($"Введіть число від {minValue} до {maxValue}: ");
                if (int.TryParse(Console.ReadLine(), out choice) && choice >= minValue && choice <= maxValue)
                {
                    break;
                }

                Console.WriteLine("Некоректне введення. Спробуйте ще раз.");
            }

            return choice;
        }

        static GameAccount CreatePlayer(GameFactory factory, int accountTypeChoice, string userName, int initialRating)
        {
            switch (accountTypeChoice)
            {
                case 1:
                    return factory.CreateStandardGameAccount(userName, initialRating);
                case 2:
                    return factory.CreateReducedLossGameAccount(userName, initialRating);
                case 3:
                    return factory.CreateWinningStreakGameAccount(userName, initialRating);
                default:
                    throw new ArgumentException("Некоректний вибір типу аккаунта.");
            }
        }

        static Game CreateGame(int gameTypeChoice, int rating)
        {
            switch (gameTypeChoice)
            {
                case 1:
                    return new StandardGame(rating);
                case 2:
                    return new TrainingGame();
                case 3:
                    return new SoloGame(rating);
                default:
                    throw new ArgumentException("Некоректний вибір типу гри.");
            }
        }

        static Player GetRandomOpponent(DbContext.DbContext dbContext, int playerId)
        {
            List<Player> opponents = dbContext.Players.FindAll(p => p.Id != playerId);
            int index = new Random().Next(0, opponents.Count);
            return opponents[index];
        }
    }
}