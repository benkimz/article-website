namespace Applantus.Tingum.Core.Services;

public interface IEmailSender
{
    Task SendAsync(string from, string to, string body, string? subject); 
}
