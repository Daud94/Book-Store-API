using BookStore.User.Dto;

namespace BookStore.User.Repository;

public interface IUserRepository
{
    Task<User> CreateUser(CreateUserDto createUserDto);

    Task<User> GetUserByEmail(string email);
    Task<User> GetUserById(int id);

   bool CheckPassword(string password, string hashedPassword);
}