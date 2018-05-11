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
         //   SeeData();
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
                new Book {  Title = "Blóðengill",
                            ISBN = 1111,
                            Publisher = "Bjartur",
                            PublicationYear = new DateTime(2018, 1, 1),
                            Price = 3390,
                            Rating = 0,
                            Summary = "",
                            Review = "",
                            Pages = 0 ,
                            Type = "Innbundin",
                            Language = "íslenska",
                            Image = "",}
                        };
                db.AddRange(initialBooks);
                db.SaveChanges();
           }
           }
        }
    }

