namespace Applantus.Tingum.Core.Services.EmailService.Models;

public class MailerResponse
{
    public bool IsSuccess { get; set; }
    public string Message { get; set; } = string.Empty;
    public DateTime TimeStamp => DateTime.UtcNow;
    public MailerResponse(bool success, string message)
    {
        IsSuccess = success; 
        Message = message;
    }
}
