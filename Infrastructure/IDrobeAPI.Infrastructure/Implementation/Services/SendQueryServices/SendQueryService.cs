using IDrobeAPI.Application.Features.SendQueries.Constants;
using IDrobeAPI.Application.Interfaces.IMails;
using IDrobeAPI.Application.Interfaces.IServices.SendQueryServices;
using IDrobeAPI.Application.Models.Mails;
using IDrobeAPI.Application.Models.Responses;
using IDrobeAPI.Application.Models.SendQueries;
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

    public GenericActionResponse<bool> SendQuery(SendQueryModel model)
    {
        GenericActionResponse<bool> response = new GenericActionResponse<bool>(false, System.Net.HttpStatusCode.BadRequest, false, SendQueryResponseMessageConstants.Response_Message_Error);

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


        _mailService.SendMail(mail);
        //await Task.Run(() => _mailService.SendMail(mail));

        response.Message = SendQueryResponseMessageConstants.Response_Message;
        response.ResponseCode = System.Net.HttpStatusCode.OK;
        response.Data = true;
        response.RequestSuccessful = true;

        return response;
    }

    public MimeEntity ConvertToAttachment(IFormFile formFile)
    {
        var stream = new MemoryStream(); //todo bunu usuing yazanda xeta olur


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
