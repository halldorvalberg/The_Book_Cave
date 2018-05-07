using System.Collections.Generic;

namespace The_Book_Cave.Data.EntityModels
{
    public class Cart
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int TotalPrice { get; set; }

        public List<CartItem> CartItem { get; set; }
    }
}