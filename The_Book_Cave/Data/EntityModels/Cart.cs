using System.ComponentModel.DataAnnotations;

namespace The_Book_Cave.Data.EntityModels
{
    public class Cart
    {

        [Key]
        public int RecordId { get; set; }
        public string CartId { get; set; }
        public int BookId { get; set; }
        public int Quantity { get; set; }
        public System.DateTime DateCreated { get; set; }
        public virtual Book Book { get; set; }

    }
}