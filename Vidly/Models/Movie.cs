using System.ComponentModel.DataAnnotations;

namespace Vidly.Models;

public class Movie
{
    public int Id { get; set; }
    
    [Required]
    public string Name { get; set; }
    
    [Required]
    public MovieGenre Genre { get; set; }

    [Required]
    public DateTime ReleasedDate { get; set; }
    
    [Required]
    public DateTime DateAdded { get; set; }
    
    [Required]
    public int NumberInStock { get; set; }
}