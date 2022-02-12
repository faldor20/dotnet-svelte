using System;
using System.Net;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Library.Models;
namespace Library.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibraryController : ControllerBase
    {
        private readonly LibraryContext _context;

        public LibraryController(LibraryContext context)
        {
            _context = context;
        }

        [HttpGet]
        public BookListing[] GetBooksByTitle(string title)
        {
            return _context.BookListings.Where(book => book.Title.Contains(title)).ToArray();
            
        }

        [HttpPost("lend/{userId:int}/{bookId:int}")]   // GET /api/test2/xyz
        public async  Task<IActionResult> LendBook(int userId,int bookId)
        {
            var book = await _context.Books.FindAsync(bookId);
            if (book is null) return NotFound($"Book with id {bookId} doesn't exist");
            if (book?.LoanInfo is not null)return Conflict("This book is already on loan. please return it first");

            var user = await _context.Users.FindAsync(userId);
            if (user is null) return NotFound($"Could not find userID{userId}");

            book.LoanInfo = new LoanInfo( DateOnly.FromDateTime(DateTime.Now),user);
            user.ReservedBooks.Add(bookId);

            await _context.SaveChangesAsync();
            return Ok();

        }
        [HttpPost("return/{bookId:int}")]   // GET /api/test2/xyz
        public async Task<IActionResult> ReturnBook( int bookId)
        {
            var book = await _context.Books.FindAsync(bookId);
            if (book is null) return NotFound($"Book with id {bookId} doesn't exist");
            if (book.LoanInfo is null) return Conflict("This book is not on loan. Please loan it first");


            var user = book.LoanInfo?.LoanedUser;
            if (user is null) return NotFound($"Could not find loadned user");
            
            book.LoanInfo = null;
            user?.BorrowedBooks.Remove(book);

            await _context.SaveChangesAsync();
            return Ok();


        }        

    }
}