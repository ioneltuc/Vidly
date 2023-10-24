using System.ComponentModel.DataAnnotations;

namespace Vidly.Services.Dtos;

public class CustomerDto
{
    public int Id { get; set; }
    
    [Required]
    [StringLength(255)]
    public string Name { get; set; }
    
    public DateTime? Birthday { get; set; }
    
    public byte MembershipTypeId { get; set; }
    
    public MembershipTypeDto? MembershipType { get; set; }
}