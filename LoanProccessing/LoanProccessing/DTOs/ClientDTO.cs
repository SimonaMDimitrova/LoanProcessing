namespace LoanProccessing.DTOs;

public class ClientDTO
{
    public int Id { get; set; }

    public string FirstName { get; set; }

    public string SecondName { get; set; }

    public string LastName { get; set; }

    public string FullName => $"{FirstName} {SecondName} {LastName}";
}
