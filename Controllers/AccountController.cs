using Microsoft.AspNetCore.Mvc;
using PersonelKayıtSistemi.Models;
using PersonelKayıtSistemi.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

namespace PersonelKayıtSistemi.Controllers
{
    public class AccountController : Controller
    {
        private readonly DataContext _context;

        public AccountController(DataContext context)
        {
            _context = context;
        }

        // Login GET
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // Login POST
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _context.Users.SingleOrDefault(u => u.Username == model.Username && u.Password == model.Password);
                
                if (user != null)
                {
                    // Kullanıcı bulundu, kimlik oluştur
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, user.Username),
                        new Claim(ClaimTypes.Role, user.Role) // Kullanıcının rolünü ekleyin: Admin/User
                    };

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var authProperties = new AuthenticationProperties
                    {
                        IsPersistent = model.RememberMe // Beni Hatırla seçeneği
                    };

                    await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity),
                        authProperties);

                    return RedirectToAction("Index", "PersonelYonetimi");
                }
                ModelState.AddModelError("", "Geçersiz kullanıcı adı veya şifre.");
            }

            return View(model);
        }

        // Register GET
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        // Register POST
        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new User
                {
                    Username = model.Username,
                    Password = model.Password,
                    Role = model.Role // Admin veya User seçeneği
                };

                _context.Users.Add(user);
                _context.SaveChanges();

                return RedirectToAction("Login");
            }

            return View(model);
        }

        // Logout
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
