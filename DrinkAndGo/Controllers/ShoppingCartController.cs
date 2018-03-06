using DrinkAndGo.Data.Interfaces;
using DrinkAndGo.Data.Models;
using DrinkAndGo.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace DrinkAndGo.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly ShoppingCart _shoppingCart;
        private readonly IDrinkRepository _drinkRepository;

        public ShoppingCartController(ShoppingCart shoppingCart, IDrinkRepository drinkRepository)
        {
            _shoppingCart = shoppingCart;
            _drinkRepository = drinkRepository;
        }

        public ViewResult Index()
        {
            _shoppingCart.GetShoppingCart();

            var shoppingCartViewModel = new ShoppingCartViewModel
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };
            return View(shoppingCartViewModel);
        }

        public RedirectToActionResult AddToShoppingCart(int drinkId)
        {
            var selectedDrink = _drinkRepository.Drinks.FirstOrDefault(d => d.DrinkId == drinkId);

            if (selectedDrink != null) _shoppingCart.AddToCart(selectedDrink);

            return RedirectToAction("Index");
        }

        public RedirectToActionResult RemoveFromShoppingCart(int drinkId)
        {
            var selectedDrink = _drinkRepository.Drinks.FirstOrDefault(d => d.DrinkId == drinkId);

            if (selectedDrink != null) _shoppingCart.RemoveFromCart(selectedDrink);

            return RedirectToAction("Index");
        }
    }
}