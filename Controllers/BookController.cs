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

namespace The_Book_Cave.Controllers
{
    public class BookController : Controller
    {
        private BookService _bookService;
        private AuthorService _authorService;
        private DataContext _db;
        public BookController()
        {
            _bookService = new BookService();
            _authorService = new AuthorService();
            _db = new DataContext();
        }
        public IActionResult Details(int? id) 
        {
            //Skilar bara view ef að int er tala og ef það finnst bók í gagnagrunninum með gefna id tölu
            if(id == null){
                return View("NotFound");
            }
            
            var bookById = _bookService.GetBookById(id);
            
            if(bookById == null){
                return View("NotFound");
            }
            //Allar umfjallanir og einkun sótt úr gagnabanka
            ViewBag.BookReviews = _bookService.GetBookReviews(id);

            var bookRatings = _bookService.GetBookRatings(id);

            double totalRating = 0; 
            
            int ratingCount = bookRatings.Count;
            //Einkun bókar reiknuð
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
            //Ef einkun hefur breyst er sú breyting vistuð í gagnabankanum
            var result = _db.Books.SingleOrDefault(b => b.Id == id);
            
            if(result != null)
            {
                result.Rating = totalRating;
                _db.SaveChanges();
            }
            //Sækir allar bækur eftir sama höfund
            ViewBag.BooksByAuthor = _authorService.GetAllBooksByAuthor(bookById.AuthorId);
            
            return View(bookById);
        }
        public IActionResult AddNewReview(int id, string review)
        {   
            //Ný umfjöllun bætt í gagnabanka
            var newReview = new Reviews(){   
                        BookId = id,
                        Review = review,
                        };

            _db.Reviews.Add(newReview);
            
            _db.SaveChanges();

            return  RedirectToAction("Details", new { id = id });
        }
        public IActionResult AddRating(int id, int rating)
        {   
            //Ný einkun bætt við í gagnabanka
            var newRating = new Ratings(){   
                        BookId = id,
                        Rating = rating,
                        };

            _db.Ratings.Add(newRating);
            
            _db.SaveChanges();
        
            return  RedirectToAction("Details", new { id = id });
        }
        public IActionResult BooksByOrder()
        {
            //Skilar öllum bókum úr gagnabanka í stafrófsröð
            var booksByOrder = _bookService.GetBooksByOrder();
            
            return View(booksByOrder);
        }
        public IActionResult Top10Books()
        {   
            //Skilar 10 hæst einkuðu bókunum úr gagnabanka
            var top10Books = _bookService.GetTop10Books();
            
            return View(top10Books);
        }
        //Not Implemented***
        public IActionResult WishList()
        {
            return View();
        }
    }
}