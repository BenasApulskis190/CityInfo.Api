namespace CityInfo.Api.Services
{
    public class LocalMailService : IMailService
    {
        private readonly string _mailTo = string.Empty;
        private readonly string _mailFrom = string.Empty;

        public LocalMailService(IConfiguration configuration)
        {
            _mailTo = configuration["MailSettings:mailToAddress"];
            _mailFrom = configuration["MailSettings:mailFromAddress"];
        }
        public void Send(string subject, string message)
        {
            //Send mail
            Console.WriteLine($"Mail from {_mailFrom} to {_mailTo}" + $"with {nameof(LocalMailService)}");
            Console.WriteLine($"Subject {subject}");
            Console.WriteLine($"Message: {message}");
        }

    }
}