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
                // Obtener las reservas del usuario actual
                var reservas = _context.Reservas
                    .Where(r => r.Usuario.Id == parsedUserId)
                    .Include(r => r.Viaje)
                        .ThenInclude(v => v.Departamento)
                    .ToList();

                // Mapear las reservas a un modelo de vista
                var modelo = reservas.Select(r => new reserva
                {
                    IdRes = r.IdRes,
                    FechaReserva = r.FechaReserva,
                    ViajeId = r.ViajeId,
                    Viaje = r.Viaje != null ? new viaje
                    {
                        IdViaje = r.Viaje.IdViaje,
                        Bus = r.Viaje.Bus,
                        Conductor = r.Viaje.Conductor,
                        Fecha = r.Viaje.Fecha,
                        DepartamentoId = r.Viaje.DepartamentoId,
                        Departamento = r.Viaje.Departamento != null ? new departamento
                        {
                            IdDep = r.Viaje.Departamento.IdDep,
                            NombreDep = r.Viaje.Departamento.NombreDep,
                            Precio = r.Viaje.Departamento.Precio
                        } : null
                    } : null,
                    UsuarioId = r.UsuarioId,
                    Usuario = new usuario
                    {
                        Id = r.Usuario.Id,
                        Nombre = r.Usuario.Nombre
                    }
                });

                return View(modelo);
            }
            else
            {
                return BadRequest("El usuario no tiene un ID válido.");
            }
        }

        public IActionResult Crear()
        {
            ViewData["DepartamentoId"] = new SelectList(_context.Departamentos, "departamentoid", "nombredep");
            ViewData["ViajeId"] = new SelectList(_context.Viajes, "viajeid", "bus");
            return View();
        }
        //hay el mismo problema que en la U
        [HttpPost]
        public IActionResult Create(reserva reserva)
        {
            if (ModelState.IsValid)
            {
                _context.Reservas.Add(reserva);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(reserva);
        }

    }

    
}
