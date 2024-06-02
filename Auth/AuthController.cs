using BookStore.User.Dto;
using BookStore.User.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Auth;

[Route("api/[controller]")]
[ApiController]
public class AuthController : Controller
{
    private readonly SqlUserRepository _sqlUserRepository;

    public AuthController(SqlUserRepository sqlUserRepository)
    {
        _sqlUserRepository = sqlUserRepository;
    }


    [Route("Register")]
    [HttpGet]
    public async Task<IActionResult> Register(CreateUserDto createUserDto)
    {
        var userExist = await _sqlUserRepository.GetUserByEmail(createUserDto.Email);
        if (userExist != null)
        {
            return Conflict("User exists with the email");
        }

        await _sqlUserRepository.CreateUser(createUserDto);

        return Ok("Registration successful!");
    }
}