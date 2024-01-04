namespace Applantus.Tingum.Infrastruture.Services.Passwords;

public interface IPasswordHashing
{
    string Hash(string password); 

    bool Verify(string password, string hash); 
}
