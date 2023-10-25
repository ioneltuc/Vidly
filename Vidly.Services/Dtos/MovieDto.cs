using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Vidly.Services.Dtos;

public class MovieDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    
    [Display(Name = "Movie name")]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public MovieGenreDto Genre { get; set; }
    
    [Display(Name = "Date released")]
    public DateTime ReleasedDate { get; set; }
    
    [Display(Name = "Stock number")]
    public int NumberInStock { get; set; }
}