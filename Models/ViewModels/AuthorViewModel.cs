using System.Collections.Generic;

namespace The_Book_Cave.Models.ViewModels
{
  public class AuthorViewModel
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Summary { get; set; }
    public string Image { get; set; }

    public int BookId {get; set;}
    
    public  List<BookListViewModel> Books { get; set; }
  }
}