using System.ComponentModel.DataAnnotations;
using Vidly.Models;

namespace Vidly.Dtos;

public class MovieDto
{
    public int Id { get; set; }
    
    [Required]
    [StringLength(255)]
    public string Name { get; set; }
    
    [Required]
    public MovieGenreDto Genre { get; set; }
    
    [Required]
    public DateTime ReleasedDate { get; set; }
    
    [Required]
    [Range(1, 20)]
    public int NumberInStock { get; set; }
}