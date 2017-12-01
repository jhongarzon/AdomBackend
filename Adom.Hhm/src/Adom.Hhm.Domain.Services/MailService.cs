using System;
using Adom.Hhm.Domain.Entities;
using Adom.Hhm.Domain.Services.Interface;
using MailKit.Net.Imap;
using MailKit.Net.Smtp;
using MimeKit;

namespace Adom.Hhm.Domain.Services
{
    public class MailService : IMailService
    {
        private readonly MimeMessage _mimeMessage;
        private readonly MailServerConfig _mailServerConfig;
        public MailService(MailServerConfig mailServerConfig)
        {
            _mimeMessage = new MimeMessage();
            _mimeMessage.From.Add(new MailboxAddress(mailServerConfig.From.Name, mailServerConfig.From.MailAddress));
            _mailServerConfig = mailServerConfig;
        }

        public bool SendMail(MailMessage mailMessage)
        {
            _mimeMessage.Subject = mailMessage.Subject;
            if (mailMessage.HtmlBody)
            {
                var builder = new BodyBuilder {HtmlBody = mailMessage.Body};
                _mimeMessage.Body = builder.ToMessageBody();

            }
            else
            {
                _mimeMessage.Body = new TextPart("plain") { Text = mailMessage.Body };
            }
            
            _mimeMessage.To.Add(new MailboxAddress(mailMessage.To.Name, mailMessage.To.MailAddress));
            if (_mailServerConfig?.CopyTo == null) return false;

            foreach (var mailAccount in _mailServerConfig.CopyTo)
            {
                _mimeMessage.Cc.Add(new MailboxAddress(mailAccount.Name, mailAccount.MailAddress));
            }
            try
            {
                using (var client = new SmtpClient())
                {
                    client.Connect(_mailServerConfig.Server, _mailServerConfig.Port, true);
                    client.Authenticate(_mailServerConfig.From.MailAddress, _mailServerConfig.From.Password);

                    client.AuthenticationMechanisms.Remove("XOAUTH2");

                    // Note: since we don't have an OAuth2 token, disable 	// the XOAUTH2 authentication mechanism.     client.Authenticate("anuraj.p@example.com", "password");
                    client.Send(_mimeMessage);
                    client.Disconnect(true);
                    return true;
                }
            }
            catch (Exception)
            {
                return true;
            }
        }
    }
}
