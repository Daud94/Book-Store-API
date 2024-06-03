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
    private readonly IUserRepository _userRepository;
    private readonly ITokenRepository _tokenRepository;

    public AuthController(IUserRepository userRepository,
        ITokenRepository tokenRepository)
    {
        _userRepository = userRepository;
        _tokenRepository = tokenRepository;
    }


    [Route("Register")]
    [HttpPost]
    public async Task<IActionResult> Register(CreateUserDto createUserDto)
    {
        // var userExist = await _sqlUserRepository.GetUserByEmail(createUserDto.Email);
        var userExist = await _userRepository.GetUserByEmail(createUserDto.Email);

        if (userExist != null)
        {
            return Conflict("User exists with the email");
        }

        await _userRepository.CreateUser(createUserDto);

        return Ok(new
        {
            success = true,
            message = "Registration successful!",
        });
    }

    [Route("Login")]
    [HttpPost]
    public async Task<IActionResult> Login(LoginRequestDto loginRequestDto)
    {
        var existingUser = await _userRepository.GetUserByEmail(loginRequestDto.Email);
        if (existingUser == null)
        {
            return NotFound("User not found");
        }

        var isPasswordValid = _userRepository.CheckPassword(loginRequestDto.Password, existingUser.Password);

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