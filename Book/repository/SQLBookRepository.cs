using AutoMapper;
using BookStore.Book.Dto;
using BookStore.Database;
using BookStore.Helper;
using BookStore.Utils;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Book.repository;

public class SqlBookRepository : IBookRepository
{
    private readonly BookStoreDbContext _bookStoreDbContext;
    private readonly IMapper _mapper;

    public SqlBookRepository(BookStoreDbContext bookStoreDbContext, IMapper mapper)
    {
        _bookStoreDbContext = bookStoreDbContext;
        _mapper = mapper;
    }

    public async Task<Book?> GetBookById(int id)
    {
        return await _bookStoreDbContext.Books.FirstOrDefaultAsync(book => book.Id == id);
    }

    public async Task<List<Book>> GetAllBooks(BookPaginationDto bookPaginationDto)
    {
        var books = _bookStoreDbContext.Books.AsQueryable();
        if (!string.IsNullOrWhiteSpace(bookPaginationDto.Title))
        {
            books = books.Where(book => book.Title.Contains(bookPaginationDto.Title));
        }

        if (!string.IsNullOrWhiteSpace(bookPaginationDto.Isbn))
        {
            books = books.Where(book => book.Isbn.Equals(bookPaginationDto.Title, StringComparison.OrdinalIgnoreCase));
        }

        if (!string.IsNullOrWhiteSpace(bookPaginationDto.Description))
        {
            books = books.Where(book =>
                book.Description != null && book.Description.Contains(bookPaginationDto.Description));
        }

        if (bookPaginationDto.Genre != null)
        {
            books = books.Where(book => book.Genre.Equals(bookPaginationDto.Genre));
        }

        if (bookPaginationDto is { StartDate: not null, EndDate: not null })
        {
            books = books.Where(book =>
                book.CreatedAt > bookPaginationDto.EndDate && bookPaginationDto.StartDate < book.CreatedAt);
        }

        if (bookPaginationDto.InAscending)
        {
            books = books.OrderBy(book => book.Title);
        }
        else
        {
            books = books.OrderByDescending(book => book.Title);
        }

        return await books.Skip(bookPaginationDto.Skip()).Take(bookPaginationDto.Limit).ToListAsync();
    }

    public async Task<Book> CreateBook(CreateBookDto createBookDto, int userId)
    {
        
        var book = _mapper.Map<Book>(createBookDto);
        var user = await _bookStoreDbContext.Books.AddAsync(book);
        await _bookStoreDbContext.SaveChangesAsync();
        return book;
    }

    public async Task<Book> UpdateBook(int id, UpdateBookDto updateBookDto)
    {
        var existingBook = await GetBookById(id);

        var book = _mapper.Map<Book>(updateBookDto);


        existingBook.Title = book.Title;
        existingBook.Isbn = book.Isbn;
        existingBook.Description = book.Description;
        existingBook.Genre = book.Genre;
        existingBook.AuthorId = book.AuthorId;

        await _bookStoreDbContext.SaveChangesAsync();
        return existingBook;

    }

    public Task<Book?> DeleteBook(int id)
    {
        throw new NotImplementedException();
    }
}