namespace Vidly.Services.Dtos;

public class NewRentalDto
{
    public int CustomerId { get; set; }
    public List<int> MovieIds { get; set; }
}