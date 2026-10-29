using System.ComponentModel.DataAnnotations;

namespace BANDaid.Models.ViewModels;

public class RegisterViewModel
{
    [Required(ErrorMessage = "Enter your email address")]
    [EmailAddress(ErrorMessage = "This does not look like an email address")]
    [Display(Name = "Email address")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Pick a username")]
    [StringLength(30, MinimumLength = 3, ErrorMessage = "Username has to be 3-30 characters long")]
    [RegularExpression(@"^[A-Za-z0-9_.\-]+$", ErrorMessage = "Use only letters, digits, dots, dashes and underscores")]
    public string Username { get; set; } = string.Empty;

    [Required(ErrorMessage = "Enter a password")]
    [DataType(DataType.Password)]
    public string Password { get; set; } = string.Empty;

    [Required(ErrorMessage = "Repeat your password")]
    [DataType(DataType.Password)]
    [Compare(nameof(Password), ErrorMessage = "Passwords do not match")]
    [Display(Name = "Repeat password")]
    public string ConfirmPassword { get; set; } = string.Empty;
}
