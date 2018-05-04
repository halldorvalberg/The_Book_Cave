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
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            

            return View();
        }
         public IActionResult Create()
        {
            

            return View();
        }
    }
}