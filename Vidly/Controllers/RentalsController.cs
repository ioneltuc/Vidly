using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Vidly.Controllers
{
    [Authorize(Policy = "CanManageEverything")]
    public class RentalsController : Controller
    {
        public IActionResult New()
        {
            return View();
        }
        
        public IActionResult Index()
        {
            return View();
        }
    }
}