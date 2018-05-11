using System.ComponentModel.DataAnnotations;
using The_Book_Cave.Data.EntityModels;

namespace The_Book_Cave.Models.ViewModels
{
    public class OrderViewModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public int Quantity { get; set; }
        public string BookTitle { get; set; }
        public string BookImage { get; set; }
        public string Address {get; set;}
        public string City { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public System.DateTime DateCreated { get; set; }
        public virtual Book Book { get; set; }
    }
}