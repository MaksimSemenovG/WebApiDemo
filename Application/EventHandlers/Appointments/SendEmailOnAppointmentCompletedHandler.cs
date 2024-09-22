using Application.Events;
using Core.Interfaces.ExternalServices;
using MediatR;

namespace Application.EventHandlers.Appointments;

public class SendEmailOnAppointmentCompletedHandler : INotificationHandler<AppointmentCompletedEvent>
{
    private readonly IEmailSender _emailSender;

    public SendEmailOnAppointmentCompletedHandler(IEmailSender emailSender)
    {
        _emailSender = emailSender;
    }

    public async Task Handle(AppointmentCompletedEvent notification, CancellationToken cancellationToken)
    {
        var appointment = notification.Appointment;
        await _emailSender.Send("patient@example.com", "Appointment Completed", $"Your appointment on {appointment.AppointmentDate} is now completed.");
    }
}
