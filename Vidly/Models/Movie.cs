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
    
    [Required]
    [Display(Name = "Released date")]
    public DateTime ReleasedDate { get; set; }
    
    public DateTime DateAdded { get; set; }
    
    [Required]
    [Range(1, 20)]
    [Display(Name = "Stock number")]
    public int NumberInStock { get; set; }
}