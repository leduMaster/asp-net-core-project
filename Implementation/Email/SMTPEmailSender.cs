using Application.Email;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Net;
using System.Text;

namespace Implementation.Email
{
    public class SMTPEmailSender : IEmailSender
    { 
        public void Send(SendEmailDto dto)
        {
            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("dusan.nikolic.1.15.asp@gmail.com", "AspJeNajjaciPredmet")
            };
            var message = new MailMessage("dusan.nikolic.1.15.asp@gmail.com", dto.SendTo);
            message.Subject = dto.Subject;
            message.Body = dto.Content;
            message.IsBodyHtml = true;
            smtp.Send(message);
        }
    }
}
