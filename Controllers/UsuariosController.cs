using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SISRESERVAS.Data;
using SISRESERVAS.Models;

namespace SISRESERVAS.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly Context _context;
        public UsuariosController(Context context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            IEnumerable<usuario> ListaUsuarios = _context.usuario;
            return View(ListaUsuarios);
        }
        public IActionResult Crear()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _context.usuario.Add(usuario);
                _context.SaveChanges();
                return RedirectToAction(nameof(Login));
            }
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
    }
}
