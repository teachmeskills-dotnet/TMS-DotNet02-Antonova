﻿using DiscountCouponQuest.BLL.Interfaces;
using DiscountCouponQuest.BLL.Models;
using DiscountCouponQuest.DAL.Models;
using DiscountCouponQuest.WebApp.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace DiscountCouponQuest.WebApp.Controllers
{
    /// <summary>
    /// Управление аккаунтами
    /// </summary>
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ICustomersService _customersService;
        private readonly IProviderService _providersService;
        private readonly IEmailService _emailService;

        /// <summary>
        /// Конструктор 
        /// </summary>
        /// <param name="userManager"></param>
        /// <param name="signInManager"></param>
        /// <param name="roleManager"></param>
        /// <param name="dbContext"></param>
        /// <param name="setting"></param>
        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, ICustomersService customersService, IProviderService providerService, IEmailService emailService)
        {
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            _signInManager = signInManager ?? throw new ArgumentNullException(nameof(signInManager));
            _customersService = customersService ?? throw new ArgumentNullException(nameof(customersService));
            _providersService = providerService ?? throw new ArgumentNullException(nameof(providerService));
            _emailService = emailService ?? throw new ArgumentNullException(nameof(emailService));
        }

        /// <summary>
        /// Модель регистрации пользовтеля
        /// </summary>
        /// <returns>RegisterCustomer View</returns>
        [HttpGet]
        public IActionResult _RegisterCustomer()
        {
            return PartialView();
        }

        /// <summary>
        /// Модель регистрации юридических лиц 
        /// </summary>
        /// <returns>RegisterProvider View</returns>
        [HttpGet]
        public IActionResult _RegisterProvider()
        {
            return PartialView();
        }

        /// <summary>
        /// Вход в систему
        /// </summary>
        /// <returns>Login View</returns>
        [HttpGet]
        public IActionResult _Login(string returnUrl = null)
        {
            return PartialView(new LoginViewModel { ReturnUrl = returnUrl });
        }

        [HttpGet]
        public IActionResult LoginModel()
        {
            return View();
        }

        /// <summary>
        /// Реализация регистрации пользователя
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegisterCustomer(RegisterViewModelCustomer model)
        {
            if (ModelState.IsValid)
            {
                User user = new User { Email = model.Email, UserName = model.Email };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await EmailSend(model, user);
                    var customer = new CustomerDto()
                    {
                        PhoneNumber = model.PhoneNumber,
                        UserId = user.Id
                    };
                    await AddToDataBase(user, customer);
                    return Content("Для завершения регистрации проверьте электронную почту и перейдите по ссылке, указанной в письме");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View("LoginModel");
        }

        /// <summary>
        /// Реализация регистрации юридических лиц
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegisterProvider(RegisterViewModelProvider model)
        {
            if (ModelState.IsValid)
            {
                User user = new User { Email = model.Email, UserName = model.Email };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await EmailSend(model, user);
                    var provider = new ProviderDto()
                    {
                        UserId = user.Id
                    };
                    await AddProviderToDataBase(user, provider);
                    return Content("Для завершения регистрации проверьте электронную почту и перейдите по ссылке, указанной в письме");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View("LoginModel");
        }

        [HttpGet]
        public async Task<IActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return View("Error");
            }
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return View("Error");
            }
            var result = await _userManager.ConfirmEmailAsync(user, code);
            if (result.Succeeded)
                return RedirectToAction("Index", "Home");
            else
                return View("Error");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(model.Email);
                if (user != null)
                {
                    if (!await _userManager.IsEmailConfirmedAsync(user))
                    {
                        ModelState.AddModelError(string.Empty, "Вы не подтвердили свой email");
                        return View(model);
                    }
                }
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                    {
                        return Redirect(model.ReturnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Неправильный логин и (или) пароль");
                }
            }
            return View("LoginModel");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        /// <summary>
        /// Отправка потверждения регистрации на почту
        /// </summary>
        /// <param name="model"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        private async Task EmailSend(RegisterViewModelBase model, User user)
        {
            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var callbackUrl = Url.Action("ConfirmEmail", "Account",
            new { userId = user.Id, code = code },
            protocol: HttpContext.Request.Scheme);
            await _emailService.SendEmailAsync(model.Email, "Confirm your account", $"Подтвердите регистрацию, перейдя по ссылке: <a href='{callbackUrl}'>link</a>");
        }

        /// <summary>
        /// Добавление данных пользователя в базу данных
        /// </summary>
        /// <param name="user"></param>
        /// <param name="customer"></param>
        /// <returns></returns>
        private async Task AddToDataBase(User user, CustomerDto customer)
        {
            await _customersService.AddAsync(customer);
            await _userManager.AddToRoleAsync(user, "Customer");
            await _signInManager.SignInAsync(user, false);
        }

        /// <summary>
        /// Добавление данных юридического лица в базу данных
        /// </summary>
        /// <param name="user"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        private async Task AddProviderToDataBase(User user, ProviderDto provider)
        {
            await _providersService.AddAsync(provider);
            await _userManager.AddToRoleAsync(user, "Provider");
            await _signInManager.SignInAsync(user, false);
        }
    }
}
