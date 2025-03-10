using Domain.Enums;
using Domain.Types;

namespace Domain.Entities;

public class Album
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Artist { get; set; }
    public string SpotifyId { get; set; }
    public string ImageUrl { get; set; }
    public Genre Genre { get; set; }
    public Rating UserRating { get; set; }
    public string Description { get; set; }
}