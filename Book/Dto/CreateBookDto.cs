namespace BookStore.Book.Dto;

public class CreateBookDto
{
    public int id { get; set; }
    
    public string title { get; set; }
    
    public string? isbn { get; set; }
    
    public string? description { get; set; }

    public string genre { get; set; }
    
    public int authorId { get; set; }
}