using System.ComponentModel.DataAnnotations;

namespace The_Book_Cave.Data.EntityModels
{
    public class Reviews
    {
        [Key]
        public int Id { get; set; }

        public int BookId { get; set; }

        public string UserId { get; set; }

        public string Review { get; set; }
    }
}