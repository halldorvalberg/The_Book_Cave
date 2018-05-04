namespace The_Book_Cave.Data.EntityModels
{
  public class Author
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Summary { get; set; }
    public string Image { get; set; }

    public int BookId {get; set;}
    
  }

}