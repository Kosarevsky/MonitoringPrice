using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using MonitoringPrice.Web.Models;
using MonitoringPrice.Services.Models;
using MonitoringPrice.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace MonitoringPrice.Web.Controllers
{
    [Authorize]
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
                var userModel = new UserModel { Email = model.Email, Password = model.Password };
                UserModel user = await _userService.GetUser(userModel);
                if (user == null)
                {
                    // добавляем пользователя в бд
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
            if (ModelState.IsValid)
            {
                var userModel = new UserModel { Email = model.Email, Password = model.Password };

                var user = await _userService.GetUser(userModel);

                if (user != null)
                {
                    await Authenticate(user); // аутентификация

                    return Redirect("~/admin"); // RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
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