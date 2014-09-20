using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using MVCMusicStore.Models;

namespace MVCMusicStore.Classes
{
    public class ShoppingCartDBInitializer : DropCreateDatabaseIfModelChanges<ShoppingCartDB>
    {
        protected override void Seed(ShoppingCartDB context)
        {
            context.Customers.Add(
               new Customer()
                {
                    FirstName = "Adam",
                    LastName = "Atri",
                    Username = "TheWezl",
                    Email = "k.adam.atri@gmail.com",
                    Phone = "(919) 623-8442",
                    Address = new Address() { 
                        Street = "1210 Gatehouse Dr.",
                        City = "Cary",
                        State = "NC", 
                        ZipCode = "27511",
                        Country = "USA"
                    }
                });

            context.Customers.Add(
                new Customer()
                {
                    FirstName = "James",
                    LastName = "Brown",
                    Username = "TheGodfatherOfSoul",
                    Email = "godfather@soul.org",
                    Phone = "(555) 555-8442",
                    Address = new Address() { 
                        Street = "110 Grammy Winner Dr.",
                        City = "Atlanta",
                        State = "GA", 
                        ZipCode = "33333",
                        Country = "USA"
                    }
                });

            context.Customers.Add(
                new Customer()
                {
                    FirstName = "Henry",
                    LastName = "Winkler",
                    Username = "TheFonz",
                    Email = "theFonz@cool.com",
                    Phone = "(555) 455-8111",
                    Address = new Address() { 
                        Street = "210 Cuttingham Ct.",
                        City = "Minneappolis",
                        State = "MN", 
                        ZipCode = "67890",
                        Country = "USA"
                    }
                });

            base.Seed(context);
        }
    }
}