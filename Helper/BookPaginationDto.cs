using BookStore.Book.Enums;

namespace BookStore.Helper;

public class BookPaginationDto
{
    public string? title { get; set; }

    public string? description { get; set; }

    public DateTime? startDate { get; set; }

    public DateTime? endDate { get; set; }

    public string? isbn { get; set; }

    public int? authorId { get; set; }

    public Genre? genre { get; set; }

    private int page { get; set; } = 1;

    public int limit { get; set; } = 20;

    public bool inAscending { get; set; } = true;

    public int Skip()
    {
        return (page - 1) * limit;
    }
}