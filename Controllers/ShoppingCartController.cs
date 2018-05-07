using Microsoft.AspNetCore.Mvc;

namespace The_Book_Cave.Controllers
{
    public class ShoppingCartController: Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}