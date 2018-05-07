using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using The_Book_Cave.Services;

namespace The_Book_Cave.Controllers
{
    public class ShoppingCartController: Controller
    {
        private BookService _bookService;
         public ShoppingCartController()
        {
            _bookService = new BookService();
        }

        [Authorize]
        public IActionResult Index(int id)
        {
            var shoppingItem = _bookService.GetBookById(id);
            return View(shoppingItem);
        }
    }
}