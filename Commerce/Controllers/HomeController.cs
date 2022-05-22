using Commerce.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Data.SqlClient;
using Commerce.Repository;

namespace Commerce.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private DBManager dBManager;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            dBManager = new DBManager();
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(dBManager.GetAllOrdini());
        }

        [HttpGet]
        public IActionResult IndexProdotti()
        {
            return View(dBManager.GetAllProdotti());
        }
        [HttpGet]
        public IActionResult IndexClienti()
        {
            return View(dBManager.GetAllClienti());
        }

        [HttpGet]
        public IActionResult Modifica(int id)
        {
            var cliente = dBManager.GetAllClienti().Where(x => x.IdCliente == id).FirstOrDefault();
            return View(cliente);
        }

        [HttpPost]
        public IActionResult Modifica(ClientiViewModel cliente)
        {
            var res = dBManager.GetAllClienti().Where(x => x.IdCliente == cliente.id).FirstOrDefault();
            if (res != null)
                dBManager.EditCliente(cliente);

            return RedirectToAction("Index");
        }

        public IActionResult VisualizzaOrdini()
        {
            return View();
        }

        [HttpPost]
        public IActionResult VisualizzaOrdini(OrdiniViewModel ordini)
        {
            dBManager.VisualizzaOrdini(ordini);
            return RedirectToAction("IndexOrdini");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}