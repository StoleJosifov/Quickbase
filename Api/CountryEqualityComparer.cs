using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Api
{
    public class CountryEqualityComparer : IEqualityComparer<Tuple<string, int>>
    {
        public bool Equals(Tuple<string, int> x, Tuple<string, int> y)
        {
            return y != null && x != null && x.Item1 == y.Item1;
        }

        // If Equals() returns true for a pair of objects 
        // then GetHashCode() must return the same value for these objects.

        public int GetHashCode([DisallowNull] Tuple<string, int> obj)
        {
            return obj.Item1.GetHashCode();
        }
    }
}
