using Applantus.Tingum.Core.Services;
using SendGrid.Helpers.Mail;
using SendGrid;

namespace Applantus.Tingum.Infrastruture.Services;

public class EmailSender : IEmailSender
{
    private string? ApiKey => Environment.GetEnvironmentVariable("SENDGRID_API_KEY");

    public async Task SendAsync(string fromEmail, string toEmail, string? htmlBody = null, string? plainTextBody = null, string? subject = null, string? fromName = null, string? toName = null)
    {
        var apiKey = Environment.GetEnvironmentVariable("SENDGRID_API_KEY");
        var client = new SendGridClient(apiKey);
        var from = new EmailAddress(fromEmail, "From User");
        var to = new EmailAddress(toEmail, "To User");
        var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent: plainTextBody, htmlContent: htmlBody);
        var response = await client.SendEmailAsync(msg);
        Console.WriteLine(">>>>>>>>>>> Response print");
        Console.WriteLine(response.StatusCode.ToString());
        Console.WriteLine(await response.Body.ReadAsStringAsync());
        Console.WriteLine("<<<<<<<<<<<<<<<< End response print:");
    }
}
