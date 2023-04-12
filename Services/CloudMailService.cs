namespace CityInfo.Api.Services
{
    public class CloudMailService : IMailService
    {
        private string _mailTo = "admin@admin.com";
        private string _mailFrom = "admin@adminFrom.com";

        public void Send(string subject, string message)
        {
            //Send mail
            Console.WriteLine($"CloudMail from {_mailFrom} to {_mailTo}" + $"with {nameof(CloudMailService)}");
            Console.WriteLine($"Subject {subject}");
            Console.WriteLine($"Message: {message}");
        }

    }
}