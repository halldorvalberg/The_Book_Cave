using System.Collections.Generic;
using System.Linq;
using The_Book_Cave.Data;
using The_Book_Cave.Data.EntityModels;
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
    public void AddBookToBookTable ()
    {
      var newbook = new Book{Title = "Verrguds"};
      _db.Add(newbook);
      _db.SaveChanges();
    }
    public List<BookListViewModel> GetAllBooks()
    {
      var books = (from b in _db.Books
                  where b.InStock == 1
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
                      join a in _db.Authors on b.AuthorId equals a.Id
                      join c in _db.Categories on b.CategoryId equals c.Id
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
                        AuthorId = a.Id,
                        Author = a.Name,
                        CategoryId = c.Id,
                        Category = c.Name,
                        Reviews =(from r in _db.Reviews join b in _db.Books
                                  on r.BookId equals b.Id
                                  select new ReviewViewModel
                                  {
                                    Review = r.Review 
                                  }).ToList()
                                  
                      }).SingleOrDefault();

      return bookById;
    }

    public List<BookListViewModel> GetBooksByOrder()
    {
          var bookByOrder = (from b in _db.Books
                             where b.InStock == 1
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

    public List<BookListViewModel> GetBookBySearch(string search)
    {
      
      var bookBySearch =(from b in _db.Books 
                         join a in _db.Authors on b.AuthorId equals a.Id 
                         where b.Title.ToLower().Contains(search.ToLower() )|| a.Name.ToLower().Contains(search.ToLower())
                        where b.InStock == 1
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

      public List<BookListViewModel> AddToCart(int? id)
    {
      var shoppingItem = (from b in _db.Books 
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
                      }).ToList();



      return shoppingItem;
    }

    public List<ReviewViewModel>GetBookReviews(int? id)
    {
      var bookReviews =(from r in _db.Reviews
                        where r.BookId == id
                        select new ReviewViewModel
                        { 
                          Review = r.Review
                        }).ToList();
        return bookReviews;
    }
/* 
    public void AddNewReview(int id, string review)
    {   

        var newReview = new Reviews
                      {   
                          BookId = id,
                          Review = review
                      };

            _db.Reviews.Add(newReview);
            _db.SaveChanges();
    }
    */
  }
}

