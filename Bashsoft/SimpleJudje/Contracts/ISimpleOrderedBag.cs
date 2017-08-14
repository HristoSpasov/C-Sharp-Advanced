namespace SimpleJudje.Contracts
{
    using System;
    using System.Collections.Generic;

    public interface ISimpleOrderedBag<T> : IEnumerable<T>
        where T : IComparable<T>
    {
        int Size { get; }

        int Capacity { get; }

        void Add(T element);

        void AdAll(ICollection<T> collection);

        string JoinWith(string joiner);

        bool Remove(T element);
    }
}