namespace BookStore.Auth.Repository;

public interface ITokenRepository
{
    string CreateJwtToken(User.User user);
}