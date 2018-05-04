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
    }
}
