using System.ComponentModel.DataAnnotations;

namespace The_Book_Cave.Models.ViewModels
{
    public class UserListViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Key]
        public string Email { get; set; }
        public string ProfilePicture {get; set;}
        public string FavoriteBook { get; set; }
        public string BillingAddressStreet { get; set; }
        public string BillingAddressHouseNumber { get; set; }
        public string BillingAddressLine2 { get; set; }
        public string BillingAddressCity { get; set; }
        public string BillingAddressCountry { get; set; }
        public string BillingAddressZipCode { get; set; }
        public string DeliveryAddressStreet { get; set; }
        public string DeliveryAddressHouseNumber { get; set; }
        public string DeliveryAddressLine2 { get; set; }
        public string DeliveryAddressCity { get; set; }
        public string DeliveryAddressCountry { get; set; }
        public string DeliveryAddressZipCode { get; set; }
    }
}