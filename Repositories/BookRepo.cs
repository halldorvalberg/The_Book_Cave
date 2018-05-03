using System.Collections.Generic;
using The_Book_Cave.Models.ViewModels;

namespace The_Book_Cave.Repositories
{
  public class BookRepo
  {
    public List<BookListViewModel> GetAllBooks()
    {
      var books = new List<BookListViewModel>
      {
        new BookListViewModel {Title = "Ég Man Þig", 
                              Author = "Yrsa",
                              Category = "Spennusaga", 
                              ISBN = 1234, 
                              PublicationYear = 2010, 
                              Publisher = "Forlagid",
                              Price = 5999,
                              Rating = 0,
                              Review = ""}
      };
      return books;
    }
  }

}
