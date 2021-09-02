using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace Api
{
    public class CountryEqualityComparer : IEqualityComparer<Tuple<string, int>>
    {
        public bool Equals(Tuple<string, int> x, Tuple<string, int> y)
        {
            return x.Item1 == y.Item1;
        }

        // If Equals() returns true for a pair of objects 
        // then GetHashCode() must return the same value for these objects.

        public int GetHashCode([DisallowNull] Tuple<string, int> obj)
        {
            return obj.Item1.GetHashCode();
        }
    }
}
