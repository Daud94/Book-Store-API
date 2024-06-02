using System.ComponentModel.DataAnnotations;

namespace BookStore.User;

public class User
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string FirstName { get; set; }

    [Required]
    public string LastName { get; set; }

    [Required]
    public string Email { get; set; }

    [Required]
    public string Password { get; set; }
    
    public List<Book.Book> Books { get; set; }

    public List<Author.Author> Authors { get; set; }
}