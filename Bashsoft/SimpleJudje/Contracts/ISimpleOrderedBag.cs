using System;
using System.Collections.Generic;

namespace SimpleJudje.Contracts
{
    public interface ISimpleOrderedBag<T> : IEnumerable<T> 
        where T : IComparable<T>
    {
        void Add(T element);

        void AdAll(ICollection<T> collection);

        int Size { get; }

        string JoinWith(string joiner);
    }
}
