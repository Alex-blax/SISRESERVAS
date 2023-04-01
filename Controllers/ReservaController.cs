using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SISRESERVAS.Data;
using SISRESERVAS.Models;
using System.Security.Claims;
using System.Linq;
using Microsoft.AspNetCore.Authorization;


namespace SISRESERVAS.Controllers
{
    [Authorize]
    public class ReservaController : Controller
    {
        private readonly Context _context;
        public ReservaController(Context context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            int parsedUserId;

            if (int.TryParse(userId, out parsedUserId))
            {
                var reservas = _context.reserva
                    .Include(r => r.departamentoviaje.viaje)
                    .Include(r => r.departamentoviaje.departamento)
                    .Include(r => r.usuario)
                    .Where(r => r.usuario.Id == parsedUserId)
                    .ToList();
                return View(reservas);
            }
            else
            {
                return BadRequest("El usuario no tiene un ID válido.");
            }
        }

        public IActionResult Crear()
        {
            ViewData["DepartamentoId"] = new SelectList(_context.departamento, "departamentoid", "nombredep");
            ViewData["ViajeId"] = new SelectList(_context.viaje, "viajeid", "bus");
            return View();
        }
        //hay el mismo problema que en la U
        [HttpPost]
        public IActionResult Create(reserva reserva)
        {
            if (ModelState.IsValid)
            {
                _context.reserva.Add(reserva);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(reserva);
        }
       /* public IActionResult Editar(int? Id)
        {
            if (Id == null)
            {

                return NotFound();
            }
            //obtener datos
            var reserva = _context.reserva.Find(Id);
            if (reserva == null)
            {
                return NotFound();
            }
            return View(reserva);
        }*/

    }

    
}
