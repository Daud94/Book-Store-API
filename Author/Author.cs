using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Author;

public class Author
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required] public string FullName { get; set; }

    [ForeignKey(nameof(User))] [Required] public int UserId { get; set; }

    public User.User User { get; set; }

    public List<Book.Book> Books { get; set; }
}