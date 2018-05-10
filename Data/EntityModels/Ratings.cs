namespace The_Book_Cave.Data.EntityModels
{
    public class Ratings
    {   
         public int Id { get; set; }

        public int BookId { get; set; }

        public string UserId { get; set; }

        public int Rating { get; set; }

    }
}