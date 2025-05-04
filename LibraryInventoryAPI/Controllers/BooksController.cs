using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LibraryInventoryAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace LibraryInventoryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private static List<Book> books = new List<Book>
        {
            new Book { Id = 1, Title = "The Alchemist", Author = "Paulo Coelho", YearPublished = 1988, Genre = "Fiction", IsAvailable = true },
            new Book { Id = 2, Title = "Sapiens", Author = "Yuval Noah Harari", YearPublished = 2011, Genre = "History", IsAvailable = false }
        };

        // GET: api/books
        [HttpGet]
        public ActionResult<IEnumerable<Book>> GetAllBooks()
        {
            return Ok(books);
        }

        // GET: api/books/1
        [HttpGet("{id}")]
        public ActionResult<Book> GetBookById(int id)
        {
            var book = books.FirstOrDefault(b => b.Id == id);
            /*books: This is our in-memory list of Book objects.
             * .FirstOrDefault(...): This is a LINQ method that:
             * Returns the first item that matches a condition.
             * If no match is found, it returns null (the "default" value).
             * b => b.Id == id: This is a lambda expression. For each b (each Book in the list), it checks if b.Id equals the id passed into the method.*/
            if (book == null) return NotFound("Book not found.");
            return Ok(book);
        }

        // POST: api/books
        [HttpPost]
        public ActionResult AddBook(Book newBook)
        {
            newBook.Id = books.Max(b => b.Id) + 1;
            books.Add(newBook);
            return Ok(newBook);
        }

        // PUT: api/books/1
        [HttpPut("{id}")]
        public ActionResult UpdateBook(int id, Book updatedBook)
        {
            var book = books.FirstOrDefault(b => b.Id == id);
            if (book == null) return NotFound("Book not found.");

            book.Title = updatedBook.Title;
            book.Author = updatedBook.Author;
            book.YearPublished = updatedBook.YearPublished;
            book.Genre = updatedBook.Genre;
            book.IsAvailable = updatedBook.IsAvailable;

            return Ok(book);
        }

        // DELETE: api/books/1
        [HttpDelete("{id}")]
        public ActionResult DeleteBook(int id)
        {
            var book = books.FirstOrDefault(b => b.Id == id);
            if (book == null) return NotFound("Book not found.");

            books.Remove(book);
            return Ok($"Book with ID {id} deleted.");
        }
    }
}
