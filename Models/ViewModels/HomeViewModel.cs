namespace BANDaid.Models.ViewModels;

public class HomeViewModel
{
    public List<TopAlbumItem> TopAlbums { get; set; } = new();
    public List<LatestReviewItem> LatestReviews { get; set; } = new();
}

public class TopAlbumItem
{
    public int AlbumId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string ArtistName { get; set; } = string.Empty;
    public double AverageRating { get; set; }
    public int ReviewCount { get; set; }
}

public class LatestReviewItem
{
    public string AlbumTitle { get; set; } = string.Empty;
    public string ArtistName { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public int Rating { get; set; }
    public string? Text { get; set; }
    public DateTime CreatedAt { get; set; }
}
