using System.ComponentModel.DataAnnotations;
using BookStore.Book.Enums;

namespace BookStore.Book.Dto;

public class UpdateBookDto
{
    public string? Title { get; set; }

    public string? Isbn { get; set; }

    public string? Description { get; set; }

    [Required] public Genre Genre { get; set; }

    [Required] public int AuthorId { get; set; }
}