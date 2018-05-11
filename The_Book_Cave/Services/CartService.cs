

using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using The_Book_Cave.Data.EntityModels;
using The_Book_Cave.Models.ViewModels;
using The_Book_Cave.Repositories;
using System.Linq;

namespace The_Book_Cave.Services
{
    public class CartService
    {
        private CartRepo _cartRepo;
        

        public CartService()
        {
            _cartRepo = new CartRepo();
        }
        
        public void AddToCart(BookListViewModel book, HttpContext context)
        {
            _cartRepo.AddToCart(book, context);
        }

        public int RemoveFromCart(BookListViewModel book, HttpContext context)
        {
             return _cartRepo.RemoveFromCart(book, context);
        }
        public List<Cart> GetCartItems(string shoppingCartId)
        {
            return _cartRepo.GetCartItems(shoppingCartId);
        }

        public double GetTotal(string shoppingCartId)
        {
            return _cartRepo.GetTotal(shoppingCartId);
        }

        public List<OrderViewModel> GetOrder(string email)
        {
            var orders = _cartRepo.GetOrder(email);
            return orders;
        }
    }
}