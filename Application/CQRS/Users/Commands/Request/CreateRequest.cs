using System.ComponentModel.DataAnnotations;

namespace Application.CQRS.Users.Commands.Request;

public abstract class CreateRequest
{
    [Required]
    public string Username { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Required]
    [Compare("Password")]
    public string ConfirmPassword { get; set; }

    [Required]
    public DateTime BirthDate { get; set; }

    public CreateRequest()
    {
        
    }
}
