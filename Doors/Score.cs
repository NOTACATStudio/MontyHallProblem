using System;

namespace Doors
{
    public class Score
    {
        public int Wins { get; set; } 
        public int Losses { get; set; }
        public decimal Ratio => Losses == 0 ? 100 : Math.Round((decimal)Wins/(Wins+Losses)*100, 2);
    }
}