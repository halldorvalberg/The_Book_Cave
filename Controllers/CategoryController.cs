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
            var authors = _categoryService.GetAllCategories();

            return View(authors);
        }
    }
}
