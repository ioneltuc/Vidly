using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Vidly.Services.Dtos;

public class MovieDto
{
    public int Id { get; set; }
    
    [Required]
    [StringLength(255)]
    public string Name { get; set; }
    
    [Required]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public MovieGenreDto Genre { get; set; }
    
    [Required]
    public DateTime ReleasedDate { get; set; }
    
    [Required]
    [Range(1, 20)]
    public int NumberInStock { get; set; }
}