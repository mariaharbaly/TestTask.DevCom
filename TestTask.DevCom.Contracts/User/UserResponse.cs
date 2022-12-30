namespace TestTask.DevCom.Contracts.User;

public class UserResponse
{
    public int UserId { get; set; }
    public string Login  { get; set; } = null!;
    public string Password   { get; set; } = null!;
    public string FirstName   { get; set; } = null!;
    public string LastName   { get; set; } = null!;
    public DateTime DateOfBirth   { get; set; }
    public string Gender  { get; set; } = null!;
}