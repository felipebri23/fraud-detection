
namespace Payvision.CodeChallenge.Algorithms.CountingBits
{
    using System.Collections.Generic;
    using System.Linq;

    internal class Counter : ICountable
    {
        public IEnumerable<int> Get(char[] binary)
        {
            return new List<int> { binary.Count(x => x == '1') };
        }
    }
}
