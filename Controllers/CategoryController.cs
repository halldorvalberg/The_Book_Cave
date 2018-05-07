using Microsoft.AspNetCore.Mvc;
using The_Book_Cave.Services;

namespace The_Book_Cave.Controllers
{
    public class CategoryController : Controller
    {
        private CategoryService _categoryService;

        public CategoryController()
        {
            _categoryService = new CategoryService();
        }
        public IActionResult Index()
        {
            var categories = _categoryService.GetAllCategories();

            return View(categories);
        }

         public IActionResult Details(int? id) 
        {
            if(id == null){
                return View("NotFound");
            }
            var categoryById = _categoryService.GetBooksByCategory(id);
            
            if(categoryById == null){
                return View("NotFound");
            }
            
            return View(categoryById);
        }
    }
}
