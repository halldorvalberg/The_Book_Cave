using System.Collections.Generic;
using The_Book_Cave.Models.ViewModels;
using The_Book_Cave.Repositories;

namespace The_Book_Cave.Services
{
    public class CategoryService
    {
        private CategoryRepo _categoryRepo;

        public CategoryService()
        {
            _categoryRepo = new CategoryRepo();
        }

        public List<CategoryViewModel> GetAllCategories()
        {
            var categories = _categoryRepo.GetAllCategories();
            return categories;
        }

        public List<CategoryViewModel> GetAllCategoriesbyOrder()
        {
            var categoriesInOrder = _categoryRepo.GetAllCategoriesbyOrder();
            return categoriesInOrder;
        }

        public List<BookListViewModel> GetBooksByCategory(int? id)
        {
            var categoryById = _categoryRepo.GetBooksByCategory(id);
            return categoryById;
        }

        public List<BookListViewModel> GetBooksComingSoon()
        {
            var booksComingSoon = _categoryRepo.GetBooksComingSoon();
            return booksComingSoon;
        }
        public CategoryViewModel GetCategoryById(int? id)
        {
            var categoryName = _categoryRepo.GetCategoryById(id);
            return categoryName; 
        }
    }
}
