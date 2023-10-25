namespace Vidly.Services.Dtos;

public class MembershipTypeDto
{
    public byte Id { get; set; }
    public string Name { get; set; }
    
    public static readonly byte Unknown = 0;
    public static readonly byte PayAsYouGo = 1;
}