using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using The_Book_Cave.Data;
using The_Book_Cave.Data.EntityModels;

namespace The_Book_Cave
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = BuildWebHost(args);
            SeeData();
            host.Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();


        public static void SeeData()
        {
           var db = new DataContext();
           
           if(!db.Books.Any())
           {
           var initialBooks = new List<Book>()
           {
                new Book {    Title = "Ég Man Þig", 
                              Author = "Yrsa",
                              Category = "Spennusaga", 
                              ISBN = 1234, 
                              PublicationYear = "2010", 
                              Publisher = "Forlagid",
                              Price = 5999,
                              Rating = 0,
                              Review = ""}
           };
                db.AddRange(initialBooks);
                db.SaveChanges();
           }
           }
        }
    }

