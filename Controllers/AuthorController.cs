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
    public class AuthorController : Controller
    {
        private AuthorService _authorService;

        public AuthorController()
        {
            _authorService = new AuthorService();
        }

        public IActionResult Details(int? id)
        {
             if(id == null)
             {
                return View("NotFound");
             }
             
            var booksByAuthor = _authorService.GetAllBooksByAuthor(id);
            if(booksByAuthor == null)
            {
                return View("NotFound");
            }
            ViewBag.Author = _authorService.GetAuthorById(id);
            return View (booksByAuthor);
        }
    }
}
