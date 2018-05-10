using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace The_Book_Cave.Data.EntityModels
{
    public class OrderDetail
    {
        [Key]
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public int BookId { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }
        public virtual Book Book { get; set; }
        public virtual Order Order { get; set; }
    }
}