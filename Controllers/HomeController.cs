using System.Diagnostics;
using BANDaid.Data;
using BANDaid.Models;
using BANDaid.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BANDaid.Controllers;

public class HomeController : Controller
{
    private readonly ApplicationDbContext _db;

    public HomeController(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<IActionResult> Index()
    {
        var topAlbums = await _db.Albums
            .Where(a => a.Reviews.Any())
            .Select(a => new TopAlbumItem
            {
                AlbumId = a.Id,
                Title = a.Title,
                ArtistName = a.Artist!.Name,
                AverageRating = a.Reviews.Average(r => (double)r.Rating),
                ReviewCount = a.Reviews.Count
            })
            .OrderByDescending(a => a.AverageRating)
            .ThenByDescending(a => a.ReviewCount)
            .Take(5)
            .ToListAsync();

        var latestReviews = await _db.Reviews
            .OrderByDescending(r => r.CreatedAt)
            .Take(4)
            .Select(r => new LatestReviewItem
            {
                AlbumTitle = r.Album!.Title,
                ArtistName = r.Album.Artist!.Name,
                Author = r.User!.DisplayName ?? r.User.UserName ?? "unknown",
                Rating = r.Rating,
                Text = r.Text,
                CreatedAt = r.CreatedAt
            })
            .ToListAsync();

        return View(new HomeViewModel
        {
            TopAlbums = topAlbums,
            LatestReviews = latestReviews
        });
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
