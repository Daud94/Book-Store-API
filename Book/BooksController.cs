using AutoMapper;
using BookStore.Book.Dto;
using BookStore.Book.repository;
using BookStore.Helper;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Book;

[Route("api/[controller]")]
[ApiController]
public class BooksController : Controller
{
    private readonly IBookRepository _bookRepository;
    private readonly IMapper _mapper;

    public BooksController(IBookRepository bookRepository, IMapper mapper)
    {
        _bookRepository = bookRepository;
        _mapper = mapper;
    }

    [Route("{id:int}")]
    [HttpGet]
    public async Task<IActionResult> GetByBookById([FromRoute] int id)
    {
        var book = await _bookRepository.GetBookById(id);
        if (book == null)
        {
            return NotFound("Book not found");
        }
        var bookDto = _mapper.Map<CreateBookDto>(book);

        return Ok(new
        {
            success = true,
            message = "Book fetched",
            data = bookDto
        });
    }

    [HttpGet]
    public async Task<IActionResult> GetAllBooks([FromQuery] BookPaginationDto bookPaginationDto)
    {
        
    }
}