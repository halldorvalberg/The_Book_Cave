using System;

namespace The_Book_Cave.Data.EntityModels
{
  public class Book
  {
    public int Id {get; set;}
    public string Title { get; set; }
    public int ISBN { get; set; }
    public string Publisher { get; set; }
    public DateTime PublicationYear { get; set; }

    public int Price { get; set; }
  
    public double Rating { get; set; }
    public string Summary { get; set; }
    public string Review { get; set; }
    public int Pages { get; set; }
    public string Type { get; set; }
    
    public string Language { get; set; }
    public int Quantity { get; set; }
    public string Image { get; set;}

    public int AuthorId {get; set;}

    public int CategoryId {get; set;}
   }


}