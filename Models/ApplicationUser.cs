using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BANDaid.Models;

public class ApplicationUser : IdentityUser
{
    [MaxLength(100)]
    public string? DisplayName { get; set; }

    [MaxLength(500)]
    public string? Bio { get; set; }

    public ICollection<Review> Reviews { get; set; } = new List<Review>();
}