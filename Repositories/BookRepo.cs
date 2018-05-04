using System.Collections.Generic;
using System.Linq;
using The_Book_Cave.Data;
using The_Book_Cave.Models.ViewModels;

namespace The_Book_Cave.Repositories
{
  public class BookRepo
  {
    private DataContext _db;

    public BookRepo() 
    {
      _db = new DataContext();
    }
    
    public List<BookListViewModel> GetAllBooks()
    {
      var books = (from b in _db.Books
                  select new BookListViewModel
                  {
                    Id = b.Id,
                    Title = b.Title,
                    Author = b.Author,
                    Category = b.Category,
                    ISBN = b.ISBN,
                    PublicationYear = b.PublicationYear,
                    Publisher = b.Publisher,
                    Price = b.Price,
                    Rating = b.Rating,
                    Review = b.Review
                  }).ToList();
      
        return books;
    }
  }

}

