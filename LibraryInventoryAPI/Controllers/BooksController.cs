using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LibraryInventoryAPI.Models;
using System.Collections.Generic;
using System.Linq;
using LibraryInventoryAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace LibraryInventoryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        /*private static List<Book> books = new List<Book>
        {
            new Book { Id = 1, Title = "The Alchemist", Author = "Paulo Coelho", YearPublished = 1988, Genre = "Fiction", IsAvailable = true },
            new Book { Id = 2, Title = "Sapiens", Author = "Yuval Noah Harari", YearPublished = 2011, Genre = "History", IsAvailable = false }
        };*/

        private readonly LibraryContext _context;

        public BooksController(LibraryContext context)
        {
            _context = context;
        }

        // GET: api/books
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetAllBooks()
        {
            return await _context.Books.ToListAsync();
        }

        // GET: api/books/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBookById(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null) return NotFound("Book not found.");
            return book;
        }

        // POST: api/books
        [HttpPost]
        public async Task<ActionResult<Book>> AddBook(Book newBook)
        {
            _context.Books.Add(newBook);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetBookById), new { id = newBook.Id }, newBook);
        }

        // PUT: api/books/1
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(int id, Book updatedBook)
        {
            if (id != updatedBook.Id) return BadRequest("ID mismatch.");

            _context.Entry(updatedBook).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Books.Any(b => b.Id == id))
                    return NotFound("Book not found.");
                else
                    throw;
            }

            return Ok($"Book with ID {id} has been modified.");
        }

        // DELETE: api/books/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null) return NotFound("Book not found.");

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();

            return Ok($"Book with ID {id} deleted.");
        }
    }
}
