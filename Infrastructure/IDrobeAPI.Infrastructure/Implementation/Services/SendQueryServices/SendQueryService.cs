using IDrobeAPI.Application.Features.SendQueries.Models;
using IDrobeAPI.Application.Interfaces.IMails;
using IDrobeAPI.Application.Interfaces.IServices.SendQueryServices;
using IDrobeAPI.Application.Models.Mails;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using MimeKit;
using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace IDrobeAPI.Infrastructure.Implementation.Services.SendQueryServices;

internal class SendQueryService : ISendQueryService
{
    private readonly IMailService _mailService;
    private IConfiguration _configuration;
    private readonly SendQueryMailBody _queryMailBody;

    public SendQueryService(IMailService mailService, SendQueryMailBody queryMailBody, IConfiguration configuration)
    {
        _mailService = mailService;
        _queryMailBody = queryMailBody;
        _configuration = configuration;
    }

    public async Task<bool> SendQuery(SendQueryModel model)
    {

        Mail mail = new();

        mail.Subject = SendQueryConstants.mailSubject;
        mail.TextBody = _queryMailBody.GetTextBody(model.QueryInfo);
        mail.HtmlBody = _queryMailBody.GetHtmlBody(model.StoreLogos, model.QueryInfo);
        mail.ToFullName = SendQueryConstants.mailToFullName;
        mail.ToEmail = _configuration["SendQueryMail:ToMail"];

        AttachmentCollection mimeEntities = new AttachmentCollection();

        foreach (IFormFile item in model.StoreLogos)
        {
            var attachment = ConvertToAttachment(item);
            mimeEntities.Add(attachment);
        }

        mail.Attachments = mimeEntities;


        //_mailService.SendMail(mail);
        await Task.Run(() => _mailService.SendMail(mail));


        return true;
    }

    public MimeEntity ConvertToAttachment(IFormFile formFile)
    {
        using( var stream = new MemoryStream())
        {
            formFile.CopyTo(stream);
            stream.Position = 0;

            var attachment = new MimePart(formFile.ContentType)
            {
                Content = new MimeContent(stream),
                ContentDisposition = new ContentDisposition(ContentDisposition.Attachment),
                ContentTransferEncoding = ContentEncoding.Base64,
                FileName = formFile.FileName
            };

            return attachment;
        }
        
    }
}
