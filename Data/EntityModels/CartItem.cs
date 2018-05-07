using System.ComponentModel.DataAnnotations;

namespace The_Book_Cave.Data.EntityModels
{
  public class CartItem
  {
    public int Id {get; set;}
    public int BookID { get; set; }
    public int Price { get; set; }
    public int Quantity { get; set; }
  }
}