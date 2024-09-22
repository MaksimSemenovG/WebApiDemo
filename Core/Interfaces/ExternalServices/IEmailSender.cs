namespace Core.Interfaces.ExternalServices;

public interface IEmailSender
{
    Task Send(string recipient, string subject, string body);
}
