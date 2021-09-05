using B_Layer.Helpers;
using B_Layer.Models.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinaL.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly ILogger<AccountController> logger;

        public AccountController(UserManager<IdentityUser> userManager , SignInManager<IdentityUser> signInManager , ILogger<AccountController> logger)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.logger = logger;
        }



        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM Model)
        {
            if (ModelState.IsValid)
            {
                var Isuser = await userManager.FindByEmailAsync(Model.Email);
                if (Isuser == null)
                {
                    var user = new IdentityUser()
                    {
                        UserName = Model.UserName,
                        Email = Model.Email,
                    };
                    var ruselt = await userManager.CreateAsync(user, Model.Password);
                    if (ruselt.Succeeded)
                    {
                       return RedirectToAction("Login");
                    }
                    else
                    {
                        foreach (var error in ruselt.Errors)
                        {
                            ModelState.AddModelError("", error.Description);        
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError("", "This Email Is Used Before");
                }
            }
            else
            {
                return View(Model);
            }
            return View();
        }



        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM Model)
        {
            var user = await userManager.FindByEmailAsync(Model.Email);
            if (user != null)
            {
                var ruselt =  await signInManager.PasswordSignInAsync(user.UserName, Model.Password, Model.RememberMe, false);
                if (ruselt.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Wrong Email or Password");
                }
            }
            else
            {
                ModelState.AddModelError("","Wrong Email or Password");
            }
            return View(Model);
        }



        [HttpPost]
        public async Task<IActionResult> LogOut()
        {
            await signInManager.SignOutAsync();

            return RedirectToAction("Login");
        }



        public IActionResult ForgetPassword()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ForgetPassword(ForgetPasswordVM Model)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(Model.EmailAddress);

                if (user != null)
                {
                    var Token = await userManager.GeneratePasswordResetTokenAsync(user);
                    var PasswordResetLink = Url.Action("ResetPassword", "Account", new { Email = Model.EmailAddress , Token = Token },Request.Scheme);
                    MailVM MailDetails = new MailVM()
                    {
                        Title = "Reset Password Link",
                        Message = PasswordResetLink,
                        MailTo = Model.EmailAddress
                    };
                    MailHelper.SendMail(MailDetails);
                    logger.Log(LogLevel.Warning, PasswordResetLink);
                    return RedirectToAction("ConfirmForgetPassword");
                }
                return RedirectToAction("ConfirmForgetPassword");
            }
            return View(Model);
        }



        public IActionResult ResetPassword(string Email, string Token)
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordVM model)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(model.Email);

                if (user != null)
                {
                    var result = await userManager.ResetPasswordAsync(user, model.Token, model.Password);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("ConfirmResetPassword");
                    }

                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }

                    return View(model);
                }

                return RedirectToAction("ConfirmResetPassword");
            }
            return View(model);
        }


        public IActionResult ConfirmResetPassword()
        {
            return View();
        }

        public IActionResult ConfirmForgetPassword()
        {
            return View();
        }
    }
}
