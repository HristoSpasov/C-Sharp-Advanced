using System;

namespace _05.Comparing_Objects.Interfaces
{
    public interface IPerson : IComparable<IPerson>
    {
        string Name { get; }
        int Age { get; }
        string Town { get; }
    }
}