using System.Collections.Generic;
using System.Linq;
using The_Book_Cave.Data;
using The_Book_Cave.Models.ViewModels;

namespace The_Book_Cave.Repositories
{
    public class CategoryRepo
    {
        private DataContext _db;

       public CategoryRepo()
        {
            _db = new DataContext();
        }

        public List<CategoryViewModel> GetAllCategories()
        {
            var categories =(from c in _db.Categories
                         //   join b in _db.Books on c.Id equals b.CategoryId
                            select new CategoryViewModel 
                            {
                              Id = c.Id,
                              Name = c.Name,
                            }).ToList();
            return categories;
        }
    }
}