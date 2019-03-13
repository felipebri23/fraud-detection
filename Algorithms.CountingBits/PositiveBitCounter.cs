// -----------------------------------------------------------------------
// <copyright file="BitCounter.cs" company="Payvision">
//     Payvision Copyright © 2017
// </copyright>
// -----------------------------------------------------------------------

namespace Payvision.CodeChallenge.Algorithms.CountingBits
{
    using System;
    using System.Collections.Generic;

    public class PositiveBitCounter
    {
        private readonly List<ICountable> knownCountables;

        public PositiveBitCounter()
        {
            knownCountables = new List<ICountable>
            {
                new Counter(),
                new Searcher()
            };
        }

        public IEnumerable<int> Count(int input)
        {
            if (input < 0)
            {
                throw new ArgumentException("El parámetro introducido debe ser mayor o igual que 0");
            }

            string binary = Convert.ToString(input, 2);

            var arr = binary.ToCharArray();
            Array.Reverse(arr);

            var counts = new List<int>();

            foreach (var counter in knownCountables)
            {
                counts.AddRange(counter.Get(arr));
            }

            return counts;
        }
    }
}