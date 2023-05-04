using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVCAssignment2.Models;
using MVCAssignment2.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCAssignment2.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountRepository _accountRepository;
        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        [Route("signup")]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        [Route("signup")]
        public async Task<IActionResult> SignUp(SignUpUserModel model)
        {
            if (ModelState.IsValid)
            {
                var res = await _accountRepository.CreateUserAsync(model);
                if (!res.Succeeded)
                {
                    foreach(var errmsg in res.Errors)
                    {
                        ModelState.AddModelError("", errmsg.Description);
                    }
                    return View(model);
                }
                ModelState.Clear();
            }
            return View();
        }

        [Route("login")]
        public IActionResult Login()
        {
            return View();
        }

        [Route("login")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginUserModel loginuser, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var res = await _accountRepository.PasswordSignInAsync(loginuser);
                if (res.Succeeded)
                {
                    if (!string.IsNullOrEmpty(returnUrl))
                    {
                        //string[] values = returnUrl.Split('/');
                        //var test = ControllerContext.HttpContext.Request..ToString();
                        return Redirect(returnUrl);
                        //return RedirectToAction("EditBookReadingEvent1", "BookReadingEvent");

                    }
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Invalid Credentials");
            }
            return View();
        }
        [Route("logout")]
        public async Task<IActionResult> Logout()
        {
            await _accountRepository.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
