namespace ETradeAPI.Core.Security.Dtos;

public class UserForLoginDto
{
    public string EmailOrUsername { get; set; }
    public string Password { get; set; }
}