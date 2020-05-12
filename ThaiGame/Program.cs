using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace ThaiGame
{
    internal class Program
    {
        private static void Main()
        {
            var successGames = 0;
            var gamesCount = 10000000;
            var watcher = new Stopwatch();
            watcher.Start();
            watcher.Stop();
            watcher.Reset();

            watcher.Start();
            Parallel.For(0, gamesCount, new ParallelOptions
            {
                MaxDegreeOfParallelism = 8
            },i =>
            {
                var game = new Game();
                var isSucceeded = game.Start();

                //Console.WriteLine($"Игра # {i}, успешно: {isSucceeded}");
                
                if (isSucceeded)
                    successGames++;
            });

            watcher.Stop();
;
            TimeSpan time = TimeSpan.FromMilliseconds(watcher.ElapsedMilliseconds);
            Console.WriteLine($"Прошло времени {time.Minutes} min {time.Seconds} sec");

            Console.WriteLine($"*** Всего игр: {gamesCount}, успешных: {successGames} ***");
        }
    }
}