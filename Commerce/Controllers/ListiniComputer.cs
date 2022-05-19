using Microsoft.AspNetCore.Mvc;

namespace Commerce.Controllers
{
    public class ListiniComputer : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
