using System.Collections.Generic;
using The_Book_Cave.Models.ViewModels;
using The_Book_Cave.Repositories;

namespace The_Book_Cave.Services
{
   public class AuthorService
   {
       private AuthorRepo _authorRepo;

       public AuthorService()
       {
           _authorRepo = new AuthorRepo();
       }

      public List<AuthorViewModel> GetAllAuthors()
       {
           var authors = _authorRepo.GetAllAuthors();
           return authors;
       }

       public List<BookListViewModel> GetAllBooksByAuthor(int? id)
       {
           var booksByAuthor = _authorRepo.GetAllBooksByAuthor(id);
           return booksByAuthor;
       }
   }
}