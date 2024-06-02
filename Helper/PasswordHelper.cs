namespace BookStore.Helper;

public class PasswordHelper
{
    private readonly IConfiguration _configuration;

    public PasswordHelper(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    public string HashPassword(string password)
    {
        var workFactor = _configuration.GetValue<int>("BCrypt:WorkFactor");
        return BCrypt.Net.BCrypt.HashPassword(password, workFactor: workFactor);
    }

    public bool VerifyPassword(string password, string hashedPassword)
    {
        return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
    }
}