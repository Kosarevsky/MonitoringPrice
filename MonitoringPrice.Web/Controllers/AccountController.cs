using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using MonitoringPrice.Web.Models;
using MonitoringPrice.Services.Models;
using MonitoringPrice.Services.Interfaces;

namespace MonitoringPrice.Web.Controllers
{
    public class AccountController : Controller
    {
        private IUserService _userService;
        private IRoleService _roleService;
        public AccountController(IUserService userService, IRoleService roleService)
        {
            _userService = userService;
            _roleService = roleService;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                UserModel user = await _userService.GetUserByEmail(model.Email);
                if (user == null)
                {
                    // добавляем пользователя в бд
                    user = new UserModel { Email = model.Email, Password = model.Password };
                    RoleModel userRole = await  _roleService.GetRoleByName("user");

                    if (userRole != null)
                        user.Role = userRole;

                    await _userService.SaveUser(user);

                    await Authenticate(user); // аутентификация

                    return RedirectToAction("Index", "Home");
                }
                else
                    ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
            //if (ModelState.IsValid)
            //{
            //    User user = await _context.Users
            //        .Include(u => u.Role)
            //        .FirstOrDefaultAsync(u => u.Email == model.Email && u.Password == model.Password);



            //    if (user != null)
            //    {
            //        await Authenticate(user); // аутентификация

            //        return RedirectToAction("Index", "Home");
            //    }
            //    ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            //}
            return View(model);
        }
        private async Task Authenticate(UserModel user)
        {
            // создаем один claim
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role?.Name)
            };
            // создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);
            // установка аутентификационных куки
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }
    }
}