using System;
using System.ComponentModel.DataAnnotations;

namespace BANDaid.Models;

public class Review
{
    public int Id { get; set; }

    [Range(0, 10, ErrorMessage = "Has to be between 0 and 10")]
    public int Rating { get; set; }

    [MaxLength(2000)]
    public string? Text { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    [Required]
    public string UserId { get; set; } = string.Empty;
    public ApplicationUser? User { get; set; }

    public int AlbumId { get; set; }
    public Album? Album { get; set; }
}