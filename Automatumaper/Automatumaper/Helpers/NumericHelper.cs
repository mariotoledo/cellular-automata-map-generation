using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Automatumaper.Helpers
{
    public class NumericHelper
    {
        private static readonly Random Randomizer = new Random();
        private static readonly object syncLock = new object();
        public static double GetRandomNumber()
        {
            lock (syncLock)
            {
                return Randomizer.NextDouble();
            }
        }
    }
}
