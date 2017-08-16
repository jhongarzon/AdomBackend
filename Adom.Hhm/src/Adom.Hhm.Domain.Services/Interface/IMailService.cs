using Adom.Hhm.Domain.Entities;

namespace Adom.Hhm.Domain.Services.Interface
{
    public interface IMailService
    {
        bool SendMail(MailMessage mailMessage);
    }
}
