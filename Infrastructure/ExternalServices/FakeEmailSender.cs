using Core.Interfaces.ExternalServices;

namespace Infrastructure.ExternalServices;

public class FakeEmailSender : IEmailSender
{
    public Task Send(string recipient, string subject, string body)
    {
        // Simulating email sending
        Console.WriteLine($"Email sent to {recipient}: {subject} - {body}");
        return Task.CompletedTask;
    }
}