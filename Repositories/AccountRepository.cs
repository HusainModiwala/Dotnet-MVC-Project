using Microsoft.AspNetCore.Identity;
using MVCAssignment2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCAssignment2.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<ApplicationUser> _usermanager;
        private readonly SignInManager<ApplicationUser> _signinmanager;

        public AccountRepository(UserManager<ApplicationUser> usermanager, SignInManager<ApplicationUser> signinmanager)
        {
            _usermanager = usermanager;
            _signinmanager = signinmanager;
        }
        public async Task<IdentityResult> CreateUserAsync(SignUpUserModel usermodel)
        {
            var user = new ApplicationUser()
            {
                FullName = usermodel.FullName,
                Email = usermodel.Email,
                UserName = usermodel.Email
            };
            return await _usermanager.CreateAsync(user, usermodel.Password);
        }

        public async Task<SignInResult> PasswordSignInAsync(LoginUserModel loginuser)
        {
           return await _signinmanager
                .PasswordSignInAsync(loginuser.Email, loginuser.Password, loginuser.RememberMe, false);
        }

        public async Task SignOutAsync()
        {
            await _signinmanager.SignOutAsync();
        }

    }
}
