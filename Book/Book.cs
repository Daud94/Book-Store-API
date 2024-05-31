using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BookStore.Book.Enums;

namespace BookStore.Book;

public class Book
{
    public Book()
    {
        createdAt = DateTime.Now;
    }
    [Key]
    public int id { get; set; }
    
    [Required]
    public string title { get; set; }
    
    [Required]
    public string isbn { get; set; }
    
    [Required]
    [MaxLength(1000)]
    public string? description { get; set; }

    public Genre genre { get; set; }
    
    [ForeignKey(nameof(Author))]
    public int authorId { get; set; }

    public Author.Author Author { get; set; }
    
    public DateTime createdAt { get; set; }
}