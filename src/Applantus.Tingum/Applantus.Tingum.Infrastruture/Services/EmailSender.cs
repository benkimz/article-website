using Api.Mailgun;
using Applantus.Tingum.Core.Services;
using Applantus.Tingum.Core.Services.EmailService.Models;

namespace Applantus.Tingum.Infrastruture.Services;

public class EmailSender : IEmailSender
{
    public async Task<MailerResponse> SendSimpleAsync(EmailEntity from, List<EmailEntity> to, string? subject, string? body, List<EmailEntity>? cc = null)
    {
        var mailgunDomain = Environment.GetEnvironmentVariable("MAILGUN_DOMAIN");
        var apiKey = Environment.GetEnvironmentVariable("MAILGUN_API_KEY");
        var baseUri = Environment.GetEnvironmentVariable("MAILGUN_BASE_URI");

        var mailgun = new Mailgun(workDomain: mailgunDomain, apiKey: apiKey, baseUri: baseUri);
        var message = new Message()
        {
            From = new EmailAddress(from.Address, from.Name),
            To = to.Select(e => new EmailAddress(e.Address, e.Name)).ToList(),
            Cc = cc?.Select(e => new EmailAddress(e.Address, e.Name)).ToList() ?? null,
            Subject = subject,
            Html = body,
            Dkim = true,
            RequireTls = true,
            Tracking = true
        };

        var result = await mailgun.SendMessageAsync(message);
        if (result is not null)
            return new MailerResponse(result.Successful, result.ErrorMessage);
        return new MailerResponse(false, "Returned null response.");
    }
}
