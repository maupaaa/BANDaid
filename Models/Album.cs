using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BANDaid.Models;

public class Album
{
    public int Id { get; set; }

    [Required]
    [MaxLength(300)]
    public string Title { get; set; } = string.Empty;

    public DateTime ReleaseDate { get; set; }

    public int ArtistId { get; set; }
    public Artist? Artist { get; set; }

    public ICollection<Review> Reviews { get; set; } = new List<Review>();
}