using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Author;

public class Author
{   
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int id { get; set; }

    [Required]
    public string firstName { get; set; }
    
    [Required]
    public string? middleName { get; set; }
    
    public string lastName { get; set; }
}