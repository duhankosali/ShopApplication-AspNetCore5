﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ShopApplication.UI.Identity;
using ShopApplication.UI.Models;
using System.Threading.Tasks;

namespace ShopApplication.UI.Controllers
{
    [AutoValidateAntiforgeryToken]
    public class AccountController : Controller
    {
        // Dependency Injection
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }


        public IActionResult Register() // Kullanıcı oluşturma işlemleri
        {
            return View(new RegisterModel()); // yeni model oluşturuyor.
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel model) // Kullanıcı oluşturma işlemleri
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = new ApplicationUser
            {
                UserName = model.Username,
                Email = model.Email,
                FullName = model.FullName,
            };

            var result = await _userManager.CreateAsync(user, model.Password); // create işlemi

            if (result.Succeeded)
            {
                // email tokeni oluştur
                // kullanıcı emaile gönder

                var code = await _userManager.GenerateEmailConfirmationTokenAsync(user); // Kullanıcı oluştururken otomatik oluşacak bir token üretiyoruz.
                var callbackUrl = Url.Action("ConfirmEmail", "Account", new
                {
                    userId = user.Id,
                    token = code
                }); // Aşağıdaki ConfirmEmail methoduna yönlendiriyoruz.    

                return RedirectToAction("Login", "Account");
            }

            ModelState.AddModelError("", "Bilinmeyen bir hata oluştu. Lütfen tekrar deneyiniz.");

            return View();
        }



        public IActionResult Login(string ReturnUrl = null) // Kullanıcı oluşturma işlemleri
        {
            return View(new LoginModel()
            {
                ReturnUrl = ReturnUrl
            }); // yeni model oluşturuyor.   
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model) // Kullanıcı oluşturma işlemleri    
        {

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user==null) // eğer kullanı varsa.
            {
                ModelState.AddModelError("", "Email veya şifre yanlış! Lütfen tekrar deneyiniz.");

                return View(model); // Tekrar aynı sayfa açılır.
            }

            //if (!await _userManager.IsEmailConfirmedAsync(user)) // Eğer onaylı değilse (false döndürüyorsa)
            //{
            //    ModelState.AddModelError("", "Lütfen hesabınızı Email üzerinden doğrulayınız.");
            //    return View(model);
            //}

            var result = await _signInManager.PasswordSignInAsync(user, model.Password, true, false);

            if (result.Succeeded) // kullanıcı başarılı şekilde giriş yaptıysa.
            {
                return Redirect(model.ReturnUrl?? "~/"); // Eğer ReturnUrl null ise kullanıcı anasayfaya gönderilir.
            }

            return View();
        }

        

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return Redirect("~/");
        }

        public IActionResult AccessDenied()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> ConfirmEmail(string userId, string token)  
        {
            if (userId == null || token == null)
            {
                TempData["message"] = "Geçersiz token.";
                return View();
            }

            var user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                var result = await _userManager.ConfirmEmailAsync(user, token);
                if (result.Succeeded)
                {
                    TempData["message"] = "Hesabınız onaylandı";
                    return View();
                }
            }

            TempData["message"] = "Hesabınız onaylanmadı.";
            return View();
        }
    }
}
