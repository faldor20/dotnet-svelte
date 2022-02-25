using System;
using System.Net;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Library.Models;
using Microsoft.EntityFrameworkCore;
using Library.Configuration;
namespace Library.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibraryController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly LibraryContext _context;
        private readonly Paths _paths;
        private readonly Configuration.Library _libraryConfig;

        public LibraryController(IConfiguration configuration,LibraryContext context)
        {
            _context = context;
            _configuration = configuration;
            var paths = new Paths();
            var libraryConfig = new Configuration.Library();
            _configuration.Bind(libraryConfig);
            _configuration.Bind(paths);
            _libraryConfig = libraryConfig;
            _paths = paths;

        }

        [HttpGet("listings/{title}")]
        public BookListing[] GetBooksByTitle(string title)
        {
            return _context.BookListings.Where(book => book.Title.ToLower().Contains(title.ToLower())).Include("Books.LoanInfo").ToArray();
            
        }
        [HttpGet("loanInfo/{bookListingId:int}")]
        public List<Book> GetLoanInfo(int bookListingId)
        {
            return _context.BookListings.Include("Books.LoanInfo").Where(x => x.Id==bookListingId).First().Books;
        }

        [HttpGet("cover/{listingId:int}")]
        public async Task<IActionResult> GetCover(int listingId) {
            var imagePath = Path.Join(_paths.Content.FullName, _paths.Images, $"{listingId}.jpg");
            Byte[] b = await System.IO.File.ReadAllBytesAsync(imagePath);            
            return File(b, "image/jpeg");
        }
        [HttpGet("UserData/{UserId:int}")]
        public User UserData(int userId)
        {
            return _context.Users.Include("LoanedBooks.BookListing").Include("LoanedBooks.LoanInfo").Where(x=>x.Id==userId).First();
        }
        [HttpPost("lend/{userId:int}/{bookId:int}")]   // GET /api/test2/xyz
        public async  Task<IActionResult> LendBook(int userId, int bookId)
        {
            var book = await _context.Books.Include(x => x.LoanInfo).Where(x => x.Id == bookId).FirstAsync();
            if (book is null) return NotFound($"Book with id {bookId} doesn't exist");
            if (book?.LoanInfo is not null)return Conflict("This book is already on loan. please return it first");

            var user = await _context.Users.FindAsync(userId);
            if (user is null) return NotFound($"Could not find userID{userId}");
            if (user.LoanedBooks.Find(x =>x.BookListingId==book.BookListingId) is not null) return Conflict("you have already reserved that book");
            var nowDate = DateOnly.FromDateTime(DateTime.Now);
            book.LoanInfo = new LoanInfo { LoanedDate = nowDate, LoanedUser = user, DueDate = nowDate.AddDays(_libraryConfig.LoanDays) };
            _context.Books.Update(book);
            user.LoanedBooks.Add(book);
            _context.Users.Update(user);
            var a=await _context.SaveChangesAsync();
        
            Console.WriteLine($"loaning book {bookId} to user {userId} wrote ${a} changes");
            return Ok();
        }

        [HttpPost("return/{bookId:int}")]   // GET /api/test2/xyz
        public async Task<IActionResult> ReturnBook( int bookId)
        {
            var book = await _context.Books.Include(x=>x.LoanInfo).Where(x=>x.Id==bookId).FirstAsync();
            if (book is null) return NotFound($"Book with id {bookId} doesn't exist");
            if (book.LoanInfo is null) return Conflict("This book is not on loan. Please loan it first");


            var user = book.LoanInfo?.LoanedUser;
            if (user is null) return NotFound($"Could not find loadned user");
            
            book.LoanInfo = null;
            user?.LoanedBooks.Remove(book);

            await _context.SaveChangesAsync();
            return Ok();


        }

        [HttpGet("userIds")]   // GET /api/test2/xyz
        public int[] GetUserIds()
        {   var dbUsers = _context.Users;
            var users= dbUsers.Select(x => x.Id).ToArray();
            Console.WriteLine($"got {users.Length} from {dbUsers.Count()} users");
            return users;


        }


    }
}