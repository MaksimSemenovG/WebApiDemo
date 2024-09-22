namespace Core.Entities;

public class Therapist
{
    public int Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Specialization { get; set; }

    public string FullName => $"{FirstName} {LastName}";
}
