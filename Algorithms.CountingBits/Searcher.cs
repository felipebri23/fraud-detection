
namespace Payvision.CodeChallenge.Algorithms.CountingBits
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Searcher : ICountable
    {
        const char pattern = '1';

        public IEnumerable<int> Get(char[] binary)
        {
            var lastIndex = 0;
            return Enumerable.Range(0, binary.Count(x => x == pattern)).Select(x =>
            {
                var index = Array.IndexOf(binary, pattern, lastIndex);
                lastIndex = index + 1;
                return index;
            });
        }
    }
}
