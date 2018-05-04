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

       public List<AuthorViewModel> GetAllAuthors()
        {
            var authors =(from a in _db.Authors
                            join b in _db.Books on a.BookId equals b.Id
                            select new AuthorViewModel 
                            {

                            Id = a.Id,
                            Name = a.Name,
                            Summary = a.Summary,
                            Image = a.Image,
                            BookId = b.Id
                            }).ToList();

            return authors;
        }
    }
}