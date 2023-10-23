using Vidly.Services.Dtos;

namespace Vidly.ViewModels;

public class CustomerFormViewModel
{
    public IEnumerable<MembershipTypeDto> MembershipTypes { get; set; }
    public CustomerDto Customer { get; set; }
}