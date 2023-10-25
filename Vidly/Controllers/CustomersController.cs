using Microsoft.AspNetCore.Mvc;
using Vidly.Services.Dtos;
using Vidly.Services.Interfaces;
using Vidly.ViewModels;

namespace Vidly.Controllers;

public class CustomersController : Controller
{
    private readonly ICustomerService _customerService;
    private readonly IMembershipTypeService _membershipTypeService;
    public CustomersController(ICustomerService customerService, IMembershipTypeService membershipTypeService)
    {
        _customerService = customerService;
        _membershipTypeService = membershipTypeService;
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Save(CustomerDto customer)
    {
        if (!ModelState.IsValid)
        {
            var viewModel = new CustomerFormViewModel()
            {
                Customer = customer,
                MembershipTypes = await _membershipTypeService.GetAllMembershipTypes()
            };
        
            return View("CustomerForm", viewModel);
        }
        
        if (customer.Id == 0)
            await _customerService.CreateCustomer(customer);
        else
            await _customerService.UpdateCustomer(customer.Id, customer);
        
        return RedirectToAction("Index", "Customers");
    }

    public async Task<ActionResult> New()
    {
        var viewModel = new CustomerFormViewModel()
        {
            Customer = new CustomerDto(),
            MembershipTypes = await _membershipTypeService.GetAllMembershipTypes()
        };

        return View("CustomerForm", viewModel);
    }

    public async Task<IActionResult> Edit(int id)
    {
        var customer = await _customerService.GetCustomerById(id);

        if (customer == null)
            return NotFound();

        var viewModel = new CustomerFormViewModel()
        {
            MembershipTypes = await _membershipTypeService.GetAllMembershipTypes(),
            Customer = customer
        };

        return View("CustomerForm", viewModel);
    }
    
    public IActionResult Index()
    {
        return View();
    }

    public async Task<IActionResult> Details(int id)
    {
        var customer = await _customerService.GetCustomerById(id);
        
        return View(customer);
    }
}