using IDrobeAPI.Application.Interfaces.IMails;
using IDrobeAPI.Application.Models.Mails;
using Microsoft.Extensions.Configuration;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDrobeAPI.Infrastructure.Implementation.Mails;

public class MailKitMailService : IMailService
{
    private IConfiguration _configuration;
    private readonly MailSettings _mailSettings;

    public MailKitMailService(IConfiguration configuration)
    {
        _configuration = configuration;
        _mailSettings = _configuration.GetSection("MailSettings").Get<MailSettings>();
    }

    public void SendMail(Mail mail)
    {
        MimeMessage email = new();

        email.From.Add(new MailboxAddress(_mailSettings.SenderFullName, _mailSettings.SenderEmail));//gonderen email.From = MailboxAddress.Parse(_mailSettings.SenderEmail); kimi de yazmaq olardi tek tek

        email.To.Add(new MailboxAddress(mail.ToFullName, mail.ToEmail));//alici

        email.Subject = mail.Subject;//movzu/basliq

        BodyBuilder bodyBuilder = new()
        {
            TextBody = mail.TextBody,//body mailin icerisidir. html destekleyen stmp serverde html esas gotrulur, desteklenmeyen yerde ise text body qoyulur.
            HtmlBody = mail.HtmlBody
        };

        if (mail.Attachments != null) //file elave elemek maile
            foreach (MimeEntity? attachment in mail.Attachments)
                bodyBuilder.Attachments.Add(attachment);

        email.Body = bodyBuilder.ToMessageBody();

        using MailKit.Net.Smtp.SmtpClient smtp = new();
        smtp.Connect(_mailSettings.Server, _mailSettings.Port);
        smtp.Authenticate(_mailSettings.UserName, _mailSettings.Password);
        smtp.Send(email);
        smtp.Disconnect(true);
    }
}