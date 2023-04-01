using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SISRESERVAS.Data;
using SISRESERVAS.Models;
using System.Data.SqlClient;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

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
            ClaimsPrincipal c = HttpContext.User;
            if (c.Identity != null)
            {
                if (c.Identity.IsAuthenticated)
                    return RedirectToAction("Index", "Home");
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(usuario u)
        {
            try
            {
                using (SqlConnection con = new("Data Source=.;Initial Catalog=DBpasajes;Integrated Security=True;Encrypt=False"))
                {
                    using (SqlCommand cmd = new("sp_validar_usuario", con))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add("@Correo", System.Data.SqlDbType.VarChar).Value = u.Correo;
                        cmd.Parameters.Add("@Contraseña", System.Data.SqlDbType.VarChar).Value = u.Contraseña;
                        con.Open();
                        var dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            if (dr["Correo"] != null && u.Correo != null)
                            {
                                int userId = Convert.ToInt32(dr["id"]);
                                List<Claim> c = new List<Claim>()
                                {
                                    /*new Claim(ClaimTypes.NameIdentifier, u.Correo)*/
                                    new Claim(ClaimTypes.NameIdentifier, userId.ToString()),new Claim(ClaimTypes.Email, u.Correo)

                                };
                                ClaimsIdentity ci = new(c, CookieAuthenticationDefaults.AuthenticationScheme);
                                AuthenticationProperties p = new();
                                p.AllowRefresh = true;
                                p.IsPersistent = u.MantenerActivo;


                                if (!u.MantenerActivo)
                                    p.ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(1);
                                else
                                    p.ExpiresUtc = DateTimeOffset.UtcNow.AddDays(1);

                                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(ci), p);
                                return RedirectToAction("Index", "Home");
                            }
                            else
                            {
                                ViewBag.Error = "Credenciales incorrectas o cuenta no registrada.";
                            }
                        }
                        con.Close();
                    }
                    return View();
                }
            }
            catch (System.Exception e)
            {
                ViewBag.Error = e.Message;
                return View();
            }
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}
