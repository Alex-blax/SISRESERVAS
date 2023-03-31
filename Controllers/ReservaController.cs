using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SISRESERVAS.Data;
using SISRESERVAS.Models;

namespace SISRESERVAS.Controllers
{
    public class ReservaController : Controller
    {
        private readonly Context _context;
        public ReservaController(Context context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var reservas = _context.reserva.Include(r => r.viaje).ThenInclude(v => v.departamento).ToList();
            return View(reservas);
        }
        public IActionResult Crear()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Create(reserva reserva)
        {
            if (ModelState.IsValid)
            {
                _context.reserva.Add(reserva);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
