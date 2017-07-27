using _07.Equality_Logic.Interfaces;
using System;
using System.Collections.Generic;

namespace _07.Equality_Logic.Comparers
{
    public class PersonComparer : IEqualityComparer<IPerson>, IComparer<IPerson>
    {
        public bool Equals(IPerson x, IPerson y)
        {
            return string.Equals(x.Name, y.Name, StringComparison.InvariantCulture) &&
                   x.Age.Equals(y.Age);
        }

        public int GetHashCode(IPerson obj)
        {
            return obj.Name.GetHashCode() + obj.Age.GetHashCode();
        }

        public int Compare(IPerson x, IPerson y)
        {
            if (!string.Equals(x.Name, y.Name, StringComparison.InvariantCulture))
            {
                return string.Compare(x.Name, y.Name, StringComparison.InvariantCulture);
            }

            if (!x.Age.Equals(y.Age))
            {
                return x.Age.CompareTo(y.Age);
            }

            return 0;
        }
    }
}