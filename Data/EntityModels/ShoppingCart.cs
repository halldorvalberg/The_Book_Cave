using System;
using System.ComponentModel.DataAnnotations;

namespace The_Book_Cave.Data.EntityModels
{
    public class ShoppingCart
    {
        [Key]
        public string ShoppingCartId { get; set; }

       
    }
}