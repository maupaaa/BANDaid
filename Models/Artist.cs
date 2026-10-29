using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BANDaid.Models;

public class Artist
{
    public int Id { get; set; }

    [Required]
    [MaxLength(200)]
    public string Name { get; set; } = string.Empty;

    public ICollection<Album> Albums { get; set; } = new List<Album>();
}