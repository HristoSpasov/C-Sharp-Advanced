using _06.Strategy_Pattern.Interfaces;
using System;
using System.Collections.Generic;

namespace _06.Strategy_Pattern.Comparators
{
    public class PersonByNameLengthAndFirstNameLetterComparator : IComparer<IPerson>
    {
        public int Compare(IPerson x, IPerson y)
        {
            if (x.Name.Length != y.Name.Length)
            {
                return x.Name.Length.CompareTo(y.Name.Length);
            }

            return string.Compare(x.Name[0].ToString(), y.Name[0].ToString(),
                StringComparison.InvariantCultureIgnoreCase);
        }
    }
}