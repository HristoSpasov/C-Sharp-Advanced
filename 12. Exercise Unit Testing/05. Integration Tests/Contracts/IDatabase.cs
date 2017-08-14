using System.Collections.Generic;

namespace _05.Integration_Tests.Contracts
{
    public interface IDatabase
    {
        IEnumerable<ICategory> Categories { get; }

        IEnumerable<IUser> Users { get; }
    }
}