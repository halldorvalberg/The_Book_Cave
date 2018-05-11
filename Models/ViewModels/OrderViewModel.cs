using System.ComponentModel.DataAnnotations;

namespace The_Book_Cave.Models.ViewModels
{
    public class OrderViewModel
    {
        public string Name { get; set; }
        [Key]
        public string Email { get; set; }
        [Required]
        public string Address {get; set;}
        public string City { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
    }
}