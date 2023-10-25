using System.ComponentModel.DataAnnotations;

namespace Vidly.Services.Dtos;

public class CustomerDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    
    [Display(Name = "Date of birth")]
    public DateTime? Birthday { get; set; }
    
    
    [Display(Name = "Membership type")]
    public byte MembershipTypeId { get; set; }
    public MembershipTypeDto? MembershipType { get; set; }
}