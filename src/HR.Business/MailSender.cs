using System.Net.Mail;
using System.Net;
using Microsoft.Extensions.Configuration;

namespace HR.Api.Helpers;

public static class MailSender
{
    public static async Task SendAsync(string to, string subject, string body, IConfiguration configuration)
    {
        SmtpClient smtp = new SmtpClient();
        smtp.Host = "smtp-mail.outlook.com";
        smtp.Port = 587;
        smtp.EnableSsl = true;
        smtp.Credentials = new NetworkCredential(configuration.GetSection("Mail").Value, configuration.GetSection("Password").Value);

        var mail = new MailMessage(configuration.GetSection("Mail").Value, to)
        {
            Subject = subject,
            Body = body
        };

        try
        {
            await smtp.SendMailAsync(mail);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Email error!");
        }
    }
}
