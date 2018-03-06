using Microsoft.AspNetCore.Mvc;

namespace DrinkAndGo.Controllers
{
    public class ContactController : Controller
    {
        public ViewResult Index()
        {
            return View();
        }
    }
}