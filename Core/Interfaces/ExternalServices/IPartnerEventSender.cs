using Core.Entities;

namespace Core.Interfaces.ExternalServices;

public interface IPartnerEventSender
{
    Task Send(Appointment appointment);
}
