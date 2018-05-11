using System;
using System.Linq;
using System.Dynamic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using The_Book_Cave.Data;
using The_Book_Cave.Models;
using The_Book_Cave.Services;
using The_Book_Cave.Data.EntityModels;
using The_Book_Cave.Models.ViewModels;
using The_Book_Cave.Models.InputModels;

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
            //Tengir Controller við Book og Cart Sevice, og User Manager
            _cartService = new CartService();
            _bookService = new BookService();
            _userManager = userManager;
        }

        public async Task <IActionResult> Index(int? id)
        {   
            //Sækir upplýsingar um innskráðann notenda
            var user = await _userManager.GetUserAsync(User);

            var cartId = user.Email;
            //Sækir heildarkostnað körfu
            ViewBag.CartTotal = _cartService.GetTotal(cartId);
            //Sækir allar bækur í körfu
            var books = (from b in _db.Books
                        join c in _db.Carts on b.Id equals c.BookId
                        where c.CartId == cartId
                        select new BookListViewModel{
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
            //Sækir bók eftir id tölu 
            var bookAdded = _bookService.GetBookById(bookId);
            //Bætir bók í körfu sem er skráð á innskráðann notenda
            _cartService.AddToCart(bookAdded, this.HttpContext);

            return Redirect("/ShoppingCart");
        }
        public IActionResult RemoveFromCart(int bookId)
        {
            //Sækir bók eftir id tölu
            var bookRemoved = _bookService.GetBookById(bookId);
            //fjarlægir bók úr körfu skráð á innskráðann notenda
            _cartService.RemoveFromCart(bookRemoved, this.HttpContext);

            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task <IActionResult> Checkout()
        {   
            var user = await _userManager.GetUserAsync(User); 
            
            var cartId = user.Email;

            var cartItems = _cartService.GetCartItems(cartId);

            if(cartItems != null)
            {
                //Biður notenda um að filla inn sendingarupplýsingar skv OrderInputModel
                return View(new OrderInputModel());
            }

            return RedirectToAction("Index");
        }
       
        [HttpPost]
        public async Task<IActionResult> Checkout(OrderInputModel updateduser)
        {
            //Ef upplýsingar eru fjarverandi eða uppfylla ekki kröfu er 
            //notanda beint aftur á síðu og hann beðinn um að gefa upp réttar upplýisngar
            if(!ModelState.IsValid)
            {
                return View();
            }
            //Sækir notenda og uppfærir sendingarupplýisngar og vistar í gagnabanka
            var user = await _userManager.GetUserAsync(User);
            
            user.Address = updateduser.Address;
            
            user.City = updateduser.City;
            
            user.Country = updateduser.Country;
            
            user.ZipCode = updateduser.ZipCode;

            await _userManager.UpdateAsync(user);
                
            return RedirectToAction("ReviewStep");
        }
        [HttpGet]
        public async Task <IActionResult> ReviewStep()                                                                        
        {   
            //Sækir innskráðann notenda
            var user = await _userManager.GetUserAsync(User); 
            //Sækir körfu innskráða notenda
            var cartId = user.Email;
            //Sækir heildarverð körfu
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
            //Sækir notenda upplýsingar innskráðs notenda
            var user = await _userManager.GetUserAsync(User); 
            
            var cartId = user.Email;

            var cartItems = _cartService.GetCartItems(cartId);
            //Breytir körfu í pönntun
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
            //Lækkar lagertölu bóka
            foreach (var q in cartItems)
            {
                var book = (from b in _db.Books
                            where b.Id == q.BookId
                            select b).SingleOrDefault();
                
                book.Quantity -= q.Quantity;
            }
            //Tæmir körfu
            foreach (var t in cartItems)
            {   
                RemoveFromCart(t.BookId);
            }
            //Vistar allar breytingar í gagnagrunn
            _db.SaveChanges();

            return View();
        }
    }
}
