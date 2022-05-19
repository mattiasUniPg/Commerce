using Microsoft.AspNetCore.Mvc;

namespace Commerce.Controllers
{
    public class ProdottiController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
