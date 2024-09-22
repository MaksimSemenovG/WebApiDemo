using Core.Enums;

namespace Core.Entities;

public class Appointment
{
    public int Id { get; set; }

    public int TherapistId { get; set; } 

    public string PatientName { get; set; }

    public DateTime AppointmentDate { get; set; }

    public Therapist Therapist { get; set; }

    public bool IsFutureAppointment => AppointmentDate > DateTime.Now;

    public AppointmentStatus Status { get; set; } = AppointmentStatus.New;

    public void Reschedule(DateTime newDate)
    {
        if (Status != AppointmentStatus.New)
        {
            throw new InvalidOperationException($"Unable to cancel a consultation with status = {Status}");
        }

        if (newDate <= DateTime.Now)
            throw new ArgumentException("New date must be in the future");

        AppointmentDate = newDate;
    }
    
    public void MarkAsCompleted()
    {
        if (Status != AppointmentStatus.New)
        {
            throw new InvalidOperationException($"Unable to cancel a consultation with status = {Status}");
        }

        Status = AppointmentStatus.Completed;
    }

    public void Cancel()
    {
        if (Status != AppointmentStatus.New)
        {
            throw new InvalidOperationException($"Unable to cancel a consultation with status = {Status}");
        }

        if (!IsFutureAppointment)
        {
            throw new ArgumentException("Unable to cancel a past consultation");
        }

        if (IsFutureAppointment && (AppointmentDate - DateTime.Now).TotalHours <= 24)
        {
            Status = AppointmentStatus.CanceledLate;
        }
        else
        {
            Status = AppointmentStatus.Canceled;
        }
    }
}
