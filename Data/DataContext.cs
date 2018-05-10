using Microsoft.EntityFrameworkCore;
using The_Book_Cave.Data.EntityModels;

namespace The_Book_Cave.Data
{
   public class DataContext : DbContext
   {
<<<<<<< HEAD
       public DbSet<Book> Books {get; set;}
       public DbSet<Author> Authors {get; set;}
        public DbSet<Cart> Carts {get; set;}
        public DbSet<CartItem> CartItems {get; set;}

       public DbSet<Category> Categories {get; set;}

       public DbSet<Reviews> Reviews {get; set;}

=======
        public DbSet<Book> Books {get; set;}
        public DbSet<Author> Authors {get; set;}
        public DbSet<ShoppingCartItem> ShoppingCartItems {get; set;}
        public DbSet<Category> Categories {get; set;}
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
>>>>>>> 638c23270f4e8a1e56402684c2cbbc4ecf62130b
       protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
       {
           optionsBuilder
           .UseSqlServer("Server=tcp:verklegt2.database.windows.net,1433;Initial Catalog=VLN2_2018_H34;Persist Security Info=False;User ID=VLN2_2018_H34_usr;Password=sl!myFawn65;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
       }
   }
}