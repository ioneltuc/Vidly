using AutoMapper;
using Vidly.Core.Interfaces;
using Vidly.Core.Models;
using Vidly.Services.Dtos;
using Vidly.Services.Interfaces;

namespace Vidly.Services;

public class CustomerService : ICustomerService
{
    public IUnitOfWork _unitOfWork;
    private IMapper _mapper;

    public CustomerService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    
    public async Task<CustomerDto> GetCustomerById(int customerId)
    {
        if (customerId > 0)
        {
            var customer = await _unitOfWork.Customers.GetById(customerId);
            
            if (customer != null)
                return _mapper.Map<Customer, CustomerDto>(customer);
        }

        return null;
    }

    public async Task<IEnumerable<CustomerDto>> GetAllCustomers()
    {
        var customers = await _unitOfWork.Customers.GetAllIncludeRelatedData();
        return customers.ToList().Select(_mapper.Map<Customer, CustomerDto>);
    }

    public async Task<bool> CreateCustomer(CustomerDto customerDto)
    {
        if (customerDto != null)
        {
            var customer = _mapper.Map<CustomerDto, Customer>(customerDto);
            await _unitOfWork.Customers.Add(customer);

            var result = _unitOfWork.Save();

            if (result > 0)
                return true;

            return false;
        }

        return false;
    }

    public async Task<bool> UpdateCustomer(int customerId, CustomerDto customerDto)
    {
        if (customerDto != null)
        {
            var customer = await _unitOfWork.Customers.GetById(customerId);

            if (customer != null)
            {
                _mapper.Map(customerDto, customer);
                _unitOfWork.Customers.Update(customer);

                var result = _unitOfWork.Save();

                if (result > 0)
                    return true;

                return false;
            }
        }

        return false;
    }

    public async Task<bool> DeleteCustomer(int customerId)
    {
        if (customerId > 0)
        {
            var customer = await _unitOfWork.Customers.GetById(customerId);

            if (customer != null)
            {
                _unitOfWork.Customers.Delete(customer);
                
                var result = _unitOfWork.Save();

                if (result > 0)
                    return true;

                return false;
            }
        }

        return false;
    }
}