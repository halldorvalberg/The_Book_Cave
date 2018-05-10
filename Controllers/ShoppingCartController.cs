using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using The_Book_Cave.Data.EntityModels;
using The_Book_Cave.Models.ViewModels;
using The_Book_Cave.Services;

namespace The_Book_Cave.Controllers
{
    public class ShoppingCartController : Controller
    {
         private BookService _bookService;
        private readonly ShoppingCart _shoppingCart;

        public ShoppingCartController(BookService bookService, ShoppingCart shoppingCart)
        {
            _bookService = bookService;
            _shoppingCart = shoppingCart;
        }
<<<<<<< HEAD
        public IActionResult Index(int? id)
=======

        [Authorize]
        public ViewResult Index()
>>>>>>> 638c23270f4e8a1e56402684c2cbbc4ecf62130b
        {
            Console.Write("CCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCC");
            var items = _shoppingCart.GetShoppingCartItems();
            return View(items);
        }

        [Authorize]
        public RedirectToActionResult AddToShoppingCart(int bookid)
        {   
            Console.Write("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA");
            var selectedBook = _bookService.GetBookBookById(bookid);
            if (selectedBook != null)
            {
                _shoppingCart.AddToCart(selectedBook, 1);
            }
            Console.Write("BBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBB");
            return RedirectToAction("Index");
        }

<<<<<<< HEAD
        public RedirectToActionResult RemoveFromShoppingCart(int bookid)
        {
            var selectedBook = _bookService.GetBookBookById(bookid);
            if (selectedBook != null)
            {
                _shoppingCart.RemoveFromCart(selectedBook);
            }
            return RedirectToAction("Index");
        }
<<<<<<< HEAD
=======

=======
>>>>>>> 638c23270f4e8a1e56402684c2cbbc4ecf62130b
        public IActionResult CheckOut()
        {
            return View();
        }
>>>>>>> f00584a4fda7bde39cadfea6c68f394b2b900b9e
    }
}