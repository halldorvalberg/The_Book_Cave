namespace The_Book_Cave.Models.ViewModels
{
  public class BookListViewModel
  {
    public int Id {get; set;}
    public string Title { get; set; }
    public string Author { get; set; }
    public string Category { get; set; }
    public int ISBN { get; set; }
    public string PublicationYear { get; set; }
    public string Publisher { get; set; }
    public int Price { get; set; }
  
    public int Rating { get; set; }
    public string Review { get; set; }
   }


}