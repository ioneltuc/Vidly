using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vidly.Data;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers;

public class CustomersController : Controller
{
    private readonly VidlyContext _context;

    public CustomersController(VidlyContext context)
    {
        _context = context;
    }

    protected override void Dispose(bool disposing)
    {
        _context.Dispose();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Save(Customer customer)
    {
        if (!ModelState.IsValid)
        {
            var viewModel = new CustomerFormViewModel()
            {
                Customer = customer,
                MembershipTypes = _context.MembershipType.ToList()
            };
        
            return View("CustomerForm", viewModel);
        }
        
        if (customer.Id == 0)
        {
            _context.Customers.Add(customer);
        }
        else
        {
            var customerToEdit = _context.Customers.Single(c => c.Id == customer.Id);
            customerToEdit.Name = customer.Name;
            customerToEdit.Birthday = customer.Birthday;
            customerToEdit.MembershipTypeId = customer.MembershipTypeId;
        }

        _context.SaveChanges();

        return RedirectToAction("Index", "Customers");
    }

    public IActionResult New()
    {
        var viewModel = new CustomerFormViewModel()
        {
            Customer = new Customer(),
            MembershipTypes = _context.MembershipType.ToList()
        };

        return View("CustomerForm", viewModel);
    }

    public IActionResult Edit(int id)
    {
        var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

        if (customer == null)
            return NotFound();

        var viewModel = new CustomerFormViewModel()
        {
            MembershipTypes = _context.MembershipType.ToList(),
            Customer = customer
        };

        return View("CustomerForm", viewModel);
    }
    
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Details(int id)
    {
        var customer = _context.Customers
            .Include(c => c.MembershipType)
            .SingleOrDefault(c => c.Id == id);
        
        return View(customer);
    }
}