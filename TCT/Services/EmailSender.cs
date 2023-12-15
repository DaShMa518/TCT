﻿using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace TCT.Services
{

    public class EmailSender : IEmailSender
    {
        private readonly ILogger _logger;

        public EmailSender(/*IOptions<AuthMessageSenderOptions> optionsAccessor,*/
                           ILogger<EmailSender> logger)
        {
            //Options = optionsAccessor.Value;
            _logger = logger;
        }

        //public AuthMessageSenderOptions Options { get; } //Set with Secret Manager.

        public async Task SendEmailAsync(string toEmail, string subject, string message)
        {
            var apiKey = Environment.GetEnvironmentVariable("SENDGRID_API_KEY");
            //if (string.IsNullOrEmpty(Options.SendGridKey))
            if (string.IsNullOrEmpty(apiKey))
            {
                throw new Exception("Null SendGridKey");
            }

            //await Execute(Options.SendGridKey, subject, message, toEmail);
            await Execute(apiKey, subject, message, toEmail);
        }

        public async Task Execute(string apiKey, string subject, string message, string toEmail)
        {
            var client = new SendGridClient(apiKey);
            var msg = new SendGridMessage()
            {
                From = new EmailAddress("dashmaye@gmail.com", "Password Recovery"),
                Subject = subject,
                PlainTextContent = message,
                HtmlContent = message
            };
            msg.AddTo(new EmailAddress(toEmail));

            // Disable click tracking.
            // See https://sendgrid.com/docs/User_Guide/Settings/tracking.html
            msg.SetClickTracking(false, false);
            var response = await client.SendEmailAsync(msg);
            _logger.LogInformation(response.IsSuccessStatusCode
                                   ? $"Email to {toEmail} queued successfully!"
                                   : $"Failure Email to {toEmail}");
        }
    }
}