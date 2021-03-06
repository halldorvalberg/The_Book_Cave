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
       public AuthorViewModel GetAuthorById(int? id) 
       {
           var author = _authorRepo.GetAuthorById(id);
           return author;
       }
       public List<BookListViewModel> GetAllBooksByAuthor(int? id)
       {
           var booksByAuthor = _authorRepo.GetAllBooksByAuthor(id);
           return booksByAuthor;
       }
       public List<AuthorViewModel> GetAuthorByName(string search)
       {
           var authorByName = _authorRepo.GetAuthorByName(search);
           return authorByName; 
       }

   }
}