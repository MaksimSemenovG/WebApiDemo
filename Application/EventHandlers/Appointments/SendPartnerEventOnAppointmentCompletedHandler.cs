using Application.Events;
using Core.Interfaces.ExternalServices;
using MediatR;
namespace Application.EventHandlers.Appointments;

public class SendPartnerEventOnAppointmentCompletedHandler : INotificationHandler<AppointmentCompletedEvent>
{
    private readonly IPartnerEventSender _partnerEventSender;

    public SendPartnerEventOnAppointmentCompletedHandler(IPartnerEventSender partnerEventSender)
    {
        _partnerEventSender = partnerEventSender;
    }

    public async Task Handle(AppointmentCompletedEvent notification, CancellationToken cancellationToken)
    {
        var appointment = notification.Appointment;
        await _partnerEventSender.Send(appointment);
    }
}
