namespace Vidly.Core.Models;

public class Movie
{
    public int Id { get; set; }
    public string Name { get; set; }
    public MovieGenre Genre { get; set; }
    public DateTime ReleasedDate { get; set; }
    public DateTime DateAdded { get; set; }
    public int NumberInStock { get; set; }
    public int NumberAvailable { get; set; }
}