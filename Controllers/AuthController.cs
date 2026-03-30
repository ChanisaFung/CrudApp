using Microsoft.AspNetCore.Mvc;
using CrudApp.Data;
using System.Linq;
using CrudApp.Models;

namespace CrudApp.Controllers
{
    public class AuthController : Controller
    {
        private readonly AppDbContext _context;

        public AuthController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            var user = _context.Users
                .FirstOrDefault(u => u.Username == username && u.Password == password);

            if (user != null)
            {
                return RedirectToAction("Index", "Home");
            }

            ViewBag.Error = "Usuario o contraseña incorrectos";
            return View();
        }

        // GET
        public IActionResult Register()
        {
            return View();
        }

        // POST
        [HttpPost]
        public IActionResult Register(User user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }
            var username = user.Username.Trim();

            if (_context.Users.Any(u => u.Username.ToLower() == username.ToLower()))
            {
                ModelState.AddModelError("Username", "Este usuario ya existe");
                return View(user);
            }

            user.Username = username;

            _context.Users.Add(user);
            _context.SaveChanges();

            return RedirectToAction("Login");
        }
    }
}