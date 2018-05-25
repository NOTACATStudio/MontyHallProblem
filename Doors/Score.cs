using System;

namespace Doors
{
    public class Score
    {
        public Score(int iterations)
        {
            Iterations = iterations;
        }

        public int Iterations { get; set; }
        public int Wins { get; set; } 
        public int Losses { get; set; }
        public decimal Ratio => Losses == 0 ? 100 : Math.Round(((decimal)Wins/Iterations)*100, 2);
    }
}