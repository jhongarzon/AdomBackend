namespace Adom.Hhm.Domain.Entities
{
    public class MailServerConfig
    {
        public string Server { get; set; }
        public int Port { get; set; }
        public string AccountName { get; set; }
        public MailAccount From { get; set; }
    }
}
