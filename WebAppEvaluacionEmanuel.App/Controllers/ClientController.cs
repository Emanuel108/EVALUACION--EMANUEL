using EvaluacionEmanuelLibrary;
using Microsoft.AspNetCore.Mvc;
using WebAppEvaluacionEmanuel.Data;
using WebAppEvaluacionEmanuel.Data.Models;

namespace WebAppEvaluacionEmanuel.App.Controllers
{
    public class ClientController : Controller
    {
        private readonly WebAppEvaluacionEmanuelDbContext _context;

        public ClientController(WebAppEvaluacionEmanuelDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var clientLibrary = new ClientLibrary(_context);
            ViewBag.Clients = clientLibrary.GetClients();

            return View();
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Detail(Guid id)
        {
            var clientLibrary = new ClientLibrary(_context);
            var result = clientLibrary.GetClientById(id);

            if (result == null)
            {
                return NotFound();
            }

            return View(result);
        }

        [HttpPost]
        public IActionResult Add(Cliente model)
        {
            try
            {
                var clientLibrary = new ClientLibrary(_context);
                var result = clientLibrary.CreateClient(model);
                
                if(result != null)
                {
                    TempData["Success"] = "El cliente se ha creado exitosamente";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["Error"] = "Ocurrió un error al crear el nuevo cliente.";
                    return RedirectToAction(nameof(Index));
                }
                
            }
            catch(Exception)
            {
                TempData["Error"] = "Ocurrió un error al crear el nuevo cliente.";
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
