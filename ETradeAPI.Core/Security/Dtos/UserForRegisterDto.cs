namespace ETradeAPI.Core.Security.Dtos;

public class UserForRegisterDto
{
    public string Email { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string FullAddress { get; set; }
}