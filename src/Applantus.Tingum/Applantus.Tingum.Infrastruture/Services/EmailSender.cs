using Applantus.Tingum.Core.Services;

namespace Applantus.Tingum.Infrastruture.Services;

public class EmailSender : IEmailSender
{
    public Task SendAsync(string from, string to, string body, string? subject)
    {
        throw new NotImplementedException();
    }
}
