using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using The_Book_Cave.Data;
using The_Book_Cave.Data.EntityModels;
using The_Book_Cave.Models.ViewModels;
using System.Linq;
using System.Threading.Tasks;
namespace The_Book_Cave.Repositories
{
    public class CartRepo
    {
        private DataContext _db = new DataContext();

        private BookRepo _bookRepo = new BookRepo();

        public ShoppingCart GetCart(HttpContext context)
        {
            var cart = new ShoppingCart();
            cart.ShoppingCartId = context.User.Identity.Name;
            return cart;
        }

        public void AddToCart(BookListViewModel book, HttpContext context)
        {
            var cart = GetCart(context);

            var cartItem = (from item in _db.Carts
                        where item.Book.Id == book.Id && item.CartId == cart.ShoppingCartId
                        select item).SingleOrDefault();
            
            
            if (cartItem == null)
            {
                cartItem = new The_Book_Cave.Data.EntityModels.Cart
                {
                    BookId = book.Id,
                    CartId = cart.ShoppingCartId,
                    Quantity = 1,
                    DateCreated = DateTime.Now
                };
                _db.Carts.Add(cartItem);
            }
            else
            {
                cartItem.Quantity++;
            }
            _db.SaveChanges();
        }
        
        public int GetQuantity(string shoppingCartId)
        {
            
           var total = (from items in _db.Carts
                        where items.CartId == shoppingCartId
                        select items.Quantity).Single();
            
            return total;
        }
        public int RemoveFromCart(BookListViewModel book, HttpContext context)
        {
            var cart = GetCart(context);

            var cartItem = (from item in _db.Carts
                    where item.Book.Id == book.Id && item.CartId == cart.ShoppingCartId
                    select item).SingleOrDefault();
        
            var localQuantity = 0;
        
            if (cartItem != null)
            {

                _db.Carts.Remove(cartItem);
    
            }
            _db.SaveChanges();

            return localQuantity;
        }

        public List<The_Book_Cave.Data.EntityModels.Cart> GetCartItems(string shoppingCartId)
        {
            var cartItems = (from item in _db.Carts
                            where item.CartId == shoppingCartId
                            select item).ToList();
            return cartItems;
                        
        }

        public double GetTotal(string shoppingCartId)
        {
            var total = (from items in _db.Carts
                        where items.CartId == shoppingCartId
                        select items.Quantity * items.Book.Price).Sum();
            
            return total;
        }
    }
}