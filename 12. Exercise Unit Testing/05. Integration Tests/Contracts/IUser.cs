using System.Collections.Generic;

namespace _05.Integration_Tests.Contracts
{
    public interface IUser
    {
        string Name { get; }

        IEnumerable<ICategory> Categories { get; }
    }
}