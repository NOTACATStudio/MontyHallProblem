using System;

namespace Doors
{
    public class Choosy
    {
        private readonly Random _random;

        public Choosy()
        {
            _random = new Random();
        }

        public int Choose(int availableDoors = 3)
        {
            return _random.Next(0, availableDoors);
        }
    }
}