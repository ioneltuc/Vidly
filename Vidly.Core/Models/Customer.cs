namespace Vidly.Core.Models;

public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime? Birthday { get; set; }
    public MembershipType MembershipType { get; set; }
    public byte MembershipTypeId { get; set; }
}