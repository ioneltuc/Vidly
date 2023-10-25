using AutoMapper;
using Vidly.Core.Interfaces;
using Vidly.Core.Models;
using Vidly.Services.Dtos;
using Vidly.Services.Interfaces;

namespace Vidly.Services;

public class RentalService : IRentalService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public RentalService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<RentalDto> GetRentalById(int rentalId)
    {
        if (rentalId > 0)
        {
            var rental = await _unitOfWork.Rentals.GetById(rentalId);

            if (rental != null)
                return _mapper.Map<Rental, RentalDto>(rental);
        }

        return null;
    }

    public async Task<IEnumerable<RentalDto>> GetAllRentals()
    {
        var rentals = await _unitOfWork.Rentals.GetAllIncludeRelatedDate();

        return rentals.ToList().Select(_mapper.Map<Rental, RentalDto>);
    }

    public async Task<bool> CreateRental(NewRentalDto newRentalDto)
    {
        if (newRentalDto != null)
        {
            var customer = await _unitOfWork.Customers.GetById(newRentalDto.CustomerId);
            var customerDto = _mapper.Map<Customer, CustomerDto>(customer);
            
            foreach (var movieId in newRentalDto.MovieIds)
            {
                var rentalDto = new RentalDto
                {
                    Customer = customerDto,
                    Movie = _mapper.Map<Movie, MovieDto>(await _unitOfWork.Movies.GetById(movieId))
                };
                
                var rental = _mapper.Map<RentalDto, Rental>(rentalDto);
                rental.DateRented = DateTime.Now;
                await _unitOfWork.Rentals.Add(rental);
            }

            var result = _unitOfWork.Save();

            if (result > 0)
                return true;

            return false;
        }

        return false;
    }

    public async Task<bool> UpdateRental(int rentalId, RentalDto rentalDto)
    {
        if (rentalDto != null)
        {
            var rental = await _unitOfWork.Rentals.GetById(rentalId);

            if (rental != null)
            {
                _mapper.Map(rentalDto, rental);
                _unitOfWork.Rentals.Update(rental);

                var result = _unitOfWork.Save();

                if (result > 0)
                    return true;

                return false;
            }
        }

        return false;
    }

    public async Task<bool> DeleteRental(int rentalId)
    {
        if (rentalId > 0)
        {
            var rental = await _unitOfWork.Rentals.GetById(rentalId);

            if (rental != null)
            {
                _unitOfWork.Rentals.Delete(rental);

                var result = _unitOfWork.Save();

                if (result > 0)
                    return true;

                return false;
            }
        }

        return false;
    }
}