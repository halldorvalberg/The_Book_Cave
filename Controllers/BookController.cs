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
        public IActionResult Index()
        {
            return View();
        }

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

            ViewBag.BooksByAuthor = _authorService.GetAllBooksByAuthor(bookById.AuthorId);
            return View(bookById);
        }

         public IActionResult AddNewReview(int id, string review)
        {   

        var newReview = new Reviews()
                      {   
                          BookId = id,
                          Review = review,
                      };

            _db.Reviews.Add(newReview);
            _db.SaveChanges();

           return  RedirectToAction("Details", new { id = id });
            }

        public IActionResult AddRating(int id, double rating)
        {
             var bookById = _bookService.GetBookById(id);
             var bookRating = bookById.Rating; 
             var TotalRating = (bookRating + rating);

             _db.Books.Add(TotalRating);
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
    }
}