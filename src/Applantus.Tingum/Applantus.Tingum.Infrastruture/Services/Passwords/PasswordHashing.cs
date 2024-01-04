namespace Applantus.Tingum.Infrastruture.Services.Passwords;

public class PasswordHashing : IPasswordHashing
{
    public string Hash(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password); 
    }

    public bool Verify(string password, string hash)
    {
        return BCrypt.Net.BCrypt.Verify(password, hash);
    }
}
