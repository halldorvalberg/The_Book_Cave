using System.Collections.Generic;
using The_Book_Cave.Models.ViewModels;
using The_Book_Cave.Repositories;

namespace The_Book_Cave.Services
{
  public class BookService
  {
    private BookRepo _bookRepo;
    public BookService()
    {
      _bookRepo = new BookRepo();
    }
    public List<BookListViewModel> GetAllBooks()
    {
      var books = _bookRepo.GetAllBooks();
      return books;
    }
  }
}