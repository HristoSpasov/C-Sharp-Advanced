using _05.Integration_Tests.Contracts;
using _05.Integration_Tests.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.Integration_Tests.Core
{
    public class DatabaseController : IDatabaseController
    {
        private IDatabase database;

        public DatabaseController(IDatabase database)
        {
            this.database = database;
        }

        public void AddCategory(ICategory category)
        {
            if (category == null)
            {
                throw new CategoryNullException();
            }

            if (string.IsNullOrWhiteSpace(category.Name))
            {
                throw new CategoryNameException();
            }

            if (category.Users == null)
            {
                throw new CategoryUsersNullException();
            }

            if (category.ChildCategory == null)
            {
                throw new CategoryNullException();
            }

            if (this.database.Categories.Any(n => n.Name == category.Name))
            {
                throw new CategoryExistsException(category.Name);
            }

            this.database.Categories.ToList().Add(category);
        }

        public void AddCategories(IEnumerable<ICategory> categories)
        {
            foreach (var category in categories)
            {
                this.AddCategory(category);
            }
        }

        public void RemoveCategory(string categoryName)
        {
            ICategory toRemove = this.database.Categories.FirstOrDefault(n => n.Name == categoryName);

            if (toRemove == null)
            {
                throw new CategoryNotFoundException(categoryName);
            }

            ICategory child = toRemove.ChildCategory; // Child categoty

            this.AddCategory(child); // If not existing add child category as base category

            ICategory childAddedCategory = this.database.Categories.FirstOrDefault(n => n.Name == child.Name); // Search for newly added category

            if (childAddedCategory == null)
            {
                throw new ChildCategoryNotAddedAsBaseCategory(child.Name);
            }

            // Add all not duplicated users from category to delete to newly assigned category, if any
            if (toRemove.Users.Any())
            {
                foreach (var childCategoryUser in toRemove.Users)
                {
                    this.AssignUserToCategory(childCategoryUser, childAddedCategory.Name);
                }
            }
        }

        public void RemoveCategories(string[] categoriesNamesToRemove)
        {
            foreach (var category in categoriesNamesToRemove)
            {
                this.RemoveCategory(category);
            }
        }

        public void AssignChildCategoryToSingleCategory(string baseCategoryName)
        {
            if (string.IsNullOrWhiteSpace(baseCategoryName))
            {
                throw new ArgumentNullException("Base category name cannot be null or whitespace");
            }

            ICategory searchCategory = this.database.Categories.FirstOrDefault(n => n.Name == baseCategoryName);

            if (searchCategory == null)
            {
                throw new CategoryNotFoundException(baseCategoryName);
            }

            ICategory childCategory = searchCategory.ChildCategory; // Child category
            searchCategory.ChildCategory = null; // Remove child category from current category

            this.AddCategory(childCategory); // Add child category as single category
        }

        public void AssignUserToCategory(IUser user, string categoryName)
        {
            if (user == null)
            {
                throw new UserNullException();
            }

            if (string.IsNullOrWhiteSpace(user.Name))
            {
                throw new UserNameException();
            }

            if (user.Categories == null)
            {
                throw new UserCategoriesNullException();
            }

            if (string.IsNullOrWhiteSpace(categoryName))
            {
                throw new ArgumentNullException("Target category cannot be null or whitespace");
            }

            ICategory targetCategory = this.database.Categories.FirstOrDefault(n => n.Name == categoryName);

            if (targetCategory == null)
            {
                throw new CategoryNotFoundException(categoryName);
            }

            if (targetCategory.Users.Any(n => n.Name == user.Name))
            {
                throw new UserExistsException(user.Name, targetCategory.Name);
            }

            targetCategory.Users.ToList().Add(user);
        }
    }
}