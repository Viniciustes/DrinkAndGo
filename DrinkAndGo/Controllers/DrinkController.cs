using DrinkAndGo.Data.Interfaces;
using DrinkAndGo.ViewModels;
using Microsoft.AspNetCore.Mvc;


namespace DrinkAndGo.Controllers
{
    public class DrinkController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IDrinkRepository _drinkRepository;

        public DrinkController(ICategoryRepository categoryRepository, IDrinkRepository drinkRepository)
        {
            _categoryRepository = categoryRepository;
            _drinkRepository = drinkRepository;
        }

        public ViewResult List()
        {
            ViewBag.Name = "DotNet, How?";

            var drinkListViewModel = new DrinkListViewModel
            {
                Drinks = _drinkRepository.Drinks,
                CurrentCategory = "DrinkCategory"
            };

            return View(drinkListViewModel);
        }
    }
}