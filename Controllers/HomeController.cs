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
    public class HomeController : Controller
    {
        private BookService _bookService;

        public HomeController()
        {
            _bookService = new BookService();
        }
        public IActionResult Index(string search)
        {
            if(search != null)
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

            var books = _bookService.GetAllBooks();

            return View(books);
        }
        public IActionResult About()
        {
            ViewBag.Message = "This is about page.";
            
            return View();
        }
        public IActionResult Conditions()
        {
             return View();
        }
         public IActionResult Contact()
        {
             return View();
        }
   
    }
}
