using System.ComponentModel.DataAnnotations;

namespace The_Book_Cave.Data.EntityModels
{
    public class Order
    {
        [Key]
        public int RecordId { get; set; }
        public string CartId { get; set; }
        public int BookId { get; set; }
        public int Quantity { get; set; }
        public string Email { get; set; }
        public string Address {get; set;}
        public string City { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public System.DateTime DateCreated { get; set; }
        public virtual Book Book { get; set; }
    }
}