using Vidly.Services.Dtos;

namespace Vidly.Services.Interfaces;

public interface IRentalService
{
    Task<RentalDto> GetRentalById(int rentalId);
    Task<IEnumerable<RentalDto>> GetAllRentals();
    Task<bool> CreateRental(NewRentalDto newRentalDto);
    Task<bool> UpdateRental(int rentalId, RentalDto rentalDto);
    Task<bool> DeleteRental(int rentalId);
}