using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using The_Book_Cave.Models;
using The_Book_Cave.Services;
using The_Book_Cave.Data.EntityModels;
using The_Book_Cave.Data;
using Microsoft.AspNetCore.Identity;


namespace The_Book_Cave.Controllers
{
    public class BookController : Controller
    {
        private BookService _bookService;
        private AuthorService _authorService;
        private readonly UserManager<ApplicationUser> _userManager;
        private DataContext _db;
         public BookController(UserManager<ApplicationUser> userManager)
        {
            _bookService = new BookService();
            _authorService = new AuthorService();
            _userManager = userManager;
            _db = new DataContext();
        }

        /* 
        public IActionResult Index()
        {
            return View();
        }
        */

        public IActionResult Details(int? id) 
        {
            if(id == null){
                return View("NotFound");
            }
            var bookById = _bookService.GetBookById(id);
            if(bookById == null){
                return View("NotFound");
            }

            ViewBag.BookReviews = _bookService.GetBookReviews(id);

            var bookRatings = _bookService.GetBookRatings(id);

            double totalRating = 0; 
            int ratingCount = bookRatings.Count;

            if (ratingCount > 0)
            {
                for(int i = 0; i < ratingCount; i++)
                {
                     totalRating = totalRating + bookRatings[i].Rating;
                }
                totalRating = ((double)(totalRating/ratingCount));
                totalRating =System.Math.Round(totalRating,2);
            }

            ViewBag.BookRatings = totalRating; 

            var result = _db.Books.SingleOrDefault(b => b.Id == id);
            if(result != null)
            {
                Console.Write("I got to here");
                result.Rating = totalRating;
                _db.SaveChanges();
            }

            ViewBag.BooksByAuthor = _authorService.GetAllBooksByAuthor(bookById.AuthorId);
            return View(bookById);
        }

         public async Task<IActionResult> AddNewReview(int id, string review)
        {   
            var user = await _userManager.GetUserAsync(User);
    
            var newReview = new Reviews()
                      {   
                          BookId = id,
                          Review = review,
                          UserId = user.Email
                      };

            _db.Reviews.Add(newReview);
            _db.SaveChanges();

           return  RedirectToAction("Details", new { id = id });
        }

        public async Task<IActionResult> AddRating(int id, int rating)
        {   
            var user = await _userManager.GetUserAsync(User);

            var newRating = new Ratings()
                      {   
                          BookId = id,
                          Rating = rating,
                          UserId = user.Email
                      };

            _db.Ratings.Add(newRating);
            _db.SaveChanges();
        
             return  RedirectToAction("Details", new { id = id });

        }
        public IActionResult BooksByOrder()
        {
            var booksByOrder = _bookService.GetBooksByOrder();
            return View(booksByOrder);
        }
        
        public IActionResult Top10Books()
        {
            var top10Books = _bookService.GetTop10Books();
            return View(top10Books);
        }

        public IActionResult WishList()
        {
            return View();
        }
    }
}