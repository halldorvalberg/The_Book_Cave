using System.Collections.Generic;
using The_Book_Cave.Data.EntityModels;

namespace The_Book_Cave.Models.ViewModels
{
    public class Cart
    {
        public int Id { get; set; }
        public int UserId {get; set; }
        public int Quantity { get; set; }
        public int TotalPrice { get; set; }
        public List<CartItem> CartItem { get; set; }
    }
}