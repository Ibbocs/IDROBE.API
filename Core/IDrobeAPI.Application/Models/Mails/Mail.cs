using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDrobeAPI.Application.Models.Mails;

public class Mail
{
    public string Subject { get; set; }
    public string TextBody { get; set; }
    public string HtmlBody { get; set; }
    public MimeKit.AttachmentCollection? Attachments { get; set; }
    public string ToFullName { get; set; }
    public string ToEmail { get; set; }

    public Mail()
    {
    }

    public Mail(string subject, string textBody, string htmlBody, AttachmentCollection? attachments, string toFullName,
                string toEmail)
    {
        Subject = subject;
        TextBody = textBody;
        HtmlBody = htmlBody;
        Attachments = attachments;
        ToFullName = toFullName;
        ToEmail = toEmail;
    }
}
