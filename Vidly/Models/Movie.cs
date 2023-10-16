using System.ComponentModel.DataAnnotations;

namespace Vidly.Models;

public class Movie
{
    public int Id { get; set; }
    
    [Required]
    [StringLength(255)]
    public string Name { get; set; }
    
    [Required]
    public MovieGenre Genre { get; set; }
    
    public DateTime ReleasedDate { get; set; }
    
    public DateTime DateAdded { get; set; }
    
    public int NumberInStock { get; set; }
}