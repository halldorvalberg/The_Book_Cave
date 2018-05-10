using The_Book_Cave.Data.EntityModels;

namespace The_Book_Cave.Models.ViewModels
{
    public class ShoppingCartViewModel
    {
        public ShoppingCart ShoppingCart { get; set; }
        public decimal ShoppingCartTotal { get; set; }
    }
}