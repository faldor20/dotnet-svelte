using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Library.Models
{
    public class LibraryContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Book> Books { get; set; } = null!;
        public DbSet<BookListing> BookListings { get; set; } = null!;


        public string DbPath { get; }

        public LibraryContext(DbContextOptions conf)
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "blogging.db");
        }

        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");
    }

    public class BookListing
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public List<Book> Books { get; set; } = new();
        //public List<Book> reservedBooks { get; set; } = new();
        /// <summary>
        /// List of userIds of users who have reserved the book
        /// </summary>
        public List<User> reservations { get; set; } = new();
    }

    public class Book
    {
        public int Id { get; set; }
        public BookListing Listing { get; set; }
        public LoanInfo? LoanInfo { get; set; }

    }
    public class LoanInfo{
        public LoanInfo(DateOnly loanedDate, User LoanedUser)
        {
            LoanedDate = loanedDate;
            this.LoanedUser = LoanedUser;
        }

        public DateOnly LoanedDate { get; set; }
        public User LoanedUser { get; set; }

    }
    public class User
    {
        public int Id { get; set; }
        public List<Book> BorrowedBooks { get; set; } =new();
        /// <summary>
        /// List of bookListingIDs. NOT bookIDs
        /// </summary>
        public List<int> ReservedBooks { get; set; } = new();
        public DateOnly? LoanedDate { get; set;}

    }
}
