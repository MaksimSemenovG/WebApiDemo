using Core.Entities;
using Core.Interfaces.ExternalServices;

namespace Infrastructure.ExternalServices;

public class FakePartnerEventSender : IPartnerEventSender
{
    public Task Send(Appointment appointment)
    {
        // Simulating sending event to partner with appointment details
        Console.WriteLine($"Event sent: Appointment ID: {appointment.Id}, Date: {DateTime.Now}");
        return Task.CompletedTask;
    }
}
