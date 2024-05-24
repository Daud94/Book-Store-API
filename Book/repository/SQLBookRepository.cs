namespace BookStore.Book.repository;

public class SqlBookRepository : IBookRepository
{
    public Task<Book> GetBookById(int id)
    {
        throw new NotImplementedException();
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