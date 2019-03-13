
namespace Payvision.CodeChallenge.Algorithms.CountingBits
{
    using System.Collections.Generic;

    internal interface ICountable
    {
        IEnumerable<int> Get(char[] binary);
    }
}
