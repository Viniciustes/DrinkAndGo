using DrinkAndGo.Data.Context;
using DrinkAndGo.Data.Interfaces;
using DrinkAndGo.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DrinkAndGo.Data.Repositories
{
    public class DrinkRepository : Repository, IDrinkRepository
    {
        private readonly AppDbContext _appDbContext;

        public DrinkRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Drink> Drinks => _appDbContext.Drinks.Include(d => d.Category);

        public IEnumerable<Drink> PreferredDrinks => _appDbContext.Drinks.Where(d => d.IsPreferredDrink == true).Include(d => d.Category);

        public Drink GetDrinkById(int drinkId) => _appDbContext.Drinks.FirstOrDefault(d => d.DrinkId == drinkId);
    }
}