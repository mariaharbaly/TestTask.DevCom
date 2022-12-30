namespace TestTask.DevCom.Contracts.User;

public class CreateUserRequest
{
    public string Login  { get; set; } = null!;
    public string Password   { get; set; } = null!;
    public string FirstName   { get; set; } = null!;
    public string LastName   { get; set; } = null!;
    public DateTime DateOfBirth   { get; set; }
    public string Gender   { get; set; } = null!;
}