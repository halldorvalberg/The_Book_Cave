using System.ComponentModel.DataAnnotations;

namespace The_Book_Cave.Models.InputModels
{
    public class UserInputModel
    {

        [Required(ErrorMessage="Field required")]
        public string FirstName { get; set; }
        /*
        [Required(ErrorMessage="Field required")]
        public string LastName { get; set; }
        [Required(ErrorMessage="Field required")]
        public string Email { get; set; }

        [Required(ErrorMessage="Field required")]
        public string BillingAddressStreet { get; set; }

        [Required(ErrorMessage="Field required")]
        public string BillingAddressHouseNumber { get; set; }
        public string BillingAddressLine2 { get; set; }

        [Required(ErrorMessage="Field required")]
        public string BillingAddressCity { get; set; }

        [Required(ErrorMessage="Field required")]
        public string BillingAddressCountry { get; set; }

        [Required(ErrorMessage="Field required")]
        public string BillingAddressZipCode { get; set; }

        [Required(ErrorMessage="Field required")]
        public string DeliveryAddressStreet { get; set; }

        [Required(ErrorMessage="Field required")]
        public string DeliveryAddressHouseNumber { get; set; }
        public string DeliveryAddressLine2 { get; set; }

        [Required(ErrorMessage="Field required")]
        public string DeliveryAddressCity { get; set; }

        [Required(ErrorMessage="Field required")]
        public string DeliveryAddressCountry { get; set; }

        [Required(ErrorMessage="Field required")]
        public string DeliveryAddressZipCode { get; set; }
         */
    }
}