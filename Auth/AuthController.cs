using BookStore.Auth.Dto;
using BookStore.Auth.Repository;
using BookStore.User.Dto;
using BookStore.User.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Auth;

[Route("api/[controller]")]
[ApiController]
public class AuthController : Controller
{
    private readonly SqlUserRepository _sqlUserRepository;
    private readonly TokenRepository _tokenRepository;

    public AuthController(SqlUserRepository sqlUserRepository, TokenRepository tokenRepository)
    {
        _sqlUserRepository = sqlUserRepository;
        _tokenRepository = tokenRepository;
    }


    [Route("Register")]
    [HttpPost]
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

    [Route("Login")]
    [HttpPost]
    public async Task<IActionResult> Login(LoginRequestDto loginRequestDto)
    {
        var existingUser = await _sqlUserRepository.GetUserByEmail(loginRequestDto.Email);
        if (existingUser == null)
        {
            return NotFound("User not found");
        }

        var isPasswordValid = _sqlUserRepository.CheckPassword(loginRequestDto.Password, existingUser.Password);

        if (!isPasswordValid)
        {
            return BadRequest("Incorrect password");
        }

        var token = _tokenRepository.CreateJwtToken(existingUser);

        return Ok(new
        {
            success = true,
            message = "Login successful",
            accessToken = token
        });
    }
}