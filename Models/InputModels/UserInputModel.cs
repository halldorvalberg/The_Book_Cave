using System.ComponentModel.DataAnnotations;

namespace The_Book_Cave.Models.InputModels
{
    public class UserInputModel
    {


        [Required(ErrorMessage="Field required")]
        public string Name { get; set; }

        [Required(ErrorMessage="Field required")]
        public string Email { get; set; }

        [Required(ErrorMessage="Field required")]
        public string StreetName { get; set; }

        [Required(ErrorMessage="Field required")]
        public string HouseNumber { get; set; }

        [Required(ErrorMessage="Field required")]
        public string City { get; set; }

        [Required(ErrorMessage="Field required")]
        public string Country { get; set; }

        [Required(ErrorMessage="Field required")]
        public string ZipCode { get; set; }
    }
}