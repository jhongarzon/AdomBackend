namespace Adom.Hhm.Domain.Entities
{
    public class MailAccount
    {
        public MailAccount(string name, string mailAddress)
        {
            Name = name;
            MailAddress = mailAddress;
        }
        public MailAccount(string name, string mailAddress, string password)
        {
            Name = name;
            MailAddress = mailAddress;
            Password = password;
        }
        public string Name { get; set; }
        public string MailAddress { get; set; }
        public string Password { get; set; }
    }
}
