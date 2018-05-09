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

        [Authorize]
        public ViewResult Index()
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

        public RedirectToActionResult RemoveFromShoppingCart(int bookid)
        {
            var selectedBook = _bookService.GetBookBookById(bookid);
            if (selectedBook != null)
            {
                _shoppingCart.RemoveFromCart(selectedBook);
            }
            return RedirectToAction("Index");
        }

    }
}