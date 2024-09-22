using System.ComponentModel.DataAnnotations;

namespace TaskManager.DTOs.Account;

public class RegisterDto
{
    [Required] 
    public string FirstName { get; set; } = null!;
    [Required] 
    public string LastName { get; set; } = null!;
    [Required]
    public string UserName { get; set; } = null!;
    [Required][EmailAddress]
    public string Email { get; set; } =null!;
    [Required]
    public string Password { get; set; } = null!;

}