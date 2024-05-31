using BookStore.Database;
using BookStore.Helper;
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
    
    public async Task<List<Book>> GetAllBooks(BookPaginationDto bookPaginationDto)
    {
        var books = _bookStoreDbContext.Books.AsQueryable();
        if(!string.IsNullOrWhiteSpace(bookPaginationDto.title))
        {
            books = books.Where(book => book.title.Contains(bookPaginationDto.title));
            
        }
        
        if(!string.IsNullOrWhiteSpace(bookPaginationDto.isbn))
        {
            books = books.Where(book => book.isbn.Equals(bookPaginationDto.title, StringComparison.OrdinalIgnoreCase));
            
        }
        
        if(!string.IsNullOrWhiteSpace(bookPaginationDto.description))
        {
            books = books.Where(book => book.description != null && book.description.Contains(bookPaginationDto.description));
            
        }
        
        if(bookPaginationDto.genre != null)
        {
            books = books.Where(book =>  book.genre.Equals(bookPaginationDto.genre));
            
        }
        
        if(bookPaginationDto is { startDate: not null, endDate: not null })
        {
            books = books.Where(book =>
                book.createdAt > bookPaginationDto.endDate && bookPaginationDto.startDate < book.createdAt);

        }

        if (bookPaginationDto.inAscending)
        {
            books = books.OrderBy(book => book.title);
        }
        else
        {
            books = books.OrderByDescending(book => book.title);
        }

        return await books.Skip(bookPaginationDto.Skip()).Take(bookPaginationDto.limit).ToListAsync();
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