using DrinkAndGo.Data.Interfaces;
using DrinkAndGo.Data.Models;
using DrinkAndGo.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DrinkAndGo.Controllers
{
    public class OrderController : Controller
    {
        private readonly ShoppingCart _shoppingCart;
        private readonly IOrderRepository _orderRepository;

        public OrderController(ShoppingCart shoppingCart, IOrderRepository orderRepository)
        {
            _shoppingCart = shoppingCart;
            _orderRepository = orderRepository;
        }

        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Checkout(OrderViewModel orderViewModel)
        {
            _shoppingCart.GetShoppingCart();

            if (_shoppingCart.ShoppingCartItems.Count == 0)
                ModelState.AddModelError("", "You card is empty, add some drinks first");

            if (ModelState.IsValid)
            {
                var order = new Order(orderViewModel.FirstName, orderViewModel.LastName, orderViewModel.AddressLine1, orderViewModel.AddressLine2, orderViewModel.ZipCode, orderViewModel.State, orderViewModel.Country, orderViewModel.PhoneNumber, orderViewModel.Email, orderViewModel.City);

                _orderRepository.CreateOrder(order);
                _shoppingCart.ClearCart();
                return RedirectToAction("CheckoutComplete");
            }

            return View(orderViewModel);
        }

        public IActionResult CheckoutComplete()
        {
            ViewBag.CheckoutCompleteMessage = "Thanks for your order! :)";
            return View();
        }
    }
}