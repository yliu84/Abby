﻿using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using MimeKit;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace AbbyRestaurant.Utility
{
    public class EmailSender : IEmailSender
    {
        public string SendGridSecret { get; set; }
        public EmailSender(IConfiguration _config)
        {
            SendGridSecret = _config.GetValue<string>("SendGrid:SecretKey");
        }
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            //var emailToSend = new MimeMessage();
            //emailToSend.From.Add(MailboxAddress.Parse("no_reply@yangpro.com"));
            //emailToSend.To.Add(MailboxAddress.Parse(email));
            //emailToSend.Subject = subject;
            //emailToSend.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            //{
            //    Text = htmlMessage
            //};

            ////send email
            //using(var emailClient = new SmtpClient())
            //{
            //    emailClient.Connect("smtp:gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
            //    emailClient.Authenticate("yangliu0127@gmail.com", "");
            //    emailClient.Send(emailToSend);
            //    emailClient.Disconnect(true);
            //}

            var client = new SendGridClient(SendGridSecret);
            var from = new EmailAddress("yangliu0127@gmail.com", "Abby Food");
            var to = new EmailAddress(email);
            var msg = MailHelper.CreateSingleEmail(from,to,subject,"",htmlMessage);

            return client.SendEmailAsync(msg);


            //return Task.CompletedTask;
        }
    }
}
