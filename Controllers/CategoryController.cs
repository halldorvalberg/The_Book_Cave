using Microsoft.AspNetCore.Mvc;
using The_Book_Cave.Services;

namespace The_Book_Cave.Controllers
{
    public class CategoryController : Controller
    {
        private CategoryService _categoryService;

        public CategoryController()
        {
            //Tengir Controller við CategoryService
            _categoryService = new CategoryService();
        }
        public IActionResult Index()
        {
            //Sækir alla bókaflokka
            var categories = _categoryService.GetAllCategoriesbyOrder();

            return View(categories);
        }

         public IActionResult Details(int? id) 
        {
            //Sýnir bara síðu ef id tala og bókaflokkur með sömu id tölu finnst í gagnabanka
            if(id == null){
                return View("NotFound");
            }

            var categoryById = _categoryService.GetBooksByCategory(id);
            
            if(categoryById == null){
                return View("NotFound");
            }
            //Sækir upplýsingar um bókaflokk    
            ViewBag.Category = _categoryService.GetCategoryById(id);

            return View(categoryById);
        }

        public IActionResult ComingSoon()
        {
            //Sækir allar bækur í Væntanlegar bækur bókaflokkinum
            var booksComingSoon = _categoryService.GetBooksComingSoon();

            return View (booksComingSoon);
        }
    }
}
