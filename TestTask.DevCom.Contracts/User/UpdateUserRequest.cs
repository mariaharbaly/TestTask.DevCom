namespace TestTask.DevCom.Contracts.User;

public class UpdateUserRequest
{
    public string FirstName   { get; set; } = null!;
    public string LastName   { get; set; } = null!;
    public DateTime DateOfBirth   { get; set; } 
    public string Gender   { get; set; } = null!;
}