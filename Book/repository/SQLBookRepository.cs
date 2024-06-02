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
        return await _bookStoreDbContext.Books.FirstOrDefaultAsync(book => book.Id == id);
    }
    
    public async Task<List<Book>> GetAllBooks(BookPaginationDto bookPaginationDto)
    {
        var books = _bookStoreDbContext.Books.AsQueryable();
        if(!string.IsNullOrWhiteSpace(bookPaginationDto.title))
        {
            books = books.Where(book => book.Title.Contains(bookPaginationDto.title));
            
        }
        
        if(!string.IsNullOrWhiteSpace(bookPaginationDto.isbn))
        {
            books = books.Where(book => book.Isbn.Equals(bookPaginationDto.title, StringComparison.OrdinalIgnoreCase));
            
        }
        
        if(!string.IsNullOrWhiteSpace(bookPaginationDto.description))
        {
            books = books.Where(book => book.Description != null && book.Description.Contains(bookPaginationDto.description));
            
        }
        
        if(bookPaginationDto.genre != null)
        {
            books = books.Where(book =>  book.Genre.Equals(bookPaginationDto.genre));
            
        }
        
        if(bookPaginationDto is { startDate: not null, endDate: not null })
        {
            books = books.Where(book =>
                book.CreatedAt > bookPaginationDto.endDate && bookPaginationDto.startDate < book.CreatedAt);

        }

        if (bookPaginationDto.inAscending)
        {
            books = books.OrderBy(book => book.Title);
        }
        else
        {
            books = books.OrderByDescending(book => book.Title);
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