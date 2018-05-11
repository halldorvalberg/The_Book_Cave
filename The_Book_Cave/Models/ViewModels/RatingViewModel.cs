namespace The_Book_Cave.Models.ViewModels
{
    public class RatingViewModel
    {   
         public int Id { get; set; }

        public int BookId { get; set; }

        public string UserId { get; set; }

        public int Rating { get; set; }

    }
}