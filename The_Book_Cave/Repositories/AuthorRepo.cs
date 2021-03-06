using System.Collections.Generic;
using The_Book_Cave.Data;
using The_Book_Cave.Models.ViewModels;
using System.Linq;

namespace The_Book_Cave.Repositories
{
    public class AuthorRepo
    {
        private DataContext _db;

        public AuthorRepo()
        {
            _db = new DataContext();
        }

        public AuthorViewModel GetAuthorById(int? id)
        {
            var author =(from a in _db.Authors
                            join b in _db.Books on a.BookId equals b.Id
                            where a.Id == id
                            select new AuthorViewModel 
                            {
                            Id = a.Id,
                            Name = a.Name,
                            Summary = a.Summary,
                            Image = a.Image,
                            BookId = b.Id
                            }).SingleOrDefault();

            return author;
        }

        public List<BookListViewModel> GetAllBooksByAuthor(int? id)
        {
            var booksByAuthor =(from b in _db.Books
                                join a in _db.Authors on b.AuthorId equals a.Id
                                where b.AuthorId == id
                                where b.InStock == 1
                                select new BookListViewModel{
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
                                CategoryId = b.CategoryId
                                }).ToList();
            return booksByAuthor;
        }

        public List<AuthorViewModel> GetAuthorByName(string search)
        {
            var authorByName =(from a in _db.Authors
                                join b in _db.Books on a.BookId equals b.Id
                                where a.Name.ToLower().Contains(search.ToLower() )
                                select new AuthorViewModel 
                                {
                                Id = a.Id,
                                Name = a.Name,
                                Summary = a.Summary,
                                Image = a.Image,
                                BookId = b.Id
                                }).ToList();
            return authorByName; 
        }
    }
}