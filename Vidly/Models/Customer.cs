using System.ComponentModel.DataAnnotations;

namespace Vidly.Models;

public class Customer
{
    public int Id { get; set; }
    
    [Required]
    [StringLength(255)]
    public string Name { get; set; }
    
    [Min18YearsIfMember]
    public DateTime? Birthday { get; set; }
    
    public MembershipType? MembershipType { get; set; }
    
    [Display(Name = "Membership type")]
    public byte MembershipTypeId { get; set; }
}