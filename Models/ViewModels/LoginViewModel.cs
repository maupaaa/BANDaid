using System.ComponentModel.DataAnnotations;

namespace BANDaid.Models.ViewModels;

public class LoginViewModel
{
    [Required(ErrorMessage = "Enter your email or username")]
    [Display(Name = "Email or username")]
    public string Identifier { get; set; } = string.Empty;

    [Required(ErrorMessage = "Enter your password")]
    [DataType(DataType.Password)]
    public string Password { get; set; } = string.Empty;

    [Display(Name = "Remember me")]
    public bool RememberMe { get; set; }

    public string? ReturnUrl { get; set; }
}
