using System.Collections.Generic;

namespace _05.Integration_Tests.Contracts
{
    public interface ICategory
    {
        string Name { get; }

        IEnumerable<IUser> Users { get; }

        ICategory ChildCategory { get; set; }
    }
}