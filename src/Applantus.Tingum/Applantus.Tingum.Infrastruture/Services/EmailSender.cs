using Api.Mailgun;
using Applantus.Tingum.Core.Services;
using Applantus.Tingum.Core.Services.EmailService.Models;

namespace Applantus.Tingum.Infrastruture.Services;

public class EmailSender : IEmailSender
{
    // string from, string to, string? body, string? subject
   /* public async Task SendAsync()
    {
        var mailgunDomain = Environment.GetEnvironmentVariable("MAILGUN_DOMAIN");
        var apiKey = Environment.GetEnvironmentVariable("MAILGUN_API_KEY");
        var baseUri = Environment.GetEnvironmentVariable("MAILGUN_BASE_URI"); 
        
        var mailgun = new Mailgun(workDomain: mailgunDomain, apiKey: apiKey, baseUri: baseUri); 
        var message = new Message()
        {
            From = new EmailAddress("support@beamtm.com", "Support Team"),
            To = new List<EmailAddress>()
                {
                    new EmailAddress("benkim3619@gmail.com"),
                    new EmailAddress("benkimz@beamtm.com")
                },
            Cc = new List<EmailAddress>()
                {
                    new EmailAddress("nancynjeri592@gmail.com")
                },
            Subject = "~benkimz: System Tests",
            Html = "<h1>Hello, dear user!</h1>",
            Dkim = true,
            RequireTls = true,
            Tracking = true
        };

        Console.WriteLine(">>>>>>>>> send mails");
        var result = await mailgun.SendMessageAsync(message);
        if (result != null)
        {
            Console.WriteLine(result.Successful.ToString());
            Console.WriteLine(result.ErrorMessage);
        }
        Console.WriteLine("<<<<<<<< check mails");
        //throw new NotImplementedException();
    }*/

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

        Console.WriteLine(">>>>>>>>> send mails");
        var result = await mailgun.SendMessageAsync(message);
        
        if (result != null)
        {
            Console.WriteLine(result.Successful.ToString());
            Console.WriteLine(result.ErrorMessage);
        }
        Console.WriteLine("<<<<<<<< check mails");

        if (result is not null)
            return new MailerResponse(result.Successful, result.ErrorMessage);
        return new MailerResponse(false, "Returned null response.");
    }
}
