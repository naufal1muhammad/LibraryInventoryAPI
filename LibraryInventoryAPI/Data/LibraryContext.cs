using Microsoft.EntityFrameworkCore;
using LibraryInventoryAPI.Models;

namespace LibraryInventoryAPI.Data
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; }
        public DbSet<Student> Students { get; set; }
    }
}
