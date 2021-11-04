using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Threading.Tasks;

namespace WanderersDiary.API.Services.Email
{
    public interface IEmailService
    {
        public Task SendAsync(string address, EmailMessage message);
    }

    public class EmailService : IEmailService
    {
        #region Constructor & settings

        private readonly IConfiguration _config;

        private string _fromAddress;
        private string _fromName;
        private string _smtpServer;
        private string _userName;
        private string _password;

        public EmailService(IConfiguration config)
        {
            _config = config;

            IntitializeSettings();          
        }

        private void IntitializeSettings()
        {
            _fromAddress = _config["SMTP:From:Address"];
            _fromName = _config["SMTP:From:DisplayName"];
            _smtpServer = _config["SMTP:Credentials:ServerName"];
            _userName = _config["SMTP:Credentials:UserName"];
            _password = _config["SMTP:Credentials:Password"];
        }

        #endregion

        public async Task SendAsync(string address, EmailMessage messageModel)
        {
            MailAddress from = new MailAddress(_fromAddress, _fromName);
            MailAddress to = new MailAddress(address);

            MailMessage messageToSend = new MailMessage(from, to);

            messageToSend.Subject = messageModel.Subject;
            messageToSend.Body = messageModel.HtmlContent;
            messageToSend.IsBodyHtml = true;

            SmtpClient smtp = new SmtpClient(_smtpServer, 587);
            smtp.Credentials = new NetworkCredential(_userName, _password);
            smtp.EnableSsl = true;

            await smtp.SendMailAsync(messageToSend);
        }
    }

    public class EmailMessage
    {
        public string Subject { get; set; }

        public string HtmlContent { get; set; }
    }
}
