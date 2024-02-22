using IDrobeAPI.Application.Features.SendQueries.DTOs;
using Microsoft.AspNetCore.Http;
using System.Text;

namespace IDrobeAPI.Infrastructure.Implementation.Services.SendQueryServices;

public class SendQueryMailBody
{
    public string GetHtmlBody(IFormFileCollection logos, SendQueryCreateDTO queryInfo)
    {

        StringBuilder mailHtmlBody = new StringBuilder();

        mailHtmlBody.AppendLine("<html>");
        mailHtmlBody.AppendLine("<body style='background-color: #f2f2f2;'>");
        mailHtmlBody.AppendLine("<p style='font-family: Arial, sans-serif; line-height: 1.6;'>Hello,</p>");
        mailHtmlBody.AppendLine("<br/>");
        mailHtmlBody.AppendLine("<p style='font-family: Arial, sans-serif; line-height: 1.6;'>We have received an inquiry from someone interested in collaborating with us. Here are the details:</p>");
        mailHtmlBody.AppendLine("<br/>");
        mailHtmlBody.AppendLine($"<p style='font-family: Arial, sans-serif; line-height: 1.6;'><strong>Store Name:</strong> {queryInfo.StoreName}</p>");
        mailHtmlBody.AppendLine($"<p style='font-family: Arial, sans-serif; line-height: 1.6;'><strong>Phone Number:</strong> {queryInfo.PhoneNumber}</p>");
        mailHtmlBody.AppendLine($"<p style='font-family: Arial, sans-serif; line-height: 1.6;'><strong>Email Address:</strong> {queryInfo.Email}</p>");
        mailHtmlBody.AppendLine($"<p style='font-family: Arial, sans-serif; line-height: 1.6;'><strong>Address:</strong> {queryInfo.Addres}</p>");
        mailHtmlBody.AppendLine("<br/>");
        mailHtmlBody.AppendLine("<p style='font-family: Arial, sans-serif; line-height: 1.6;'>This individual or organization is interested in partnering with you. Please review this request and take the necessary steps.</p>");
        mailHtmlBody.AppendLine("<br/>");
        mailHtmlBody.AppendLine("<p style='font-family: Arial, sans-serif; line-height: 1.6;'>Best regards,</p>");
        mailHtmlBody.AppendLine("<br/>");
        mailHtmlBody.AppendLine("<br/>");


        mailHtmlBody.AppendLine("<div style='display: flex; justify-content: center; text-align: center;'>");
        mailHtmlBody.AppendLine("<table style='border-collapse: collapse;'>");
        mailHtmlBody.AppendLine("<tr>");

        foreach (IFormFile item in logos)
        {
            using (var stream = new MemoryStream())
            {
                item.CopyTo(stream);
                stream.Position = 0;
                var contentBytes = stream.ToArray();
                var base64Content = Convert.ToBase64String(contentBytes);
                mailHtmlBody.AppendLine("<td style='border: 2px solid #ccc; border-radius: 10px; padding: 10px;'>");
                mailHtmlBody.AppendLine($"<img src=\"data:image/jpeg;base64,{base64Content}\" alt=\"Logo\" style='max-width: 200px; max-height: 200px;'>");
                mailHtmlBody.AppendLine("</td>");

            }
        }

        mailHtmlBody.AppendLine("</tr>");
        mailHtmlBody.AppendLine("</table>");
        mailHtmlBody.AppendLine("</div>");

        mailHtmlBody.AppendLine("</body>");
        mailHtmlBody.AppendLine("</html>");

        return mailHtmlBody.ToString();
    }

    public string GetTextBody(SendQueryCreateDTO queryInfo)
    {
        StringBuilder mailTextBody = new StringBuilder();

        mailTextBody.AppendLine("Hello,");
        mailTextBody.AppendLine();
        mailTextBody.AppendLine("We have received an inquiry from someone interested in collaborating with us. Here are the details:");
        mailTextBody.AppendLine();
        mailTextBody.AppendLine($"Store Name: {queryInfo.StoreName}");
        mailTextBody.AppendLine($"Phone Number: {queryInfo.PhoneNumber}");
        mailTextBody.AppendLine($"Email Address: {queryInfo.Email}");
        mailTextBody.AppendLine($"Address: {queryInfo.Addres}");
        mailTextBody.AppendLine();
        mailTextBody.AppendLine("This individual or organization is interested in partnering with you. Please review this request and take the necessary steps.");
        mailTextBody.AppendLine();
        mailTextBody.AppendLine("Best regards,");

        return mailTextBody.ToString();
    }
}