namespace The_Book_Cave.Models.ViewModels
{
    public class ReviewViewModel
    {
        public int Id { get; set; }

        public int BookId { get; set; }

        public string UserId { get; set; }

        public string Review { get; set; }
    }
}