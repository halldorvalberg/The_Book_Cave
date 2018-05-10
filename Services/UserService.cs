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
        public void ProcessUser(UserInputModel user)
        {
            if(string.IsNullOrEmpty(user.Name))
            {
                throw new Exception("First name is missing");
            }
            if(string.IsNullOrEmpty(user.Email))
            {
                throw new Exception("Email is missing");
            }
            if(string.IsNullOrEmpty(user.StreetName))
            {
                throw new Exception("Street is missing");
            }
            if(string.IsNullOrEmpty(user.HouseNumber))
            {
                throw new Exception("House number is missing");
            }
            if(string.IsNullOrEmpty(user.City))
            {
                throw new Exception("City is missing");
            }
            if(string.IsNullOrEmpty(user.Country))
            {
                throw new Exception("Country is missing");
            }
            if(string.IsNullOrEmpty(user.ZipCode))
            {
                throw new Exception("Postal code is missing");
            }
        }
    }
}