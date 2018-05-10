using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using The_Book_Cave.Data;
using The_Book_Cave.Data.EntityModels;
using The_Book_Cave.Models.ViewModels;

namespace The_Book_Cave.Repositories
{
    public class UserRepo
    {
        private DataContext _db;

        public UserRepo()
        {
            _db = new DataContext();
        }

        
        public List<UserListViewModel> GetAllUsers()
        {
            
            var user = (from a in _db.Users
                            select new UserListViewModel
                            {
                                Name = a.Name,
                                Email = a.Email,
                                StreetName = a.StreetName,
                                HouseNumber = a.HouseNumber,
                                City = a.City,
                                Country = a.Country,
                                ZipCode = a.ZipCode,
                                
                            }).ToList();
            return user;
        }

        public static string GetUser(HttpContext context)
        {
            var user = context.User.Identity.Name;
            return user;
        }
        /*
        public List<PurchasesViewModel> GetAllPurchases(HttpContext context)
        {
            var user = GetUser(context);
            var purchased = (from item in _db.Books
                            join citems in _db.Purchased on item.Id equals citems.BookId 
                            where citems.CartId == user
                            select new PurchasesViewModel
                            {
                                Id = item.Id,
                                Image = item.Image,
                                Title = item.Title,
                                Author = item.Author,
                                Rating = item.Rating,
                                Price = item.DiscountPrice,
                                Quantity = citems.Quantity,
                                DateCreated = citems.DateCreated
                            }).ToList();
                            return purchased;
        }
         */
    }
}