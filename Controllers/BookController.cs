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
    }
}