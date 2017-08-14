using System.Collections.Generic;

namespace _05.Integration_Tests.Contracts
{
    public interface IDatabaseController
    {
        void AddCategory(ICategory category);

        void AddCategories(IEnumerable<ICategory> categories);

        void RemoveCategory(string categoryName);

        void RemoveCategories(string[] categoriesNamesToRemove);

        void AssignChildCategoryToSingleCategory(string baseCategoryName);

        void AssignUserToCategory(IUser user, string categoryName);
    }
}