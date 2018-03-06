using DrinkAndGo.Data.Interfaces;
using DrinkAndGo.Data.Models;
using System.Collections.Generic;

namespace DrinkAndGo.Data.Mocks
{
    public class MockCategoryRepository : ICategoryRepository
    {
        public IEnumerable<Category> Categories
        {
            get => new List<Category>
            {
                new Category{CategoryName="Alcoholic", Description="All alcoholic drinks"},
                new Category{CategoryName="Non-alcoholic", Description="All non-alcoholic drinks"}
            };
        }
    }
}
