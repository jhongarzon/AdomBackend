namespace Adom.Hhm.Domain.Entities
{
    public class MailMessage
    {
        public MailAccount To { get; set; }
        public string Body { get; set; }
        public string Subject { get; set; }
        public bool HtmlBody { get; set; } = true;
    }
}
