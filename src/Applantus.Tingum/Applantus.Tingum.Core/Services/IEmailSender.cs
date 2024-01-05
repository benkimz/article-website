namespace Applantus.Tingum.Core.Services;

public interface IEmailSender
{
    Task SendAsync(string fromEmail, string toEmail, string? htmlBody = null, string? plainTextBody = null, string? subject = null, string? fromName = null, string? toName = null); 
}
