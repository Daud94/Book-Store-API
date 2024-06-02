using BookStore.Database;
using BookStore.Helper;
using BookStore.User.Dto;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace BookStore.User.Repository;

public class SqlUserRepository : IUserRepository
{
    private readonly BookStoreDbContext _bookStoreDbContext;
    private readonly PasswordHelper _passwordHelper;

    public SqlUserRepository(BookStoreDbContext bookStoreDbContext, PasswordHelper passwordHelper)
    {
        _bookStoreDbContext = bookStoreDbContext;
        _passwordHelper = passwordHelper;
    }


    public async Task<User> CreateUser(CreateUserDto createUserDto)
    {
        var user = new User()
        {
            FirstName = createUserDto.FirstName,
            LastName = createUserDto.LastName,
            Email = createUserDto.Email,
            Password = _passwordHelper.HashPassword(createUserDto.Password)
        };
        await _bookStoreDbContext.Users.AddAsync(user);
        await _bookStoreDbContext.SaveChangesAsync();
        return user;
    }

    public async Task<User?> GetUserByEmail(string email)
    {
        return await _bookStoreDbContext.Users.FirstOrDefaultAsync(user => user.Email == email);
    }

    public async Task<User?> GetUserById(int id)
    {
        return await _bookStoreDbContext.Users.FirstOrDefaultAsync(user => user.Id == id);
    }
}