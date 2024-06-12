using BookStore.Book.Dto;
using BookStore.Helper;
using BookStore.Utils;

namespace BookStore.Book.repository;

public interface IBookRepository
{
    Task<Book?> GetBookById(int id);

    Task<List<Book>> GetAllBooks(BookPaginationDto bookPaginationDto);
    
    Task<Book> CreateBook(CreateBookDto createBookDto, int userId);

    Task<Book> UpdateBook(int id, UpdateBookDto updateBookDto);
    
    Task<Book?> DeleteBook(int id);

}