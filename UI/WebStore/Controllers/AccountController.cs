using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebStore.DomainNew.Entities;
using WebStore.ViewModel;

namespace WebStore.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View(new LoginViewModel());//Будет возвращать представление с пустой моделькой
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model,[FromServices] ILogger<AccountController> logger)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            logger.LogInformation("Пользователь{0} вошел в систему", model.UserName);
            var loginResult = await _signInManager.PasswordSignInAsync(
                model.UserName, 
                model.Password, 
                model.RememberMy,
                false);

            if (!loginResult.Succeeded)
            {
                logger.LogWarning("Ошибка входа пользователя {0} в систему", model.UserName);
                ModelState.AddModelError("", "Вход невозможен");

                return View(model);
            }
            if (Url.IsLocalUrl(model.ReturnUrl))
            {
                return Redirect(model.ReturnUrl);
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout([FromServices] ILogger<AccountController> logger)
        {

            var userName = User.Identity.Name;

            await _signInManager.SignOutAsync();

            logger.LogInformation("Пользователь {0} вышел из системы", userName);
            return RedirectToAction("Index", "Home");
        }


        [HttpGet]
        public IActionResult Register()
        {
            return View(new RegisterUserViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterUserViewModel model, 
                                                   [FromServices] ILogger<AccountController> logger)
        {
            if (!ModelState.IsValid)
            {
                logger.LogWarning("Ошибка модели модели регистрации нового пользователя");
                return View(model);
            }

            var user = new User {UserName=model.UserName, Email=model.Email };

            using (logger.BeginScope("Регистрация нового пользователя"))
            {
                var createResult = await _userManager.CreateAsync(user, model.Password);

                if (!createResult.Succeeded)
                {
                    foreach (var identityError in createResult.Errors)
                    {
                        ModelState.AddModelError("", identityError.Description);
                    }
                    logger.LogInformation("Ошибка регистрации пользователя {0} :{1}",
                        model.UserName,
                        string.Join(",", createResult.Errors.Select(e => e.Description)));
                    return View(model);
                }
                logger.LogInformation("Пользователь успешно зарегистрирован {0}", model.UserName);
                await _signInManager.SignInAsync(user, false);

                await _userManager.AddToRoleAsync(user, "User");

                logger.LogInformation("Пользователь успешно вошел в систему {0}", model.UserName);
                return RedirectToAction("Index", "Home");

            }
        }
    }
}