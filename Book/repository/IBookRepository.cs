namespace BookStore.Book.repository;

public interface IBookRepository
{
    Task<Book?> GetBookById(int id);

    Task<List<Book>> GetAllBooks();
    
    Task<Book> CreateBook();

    Task<Book> UpdateBook(int id, Book book);
    
    Task<Book?> DeleteBook(int id);

}