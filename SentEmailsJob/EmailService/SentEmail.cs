using MimeKit;
using System;
using System.Collections.Generic;
using System.Net.Mail;

namespace SentEmailsJob.EmailService
{
    public class SentEmail
    {
        public async Task SendEmailAsync(string senderEmail, string senderPassword, string recipientEmail, string subject, string body)
        {
            return;

            // Create the email message
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Sender Name", senderEmail));
            message.To.Add(new MailboxAddress("Recipient Name", recipientEmail));
            message.Subject = subject;
            message.Body = new TextPart("plain")
            {
                Text = body
            };

            // Create the Smtp client and connect to the server
            using (var client = new SmtpClient())
            {
                //client.Connect("smtp.example.com", 587, SecureSocketOptions.StartTls); // Replace with your SMTP server settings
                //client.Authenticate(senderEmail, senderPassword);

                //// Send the email
                //await client.SendAsync(message);
            }
        }
    }
}
