using BookStore.Book.Enums;

namespace BookStore.Utils;

public class BookPaginationDto
{
    public string? Title { get; set; }

    public string? Description { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public string? Isbn { get; set; }

    public int? AuthorId { get; set; }

    public Genre? Genre { get; set; }

    private int Page { get; set; } = 1;

    public int Limit { get; set; } = 20;

    public bool InAscending { get; set; } = true;

    public int Skip()
    {
        return (Page - 1) * Limit;
    }
}