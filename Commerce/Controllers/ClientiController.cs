using Microsoft.AspNetCore.Mvc;

namespace Commerce.Controllers
{
    public class ClientiController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
