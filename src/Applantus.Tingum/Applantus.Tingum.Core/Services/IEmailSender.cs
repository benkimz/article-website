using Applantus.Tingum.Core.Services.EmailService.Models;

namespace Applantus.Tingum.Core.Services;

public interface IEmailSender
{
    /// <summary>
    ///     from: new EmailEntity(username@your-domain.com, name)
    ///     to:  new List { 
    ///         new EmailEntity(email, name),
    ///         ...
    ///         }
    ///     body: type html,
    ///     cc: new List{
    ///         new EmailEntity(email, name),
    ///         ...
    ///         }
    /// </summary>
    /// <returns></returns>
    /// 
    Task<MailerResponse> SendSimpleAsync(
        EmailEntity from, 
        List<EmailEntity> to, 
        string? subject, 
        string? body, 
        List<EmailEntity>? cc = null
        ); 
}
