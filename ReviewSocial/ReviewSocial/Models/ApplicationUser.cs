using Microsoft.AspNetCore.Identity;
public class ApplicationUser : IdentityUser
{
    public string Email { get; set; }
    public string Password { get; set; }
    public string Username { get; set; }
    public string password { get; set; }
    public string Avatar { get; set; }
}
