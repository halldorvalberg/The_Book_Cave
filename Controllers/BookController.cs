using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using The_Book_Cave.Models;
using The_Book_Cave.Services;

namespace The_Book_Cave.Controllers
{
    public class BookController : Controller
    {
        private BookService _bookService;
         public BookController()
        {
            _bookService = new BookService();
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
            return View(bookById);
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

<<<<<<< HEAD

        public IActionResult BooksBySearch(string search)  
        {
=======
        /* 
        public IActionResult Details(string search)  
>>>>>>> a0c331b1c390fc9d6c0e00c65dcceaabc14804bc
            if (search != null)
            {
                if (search == null) 
                {
                    return View("NotFound");
                }

                var bookBySearch = _bookService.GetBookBySearch(search);

                if (bookBySearch == null)
                {
                    return View("NotFound");
                }
                 return View(bookBySearch);
            }
            return View("Index", "Home");
        }


        /* 
        [HttpGet]  
        public IActionResult Index(string search)
        {

        if (search != null)
        {
            if (search == null)
            {
                return View("NotFound");
            }
            var filteredBook = (from b in "Gagnagrunnur" where b.Title.ToLower().Contains(search.ToLower())
            select new BookListViewModel
            {
                Id = b.Id,
                Title = b.Title,
                Author = b.Author,
                Category = b.Category,
                ISBN = b.ISBN,
                PublicationYear = b.PublicationYear,
                Publisher = b.Publisher,
                Price = b.Price,
                Rating = b.Rating,
                Review = b.Review
                
            }).ToList();

            if(filteredBook == null) {
                return View("NotFound");
            }

            return View(filteredBook);
        }
            var books = (from b in "Gagnagrunnur"
                            select new BookListViewModel
                            {
                                Id = b.Id,
                                Title = b.Title,
                                Author = b.Author,
                                Category = b.Category,
                                ISBN = b.ISBN,
                                PublicationYear = b.PublicationYear,
                                Publisher = b.Publisher,
                                Price = b.Price,
                                Rating = b.Rating,
                                Review = b.Review
                            }).ToList();

            return View(books);*/
    }
}