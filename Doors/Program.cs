using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace Doors
{
    class Program
    {
        static void Main(string[] args)
        {
            RunDoorSimulation();
        }

        private static void RunDoorSimulation()
        {
            var stopwatch = new Stopwatch();
            var choosy = new Choosy();
            var iterations = 1000000000;
            var score = new Score();
            stopwatch.Start();
            for (int i = 0; i < iterations; i++)
            {
                if (i > 1 && i % 100000 == 0)
                {
                    PrintTime(score, stopwatch, i, iterations);
                }
                var doorSim = new DoorSim(choosy);
                if (doorSim.RunDoorSimulation())
                {
                    score.Wins++;
                }
                else
                {
                    score.Losses++;
                }
            }
            stopwatch.Stop();

            PrintResults(score, stopwatch, iterations);
        }

        private static void PrintResults(Score score, Stopwatch stopwatch, int i)
        {
            PrintScoreInfo(score);
            Console.WriteLine($"Iterations: {i}");
            Console.WriteLine($"Total Time Elapsed: {stopwatch.Elapsed.Hours} Hours {stopwatch.Elapsed.Minutes} Minutes {stopwatch.Elapsed.Seconds} Seconds");
        }

        private static void PrintTime(Score score, Stopwatch stopwatch, int i, int iterations)
        {
            Console.Clear();
            PrintScoreInfo(score);
            Console.WriteLine($"Time Elapsed: {stopwatch.Elapsed.Hours} Hours {stopwatch.Elapsed.Minutes} Minutes {stopwatch.Elapsed.Seconds} Seconds");
            Console.WriteLine($"Iterations: {i}");
            Console.WriteLine($"Percent Complete: {Math.Round(((decimal)i / iterations) * 100, 2)}%");
        }

        private static void PrintScoreInfo(Score score)
        {
            Console.WriteLine($"Number of correct guesses: {score.Wins}");
            Console.WriteLine($"Number of incorrect guesses: {score.Losses}");
            Console.WriteLine($"Percentage of wins: {score.Ratio}%"); //this doesn't work during the live update
            Console.WriteLine("");
        }
    }
}
