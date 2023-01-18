
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using skill_test.Interfaces;
using skill_test.Models.Settings;

namespace skill_test.Services.Smtp;

public class SmtpServices : ISmtp
{
    private readonly MailSettings _mailSettings;
    public SmtpServices(IOptions<MailSettings> mailSetting)
    {
        _mailSettings = mailSetting.Value;
    }
    public bool SendMail(string lastName, string emailAddress)
    {
        var email = new MimeMessage();
        email.From.Add(MailboxAddress.Parse(_mailSettings.Mail));
        email.To.Add(MailboxAddress.Parse(emailAddress));
        email.Subject = "Skill Test Email";
        email.Body = new TextPart(MimeKit.Text.TextFormat.Plain) { Text = "Your Email was used in Skill test, " + lastName };

        try
        {
            using var smtp = new SmtpClient();
            smtp.Connect(_mailSettings.Host, _mailSettings.Port , SecureSocketOptions.StartTls);
            smtp.Authenticate(_mailSettings.Mail, _mailSettings.Password);
            smtp.Send(email);
            smtp.Disconnect(true);

            return true;
        }
        catch (Exception)
        {
            throw;
        }

    }
}