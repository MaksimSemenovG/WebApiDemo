using Core.Entities;
using MediatR;

namespace Application.Events;

public class AppointmentCompletedEvent : INotification
{
    public Appointment Appointment { get; }

    public AppointmentCompletedEvent(Appointment appointment)
    {
        Appointment = appointment;
    }
}
