

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

        public static ShoppingCart GetCart(HttpContext context)
        {
            var cart = new ShoppingCart();
            cart.ShoppingCartId = context.User.Identity.Name;
            
            return cart;
        }
        
        public void AddToCart(BookListViewModel book, HttpContext context)
        {
            _cartRepo.AddToCart(book, context);
        }

        // public int RemoveFromCart(BookListViewModel book, HttpContext context)
        // {
        //     return _cartRepo.RemoveFromCart(book, context);
        // }
      
       
       public int RemoveFromCart(string shoppingCartId)
        {
           
            var cartItem = _cartRepo.GetQuantity(shoppingCartId);
            if (cartItem != 0)
            {
                if(cartItem > 1)
                {
                    cartItem--;

                }
                if(cartItem == 1)
                {
                    cartItem--;
                    cartItem = 0;
                }
                
              
            }
            
            return cartItem;
        
        }

        private void NewMethod1()
        {
            // Save changes
            NewMethod1();
        }

        private object GetCart()
        {
            throw new NotImplementedException();
        }

        private void NewMethod()
        {
             NewMethod1();
        }

        public List<Cart> GetCartItems(string shoppingCartId)
        {
            return _cartRepo.GetCartItems(shoppingCartId);
        }

        public double GetTotal(string shoppingCartId)
        {
            return _cartRepo.GetTotal(shoppingCartId);
        }
    }
}