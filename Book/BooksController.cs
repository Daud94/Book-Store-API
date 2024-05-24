using AutoMapper;
using BookStore.Book.repository;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Book;

[Route("api/[controller]")]
[ApiController]
public class BooksController : Controller
{
    private readonly IBookRepository bookRepository;
    private readonly IMapper mapper;

    public BooksController(IBookRepository bookRepository, IMapper mapper)
    {
        this.bookRepository = bookRepository;
        this.mapper = mapper;
    }

    [Route("{id:int}")]
    [HttpGet]
    public async Task<IActionResult> GetByBookById([FromRoute] int id)
    {
        var book = await bookRepository.GetBookById(id);
        if (book == null) ;
        {
            return NotFound();
        }
        return Ok();
    }
}