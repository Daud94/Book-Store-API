using BookStore.Database;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Book.repository;

public class SqlBookRepository : IBookRepository
{
    private readonly BookStoreDbContext _bookStoreDbContext;

    public SqlBookRepository(BookStoreDbContext bookStoreDbContext)
    {
        _bookStoreDbContext = bookStoreDbContext;
    }
    public async Task<Book?> GetBookById(int id)
    {
        return await _bookStoreDbContext.Books.FirstOrDefaultAsync(book => book.id == id);
    }

    public Task<List<Book>> GetAllBooks()
    {
        throw new NotImplementedException();
    }

    public Task<Book> CreateBook()
    {
        throw new NotImplementedException();
    }

    public Task<Book> UpdateBook(int id, Book book)
    {
        throw new NotImplementedException();
    }

    public Task<Book?> DeleteBook(int id)
    {
        throw new NotImplementedException();
    }
}