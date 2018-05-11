using System.ComponentModel.DataAnnotations;

namespace The_Book_Cave.Models.InputModels
{
    public class OrderInputModel
    {


        [Required(ErrorMessage="Field required")]
        public string Name { get; set; }

        [Required(ErrorMessage="Field required")]
        public string Address { get; set; }

        [Required(ErrorMessage="Field required")]
        public string City { get; set; }

        [Required(ErrorMessage="Field required")]
        public string Country { get; set; }

        [Required(ErrorMessage="Field required")]
        public string ZipCode { get; set; }
    }
}