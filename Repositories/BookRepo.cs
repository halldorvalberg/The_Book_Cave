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
                    ISBN = b.ISBN,
                    Publisher = b.Publisher,
                    PublicationYear = b.PublicationYear,
                    Price = b.Price,
                    Rating = b.Rating,
                    Summary = b.Summary,
                    Review = b.Review,
                    Pages = b.Pages,
                    Type = b.Type,
                    Language = b.Language,
                    Image = b.Image,
                    AuthorId = b.AuthorId,
                    CategoryId = b.CategoryId
                  }).ToList();
      
        return books;
    }
    public BookListViewModel GetBookById(int? id)
    {
      var bookById = (from b in _db.Books 
                      where b.Id == id
                      select new BookListViewModel
                      {
                        Id = b.Id,
                        Title = b.Title,
                        ISBN = b.ISBN,
                        Publisher = b.Publisher,
                        PublicationYear = b.PublicationYear,
                        Price = b.Price,
                        Rating = b.Rating,
                        Summary = b.Summary,
                        Review = b.Review,
                        Pages = b.Pages,
                        Type = b.Type,
                        Language = b.Language,
                        Image = b.Image,
                        AuthorId = b.AuthorId,
                        CategoryId = b.CategoryId
                      }).SingleOrDefault();

      return bookById;
    }

    public List<BookListViewModel> GetBooksByOrder()
    {
          var bookByOrder = (from b in _db.Books
                             orderby b.Title ascending
                             select new BookListViewModel
                             {
                              Id = b.Id,
                              Title = b.Title,
                              ISBN = b.ISBN,
                              Publisher = b.Publisher,
                              PublicationYear = b.PublicationYear,
                              Price = b.Price,
                              Rating = b.Rating,
                              Summary = b.Summary,
                              Review = b.Review,
                              Pages = b.Pages,
                              Type = b.Type,
                              Language = b.Language,
                              Image = b.Image,
                              AuthorId = b.AuthorId,
                              CategoryId = b.CategoryId
                            }).ToList();

          return bookByOrder;
    }

    public BookListViewModel GetBookBySearch(string search)
    {
      var bookBySearch =(from b in _db.Books where b.Title.ToLower().Contains(search.ToLower())
                        select new BookListViewModel
                        {
                          Id = b.Id,
                          Title = b.Title,
                          ISBN = b.ISBN,
                          Publisher = b.Publisher,
                          PublicationYear = b.PublicationYear,
                          Price = b.Price,
                          Rating = b.Rating,
                          Summary = b.Summary,
                          Review = b.Review,
                          Pages = b.Pages,
                          Type = b.Type,
                          Language = b.Language,
                          Image = b.Image,
                          AuthorId = b.AuthorId,
                          CategoryId = b.CategoryId 
                        }).SingleOrDefault();
        
       return bookBySearch;
    }

    public List<BookListViewModel> GetTop10Books()
    {
      var books =(from b in _db.Books
                  select new BookListViewModel {
                  Id = b.Id,
                  Title = b.Title,
                  ISBN = b.ISBN,
                  Publisher = b.Publisher,
                  PublicationYear = b.PublicationYear,
                  Price = b.Price,
                  Rating = b.Rating,
                  Summary = b.Summary,
                  Review = b.Review,
                  Pages = b.Pages,
                  Type = b.Type,
                  Language = b.Language,
                  Image = b.Image,
                  AuthorId = b.AuthorId,
                  CategoryId = b.CategoryId 
                  }).ToList();

      var top10Books = (from b in books
                        orderby b.Rating descending
                        select b).Take(10).ToList();

      return top10Books; 
    }
  }
}

