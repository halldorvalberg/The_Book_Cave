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
        public IActionResult Index(string search)
        {
            return View();
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