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
                    .Include(r => r.departamento)
                    .Include(r => r.viaje)
                    .Include(r => r.usuario)
                    .Where(r => r.UsuarioId == parsedUserId)
                    .ToList();
                return View(reservas);
            }
            else
            {
                return BadRequest("El usuario no tiene un ID válido.");
            }
        }

    }

    
}
