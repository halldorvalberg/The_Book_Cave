using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using The_Book_Cave.Models.InputModels;
using The_Book_Cave.Models.ViewModels;
using The_Book_Cave.Repositories;

namespace The_Book_Cave.Services
{
    public class UserService
    {
        private UserRepo _userRepo;

        public UserService()
        {
            _userRepo = new UserRepo();
        }

        public List<UserListViewModel> GetAllUsers()
        {
            var users = _userRepo.GetAllUsers();

            return users;
        }
        /*
        public void ProcessUser(UserInputModel user)
        {
            if(string.IsNullOrEmpty(user.FirstName)) { throw new Exception("First name is missing"); }
            if(string.IsNullOrEmpty(user.LastName)) { throw new Exception("Last name is missing"); }
            if(string.IsNullOrEmpty(user.Email)) { throw new Exception("Email is missing"); }
            if(string.IsNullOrEmpty(user.BillingAddressStreet)) { throw new Exception("Street is missing"); }
            if(string.IsNullOrEmpty(user.BillingAddressHouseNumber)) { throw new Exception("House number is missing"); }
            if(string.IsNullOrEmpty(user.BillingAddressCity)) { throw new Exception("City is missing"); }
            if(string.IsNullOrEmpty(user.BillingAddressCountry)) { throw new Exception("Country is missing"); }
            if(string.IsNullOrEmpty(user.BillingAddressZipCode)) { throw new Exception("Postal code is missing"); }
            if(string.IsNullOrEmpty(user.DeliveryAddressStreet)) { throw new Exception("Street is missing"); }
            if(string.IsNullOrEmpty(user.DeliveryAddressHouseNumber)) { throw new Exception("House number is missing"); }
            if(string.IsNullOrEmpty(user.DeliveryAddressCity)) { throw new Exception("City is missing"); }
            if(string.IsNullOrEmpty(user.DeliveryAddressCountry)) { throw new Exception("Country is missing"); }
            if(string.IsNullOrEmpty(user.DeliveryAddressZipCode)) { throw new Exception("Postal code is missing"); }
        }
        
        public List<PurchasesViewModel> GetAllPurchases(HttpContext context)
        {
            
            return _userRepo.GetAllPurchases(context);
        }
         */
        public static string GetUser(HttpContext context)
        {
            var user = context.User.Identity.Name;
            return user;
        }
    }
}