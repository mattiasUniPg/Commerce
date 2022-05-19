using Microsoft.AspNetCore.Mvc;

namespace Commerce.Controllers
{
    public class OrdiniController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
