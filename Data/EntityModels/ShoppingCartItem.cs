using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace The_Book_Cave.Data.EntityModels
{
    public class ShoppingCartItem
    {
        [Key]
        public int ShoppingCartItemId { get; set; }
        public Book Book { get; set; }
        public int Amount { get; set; }
        public string ShoppingCartID { get; set; }
    }
}