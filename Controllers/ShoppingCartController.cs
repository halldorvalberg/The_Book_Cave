using System.Dynamic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using The_Book_Cave.Data;
using The_Book_Cave.Services;
using The_Book_Cave.Models.ViewModels;
using System.Linq;

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

            var accountModel = _userService.GetAllUsers();

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

            return RedirectToAction("Index", "Home");
        }

        public IActionResult RemoveFromCart(int bookId)
        {
            var books = _bookService.GetAllBooks();

            var bookAdded = (from book in books
                            where book.Id == bookId
                            select book).SingleOrDefault();

            var cart = CartService.GetCart(this.HttpContext);

            _cartService.RemoveFromCart(bookAdded, this.HttpContext);

            return RedirectToAction("Index");
        }
        /*
        [HttpGet]
        public IActionResult Checkout(string email)
        {
            var accounts = _accountService.GetAllAccounts();

            var account = (from a in accounts
                         where a.Email == email
                         select a).SingleOrDefault();
            return View(account);
        }
        
        [HttpPost]
        public IActionResult Checkout(AccountInputModel updatedAccount)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }

            _accountService.ProcessAccount(updatedAccount);
            
            using (var db = new DataContext())
            {
                var account = (from a in db.Accounts
                            where a.Email == updatedAccount.Email
                            select a).FirstOrDefault();

                account.FirstName = updatedAccount.FirstName;
                account.LastName = updatedAccount.LastName;
                account.Email = updatedAccount.Email;
                account.BillingAddressStreet = updatedAccount.BillingAddressStreet;
                account.BillingAddressHouseNumber = updatedAccount.BillingAddressHouseNumber;
                account.BillingAddressLine2 = updatedAccount.BillingAddressLine2;
                account.BillingAddressCity = updatedAccount.BillingAddressCity;
                account.BillingAddressCountry = updatedAccount.BillingAddressCountry;
                account.BillingAddressZipCode = updatedAccount.BillingAddressZipCode;
                account.DeliveryAddressStreet = updatedAccount.DeliveryAddressStreet;
                account.DeliveryAddressHouseNumber = updatedAccount.DeliveryAddressHouseNumber;
                account.DeliveryAddressLine2 = updatedAccount.DeliveryAddressLine2;
                account.DeliveryAddressCity = updatedAccount.DeliveryAddressCity;
                account.DeliveryAddressCountry = updatedAccount.DeliveryAddressCountry;
                account.DeliveryAddressZipCode = updatedAccount.DeliveryAddressZipCode;
               

                db.SaveChanges();

            }
            return RedirectToAction("ReviewStep");

        }
<<<<<<< HEAD
        
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

            var accounts = _userService.GetAllAccounts();

            var accountmodel = (from a in accounts
                         where a.Email == user
                         select a).SingleOrDefault();

            myModel.cartItems = cartModel;
            myModel.account = accountmodel;

            return View(myModel);
        }
        
        public IActionResult ConfirmationStep()
=======
<<<<<<< HEAD
=======

=======
>>>>>>> 638c23270f4e8a1e56402684c2cbbc4ecf62130b
        public IActionResult CheckOut()
        {
            var user = HttpContext.User.Identity.Name;
            var cart = CartService.GetCart(this.HttpContext);
            var cartId = cart.ShoppingCartId;

            dynamic myModel = new ExpandoObject();
            
            var cartItems = _cartService.GetCartItems(cartId);
            
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

                RemoveFromCart(item.BookId);
            }

            _db.SaveChanges();

            return View("Final");
        }
         */
    }
}