using System.ComponentModel.DataAnnotations;

namespace RazorAuth.ViewModels;

public class RegisterViewModel
{
    [Required]
    [DataType(DataType.EmailAddress)]
    public string? Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string? Password { get; set; }

    [Required]
    [DataType(DataType.Password)]
    [Compare(nameof(Password), ErrorMessage = "Passwords don't match")]
    public string? ConfirmPassword { get; set; }
}