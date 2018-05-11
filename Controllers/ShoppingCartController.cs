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
using Microsoft.AspNetCore.Identity;
using The_Book_Cave.Models;
using System.Threading.Tasks;

namespace The_Book_Cave.Controllers
{
    

    [Authorize]
    public class ShoppingCartController : Controller
    {
        private CartService _cartService;
        private BookService _bookService;
        private readonly UserManager<ApplicationUser> _userManager;
        private DataContext _db = new DataContext();

        public ShoppingCartController(UserManager<ApplicationUser> userManager)
        {
            _cartService = new CartService();
            _bookService = new BookService();
            _userManager = userManager;
        }

     public async Task <IActionResult> Index(int? id)
        {   
            var user = await _userManager.GetUserAsync(User);
            var cartId = user.Email;
            
            var cartModel = new ShoppingCartViewModel
            {
                CartItems = _cartService.GetCartItems(cartId),
                CartTotal = _cartService.GetTotal(cartId)
            };

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

            _cartService.AddToCart(bookAdded, this.HttpContext);

            return Redirect("/ShoppingCart");
        }

        public IActionResult RemoveFromCart(int bookId)
        {
            var books = _bookService.GetAllBooks();

            var bookAdded = (from book in books
                            where book.Id == bookId
                            select book).SingleOrDefault();

            _cartService.RemoveFromCart(bookAdded, this.HttpContext);

            return RedirectToAction("Index");
        }

        
        [HttpGet]
        public IActionResult Checkout()
        {   
            return View(new OrderInputModel());
        }
       
        [HttpPost]
        public async Task<IActionResult> Checkout(OrderInputModel updateduser)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }

            var user = await _userManager.GetUserAsync(User);
                user.Address = updateduser.Address;
                user.City = updateduser.City;
                user.Country = updateduser.Country;
                user.ZipCode = updateduser.ZipCode;

              await _userManager.UpdateAsync(user);

            _db.SaveChanges();
                
            return RedirectToAction("ReviewStep");
        }
        
        [HttpGet]
        public async Task <IActionResult> ReviewStep()                                                                        
        {   //Sækir innskráðann notenda
            var user = await _userManager.GetUserAsync(User); 
            //Sækir körfu innskráða notenda
            var cartId = user.Email;

            ViewBag.CartTotal = _cartService.GetTotal(cartId);
            
            return View(new OrderViewModel {
                Name = (user.FirstName + " " + user.LastName),
                Email = user.Email,
                Address = user.Address,
                City = user.City,
                Country = user.Country,
                ZipCode = user.ZipCode,
            });
        }
        public async Task <IActionResult> ConfirmationStep()
        {
            var user = await _userManager.GetUserAsync(User); 
            var cartId = user.Email;

            var cartItems = _cartService.GetCartItems(cartId);
            
            foreach (var b in cartItems)
            {
                var cartItem = new Order()
                {
                    CartId = b.CartId,
                    BookId = b.BookId,
                    Quantity = b.Quantity,
                    DateCreated = b.DateCreated,
                    Book = b.Book,
                    Email = user.Email,
                    Address = user.Address,
                    City = user.City,
                    Country = user.Country,
                    ZipCode = user.ZipCode,
                };
                _db.Orders.Add(cartItem);
            }
            foreach (var q in cartItems)
            {
                var book = (from b in _db.Books
                            where b.Id == q.BookId
                            select b).SingleOrDefault();
                book.Quantity -= q.Quantity;
            }
            
            foreach (var t in cartItems)
            {   
                RemoveFromCart(t.BookId);
            }

            _db.SaveChanges();

            return View();
        }
    }
}
