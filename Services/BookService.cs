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

    public BookListViewModel GetBookById(int? id)
    {
      var bookById = _bookRepo.GetBookById(id);
      return bookById;
    }

    public List<BookListViewModel> GetBooksByOrder()
    {
      var booksByOrder = _bookRepo.GetBooksByOrder();
      return booksByOrder;
    }

    public List<BookListViewModel> GetBookBySearch(string search)
    {
      var bookBySearch = _bookRepo.GetBookBySearch(search);
      return bookBySearch;
    }

    public List<BookListViewModel> GetTop10Books()
    {
      var top10Books = _bookRepo.GetTop10Books();
      return top10Books;
    }
    
    public List<BookListViewModel> AddToCart(int? id)
    {
      var shoppingItem = _bookRepo.AddToCart(id);
      
      return shoppingItem; 
    }
  }
}

 