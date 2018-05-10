using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using The_Book_Cave.Data.EntityModels;
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
        public IActionResult Index(int? id)
        {
            var shoppingItem = _bookService.AddToCart(id);

            return View(shoppingItem);
        }
        public IActionResult CheckOut()
        {
            return View();
        }
    }
}