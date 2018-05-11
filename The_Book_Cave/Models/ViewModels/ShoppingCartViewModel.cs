using System.Collections.Generic;
using The_Book_Cave.Data.EntityModels;

namespace The_Book_Cave.Models.ViewModels
{
    public class ShoppingCartViewModel
    {
        public List<Cart> CartItems { get; set; }
        public double CartTotal { get; set; }
    }
} 