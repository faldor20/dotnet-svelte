using Library.Models;
using System;
using System.Linq;

namespace Library.Data
{
    public static class DbInitializer
    {
        public static void Initialize(LibraryContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            /*             // Look for any students.
                        if (context.BookListings.Any()&&context)
                        {
                            return;   // DB has been seeded
                        } */

            var listings = new BookListing[]
            {
                new BookListing{Title="Hyperion", Author="dan symmons", Description="An experiential novel telling the story of 5 travelers brought together to tell their own stories",}
            };

            var books = new List<Book>();
            var count = 0;
            foreach (BookListing s in listings)
            {
                var thisBooks = new List<Book>{
                    new Book{Listing=s},
                    new Book{Listing=s}
                };
                count += 2;
                books.AddRange(thisBooks);
                s.Books = thisBooks;
            }
            

            context.Books.AddRange(books);
            context.BookListings.AddRange(listings);
            context.SaveChanges();

            var users = new User[]
            {
                new User{},
                new User{}
            };

            context.Users.AddRange(users);
            context.SaveChanges();
            Console.WriteLine($"Initialized {context.Users.Count()} Users");

        }
    }
}
