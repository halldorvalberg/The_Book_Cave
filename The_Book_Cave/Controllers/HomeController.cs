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
        private CategoryService _categoryService;
        private AuthorService _authorService;
        public HomeController()
        {   //Tengir Controller við Bóka-, Bókaflokka- og Ritöhfunda þjóninn. (Book-, Category-, og Author Service)
            _categoryService = new CategoryService();
            _bookService = new BookService();
            _authorService = new AuthorService();
        }
        public IActionResult Index()
        {   
            //Sækir 20 bækur úr fyrstu 7 bókaflokkunum til að sýna á forsíðu
            ViewBag.a = _categoryService.GetBooksByCategory(1).Take(20);
            
            ViewBag.b = _categoryService.GetBooksByCategory(2).Take(20);
            
            ViewBag.c = _categoryService.GetBooksByCategory(3).Take(20);
            
            ViewBag.d = _categoryService.GetBooksByCategory(4).Take(20);
            
            ViewBag.e = _categoryService.GetBooksByCategory(5).Take(20);
            
            ViewBag.f = _categoryService.GetBooksByCategory(6).Take(20);
            
            ViewBag.g = _categoryService.GetBooksByCategory(7).Take(20);
            
            return View();
        }
        public IActionResult SearchIndex(string search)
        {   
            //Skilar bara síðu ef leitarstrengur inniheldur eitthvað og -
            //bók í gagnagrunninum hefur titil sem samræmist við leitarstreng
            if (search == null) 
            {
                return View("NotFound");
            }
            //Bækur og höfundar sóttir eftir leitarstreng
            var bookBySearch = _bookService.GetBookBySearch(search);
            
            ViewBag.Author = _authorService.GetAuthorByName(search);
            
            if (bookBySearch == null)
            {
                return View("NotFound");
            }
            
            return View(bookBySearch);
        }

        public IActionResult About()
        {
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
