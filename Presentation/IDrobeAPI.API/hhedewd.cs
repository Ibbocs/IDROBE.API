//using IDrobeAPI.Application.Interfaces.IServices.SendQueryServices;
//using IDrobeAPI.Application.Models.Mails;
//using IDrobeAPI.Application.Models.Responses;
//using IDrobeAPI.Application.Models.SendQueries;
//using IDrobeAPI.Infrastructure.Implementation.Services.SendQueryServices;
//using Microsoft.AspNetCore.Mvc;
//using MimeKit;

//internal class SendQueryService : ISendQueryService
//{
//    private readonly IMailService _mailService;
//    private IConfiguration _configuration;
//    private readonly SendQueryMailBody _queryMailBody;

//    public SendQueryService(IMailService mailService, SendQueryMailBody queryMailBody, IConfiguration configuration)
//    {
//        _mailService = mailService;
//        _queryMailBody = queryMailBody;
//        _configuration = configuration;
//    }

//    public GenericActionResponse<bool> SendQuery(SendQueryModel model)
//    {
//        GenericActionResponse<bool> response = new GenericActionResponse<bool>(false, System.Net.HttpStatusCode.BadRequest, false, SendQueryResponseMessageConstants.Response_Message_Error);

//        Mail mail = new();

//        mail.Subject = SendQueryConstants.mailSubject;
//        mail.TextBody = _queryMailBody.GetTextBody(model.QueryInfo);
//        mail.HtmlBody = _queryMailBody.GetHtmlBody(model.StoreLogos, model.QueryInfo);
//        mail.ToFullName = SendQueryConstants.mailToFullName;
//        mail.ToEmail = _configuration["SendQueryMail:ToMail"];

//        AttachmentCollection mimeEntities = new AttachmentCollection();

//        foreach (IFormFile item in model.StoreLogos)
//        {
//            var attachment = ConvertToAttachment(item);
//            mimeEntities.Add(attachment);
//        }

//        mail.Attachments = mimeEntities;


//        _mailService.SendMail(mail);
//        //await Task.Run(() => _mailService.SendMail(mail));

//        response.Message = SendQueryResponseMessageConstants.Response_Message;
//        response.ResponseCode = System.Net.HttpStatusCode.OK;
//        response.Data = true;
//        response.RequestSuccessful = true;

//        return response;
//    }

//    public MimeEntity ConvertToAttachment(IFormFile formFile)
//    {
//        using (var stream = new MemoryStream())
//        {
//            formFile.CopyTo(stream);
//            stream.Position = 0;

//            var attachment = new MimePart(formFile.ContentType)
//            {
//                Content = new MimeContent(stream),
//                ContentDisposition = new ContentDisposition(ContentDisposition.Attachment),
//                ContentTransferEncoding = ContentEncoding.Base64,
//                FileName = formFile.FileName
//            };

//            return attachment;
//        }

//    }
//}

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

//[HttpPost("po2")]
//public void SendQuery([FromQuery] SendQueryModel model)//FromForm
//{
//    //SendQueryModel sendQueryModel = new SendQueryModel();
//    //sendQueryModel.QueryInfo = model;
//    //sendQueryModel.StoreLogo.Add(file);

//    var data = _queryService.SendQuery(model);
//}