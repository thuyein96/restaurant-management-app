namespace RestaurantManagementApp.Modules.Helper.Email;

public interface IEmailService
{
    Task<string> SendEmailAsync(string toEmail, string subject, string body);
    Task<string> GetAccountAsync();
}