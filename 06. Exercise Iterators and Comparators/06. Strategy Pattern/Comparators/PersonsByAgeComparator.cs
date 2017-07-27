using _06.Strategy_Pattern.Interfaces;
using System.Collections.Generic;

namespace _06.Strategy_Pattern.Comparators
{
    public class PersonsByAgeComparator : IComparer<IPerson>
    {
        public int Compare(IPerson x, IPerson y)
        {
            return x.Age.CompareTo(y.Age);
        }
    }
}