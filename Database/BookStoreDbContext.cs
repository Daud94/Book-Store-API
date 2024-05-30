using Microsoft.EntityFrameworkCore;

namespace BookStore.Database;

public class BookStoreDbContext : DbContext
{
    public BookStoreDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
    {
        
    }

    public DbSet<Book.Book> Books { get; set; }
    public DbSet<Author.Author> Authors { get; set; }
}