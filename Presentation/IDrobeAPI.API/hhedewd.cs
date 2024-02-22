//using IDrobeAPI.Application.Models.Mails;
//using IDrobeAPI.Application.Models.Responses;
//using IDrobeAPI.Application.Services.SendQueryServices;
//using MimeKit;

//public class MailKitMailService : IMailService
//{
//    private IConfiguration _configuration;
//    private readonly MailSettings _mailSettings;

//    public MailKitMailService(IConfiguration configuration)
//    {
//        _configuration = configuration;
//        _mailSettings = _configuration.GetSection("MailSettings").Get<MailSettings>();
//    }

//    public void SendMail(Mail mail)
//    {
//        MimeMessage email = new();

//        email.From.Add(new MailboxAddress(_mailSettings.SenderFullName, _mailSettings.SenderEmail));//gonderen email.From = MailboxAddress.Parse(_mailSettings.SenderEmail); kimi de yazmaq olardi tek tek

//        email.To.Add(new MailboxAddress(mail.ToFullName, mail.ToEmail));//alici

//        email.Subject = mail.Subject;//movzu/basliq

//        BodyBuilder bodyBuilder = new()
//        {
//            TextBody = mail.TextBody,//body mailin icerisidir. html destekleyen stmp serverde html esas gotrulur, desteklenmeyen yerde ise text body qoyulur.
//            HtmlBody = mail.HtmlBody
//        };

//        if (mail.Attachments != null) //file elave elemek maile
//            foreach (MimeEntity? attachment in mail.Attachments)
//                bodyBuilder.Attachments.Add(attachment);

//        email.Body = bodyBuilder.ToMessageBody();

//        using MailKit.Net.Smtp.SmtpClient smtp = new();
//        smtp.Connect(_mailSettings.Server, _mailSettings.Port);
//        smtp.Authenticate(_mailSettings.UserName, _mailSettings.Password);
//        smtp.Send(email);
//        smtp.Disconnect(true);
//    }
//}

//public class Mail
//{
//    public string Subject { get; set; }
//    public string TextBody { get; set; }
//    public string HtmlBody { get; set; }
//    public MimeKit.AttachmentCollection? Attachments { get; set; }
//    public string ToFullName { get; set; }
//    public string ToEmail { get; set; }

//    public Mail()
//    {
//    }

//    public Mail(string subject, string textBody, string htmlBody, AttachmentCollection? attachments, string toFullName,
//                string toEmail)
//    {
//        Subject = subject;
//        TextBody = textBody;
//        HtmlBody = htmlBody;
//        Attachments = attachments;
//        ToFullName = toFullName;
//        ToEmail = toEmail;
//    }
//}

//public class SendQueryCreateDTO
//{
//    public string StoreName { get; set; }
//    public string PhoneNumber { get; set; }
//    public string Email { get; set; }
//    public string Addres { get; set; }
//    public FileStream StoreLogo { get; set; }
//}

//internal class SendQueryService : ISendQueryService
//{
//    private readonly IMailService _mailService;

//    public SendQueryService(IMailService mailService)
//    {
//        _mailService = mailService;
//    }

//    public async Task<GenericActionResponse<bool>> SendQueryAsync(SendQueryCreateDTO model)
//    {
//        GenericActionResponse<bool> response = new GenericActionResponse<bool>(false, System.Net.HttpStatusCode.BadRequest, false, "Nem");

//        Mail mail = new();
//        mail.Subject = "Store Query Mail";
//        mail.TextBody = "Test Text Body";
//        mail.HtmlBody = "Test Html Body";
//        mail.ToFullName = "IDrobe Support Team";
//        mail.ToEmail = "info@idrobe.az";//todo daha yaxsi yaz
//        mail.Attachments = model.StoreLogo.Name;


//        _mailService.SendMail(mail);


//        return response;
//    }
//}