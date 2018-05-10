using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace The_Book_Cave.Data.EntityModels
{
    /* 
    public class ShoppingCart
    {
        private readonly DataContext _datacontext;
        private ShoppingCart(DataContext datacontext)
        {
            _datacontext = datacontext;
        }
        [Key]
        public string ShoppingCartId { get; set; }

        public List<ShoppingCartItem> ShoppingCartItems { get; set; }

        public static ShoppingCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?
                .HttpContext.Session;

            var context = services.GetService<DataContext>();
            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            session.SetString("CartId", cartId);

            return new ShoppingCart(context) { ShoppingCartId = cartId };
        }

        public void AddToCart(Book book, int amount)
        {
            var shoppingCartItem = _datacontext.ShoppingCartItems.SingleOrDefault(s => s.Book.Id == book.Id && s.ShoppingCartID == ShoppingCartId);

            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem
                {
                    ShoppingCartID = ShoppingCartId,
                    Book = book,
                    Amount = 1
                };

                _datacontext.ShoppingCartItems.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Amount++;
            }
            _datacontext.SaveChanges();
        }

        public int RemoveFromCart(Book book)
        {
            var shoppingCartItem =
                    _datacontext.ShoppingCartItems.SingleOrDefault(
                        s => s.Book.Id == book.Id && s.ShoppingCartID == ShoppingCartId);

            var localAmount = 0;

            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.Amount > 1)
                {
                    shoppingCartItem.Amount--;
                    localAmount = shoppingCartItem.Amount;
                }
                else
                {
                    _datacontext.ShoppingCartItems.Remove(shoppingCartItem);
                }
            }

            _datacontext.SaveChanges();

            return localAmount;
        }

        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return ShoppingCartItems ??
                   (ShoppingCartItems =
                       _datacontext.ShoppingCartItems.Where(c => c.ShoppingCartID == ShoppingCartId)
                           .Include(s => s.Book)
                           .ToList());
        }

        public void ClearCart()
        {
            var cartItems = _datacontext
                .ShoppingCartItems
                .Where(cart => cart.ShoppingCartID == ShoppingCartId);

            _datacontext.ShoppingCartItems.RemoveRange(cartItems);

            _datacontext.SaveChanges();
        }

        public decimal GetShoppingCartTotal()
        {
            var total = _datacontext.ShoppingCartItems.Where(c => c.ShoppingCartID == ShoppingCartId)
                .Select(c => c.Book.Price * c.Amount).Sum();
            return total;
        }
        */
    }
}