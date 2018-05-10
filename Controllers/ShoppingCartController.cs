using System.Dynamic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using The_Book_Cave.Data;
using The_Book_Cave.Services;
using The_Book_Cave.Models.ViewModels;
using System.Linq;
using The_Book_Cave.Models.InputModels;
using System;
using System.Security.Claims;
using The_Book_Cave.Data.EntityModels;

namespace The_Book_Cave.Controllers
{
    [Authorize]
    public class ShoppingCartController : Controller
    {
        private UserService _userService;
        private CartService _cartService;
        private BookService _bookService;
        private DataContext _db = new DataContext();

        public ShoppingCartController()
        {
            _cartService = new CartService();
            _bookService = new BookService();
            _userService = new UserService();
            
        }

     public IActionResult Index(int? id)
        {
            var cart = CartService.GetCart(this.HttpContext);

            var cartId = cart.ShoppingCartId;

            dynamic myModel = new ExpandoObject();
            
            var cartModel = new ShoppingCartViewModel
            {
                CartItems = _cartService.GetCartItems(cartId),
                CartTotal = _cartService.GetTotal(cartId)
            };

            var userModel = _userService.GetAllUsers();

            var books = (from b in _db.Books
                        join c in _db.Carts on b.Id equals c.BookId
                        where c.CartId == cartId
                        select new BookListViewModel
                        {
                            Id = b.Id,
                            Title = b.Title,
                            ISBN = b.ISBN,
                            Publisher = b.Publisher,
                            PublicationYear = b.PublicationYear,
                            Price = b.Price,
                            Rating = b.Rating,
                            RatingCount = b.RatingCount,
                            Summary = b.Summary,
                            Review = b.Review,
                            Image = b.Image,
                            Pages = b.Pages,
                            Type = b.Type,
                            Language = b.Language,
                            AuthorId = b.AuthorId,
                            Quantity = c.Quantity,
                        }).ToList();
            
            return View(books);
        }

        [Authorize]
        public IActionResult AddToCart(int bookId)
        {
            var books = _bookService.GetAllBooks();

            var bookAdded = (from book in books
                            where book.Id == bookId
                            select book).SingleOrDefault();

            var cart = CartService.GetCart(this.HttpContext);


            _cartService.AddToCart(bookAdded, this.HttpContext);

            return Redirect("/ShoppingCart");
        }

       [HttpPost]
        public IActionResult RemoveFromCart(int id)
        {
            var cart = CartService.GetCart(this.HttpContext);
            string cartId = cart.ShoppingCartId;
         string bookName = _db.Carts
                .Single(item => item.BookId == id).Book.Title;    
                
                 int itemCount = _cartService.RemoveFromCart(cartId);

            // var results = new ShoppingCartViewModel
            // {
            //     Message = " has been removed from your shopping cart.",
            //     // CartTotal = cart.GetTotal(),
            //     // CartCount = cart.GetCount(),
            //     ItemCount = itemCount,
            //     DeleteId = id
            // };

          

            return Ok();
        }
        
        [HttpGet]
        [HttpGet]
        public IActionResult Checkout(string email)
        {
            var users = _userService.GetAllUsers();

            var user = (from a in users
                         where a.Email == email
                         select a).SingleOrDefault();
            return View(user);
        }
       /* 
        [HttpPost]
        public IActionResult Checkout(UserInputModel userinfo)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }
            
            var user = new User()
                {
                    Name = userinfo.Name,
                    Email = userinfo.Email,
                    StreetName = userinfo.StreetName,
                    HouseNumber = userinfo.HouseNumber,
                    City = userinfo.City,
                    Country = userinfo.Country,
                    ZipCode = userinfo.ZipCode,

                };
                _db.Users.Add(user);
            
            return RedirectToAction("ReviewStep");
        }
        
        [HttpGet]
        public IActionResult ReviewStep()
        {
            var user = HttpContext.User.Identity.Name;

            var cart = CartService.GetCart(this.HttpContext);

            var cartId = cart.ShoppingCartId;

            dynamic myModel = new ExpandoObject();
            
            var cartModel = new ShoppingCartViewModel
            {
                CartItems = _cartService.GetCartItems(cartId),
                CartTotal = _cartService.GetTotal(cartId)
            };

            var accounts = _userService.GetAllUsers();

            var accountmodel = (from a in accounts
                         where a.Email == user
                         select a).SingleOrDefault();

            myModel.cartItems = cartModel;
            myModel.account = accountmodel;

            return View(myModel);
        }
        
        public IActionResult ConfirmationStep()
        {
            var user = HttpContext.User.Identity.Name;
            var cart = CartService.GetCart(this.HttpContext);
            var cartId = cart.ShoppingCartId;

            dynamic myModel = new ExpandoObject();
            
            var cartItems = _cartService.GetCartItems(cartId);
            /* 
            foreach (var item in cartItems)
            {
                var cartItem = new Purchased()
                {
                    CartId = item.CartId,
                    BookId = item.BookId,
                    Quantity = item.Quantity,
                    DateCreated = item.DateCreated,
                    Book = item.Book
                };
                _db.Purchased.Add(cartItem);
            }
            
            foreach (var item in cartItems)
            {
                    var thebook = (from b in _db.Books
                            where b.Id == item.BookId
                            select b).SingleOrDefault();

                    thebook.Quantity -= item.Quantity;
                    //thebook.BoughtCopies += item.Quantity;
            }
            
            foreach (var item in cartItems)
            {   
                RemoveFromCart(item.BookId);
            }

            _db.SaveChanges();

            return View("Confirmation");
        }

        // [HttpGet]
        // public int GetCartCount()
        // {
        //     var cart = CartService.GetCart(this.HttpContext);
        //     var cartId = cart.ShoppingCartId;
        //     return _cartService.GetCartItems(cartId).Count;
            
        // }

    }
*/
    }
}
