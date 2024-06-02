using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BookStore.Book.Enums;

namespace BookStore.Book;

public class Book
{
    public Book()
    {
        CreatedAt = DateTime.Now;
    }

    [Key] public int Id { get; set; }

    [Required] [MaxLength(100)] public string Title { get; set; }

    [Required] [MaxLength(100)] public string Isbn { get; set; }

    [Required] [MaxLength(1000)] public string? Description { get; set; }

    public Genre Genre { get; set; }

    [ForeignKey(nameof(Author))] [Required] public int AuthorId { get; set; }

    public Author.Author Author { get; set; }

    [ForeignKey(nameof(User))] [Required] public int UserId { get; set; }

    public User.User User { get; set; }

    public DateTime CreatedAt { get; set; }
}