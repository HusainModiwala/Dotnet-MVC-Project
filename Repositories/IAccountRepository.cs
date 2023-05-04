using Microsoft.AspNetCore.Identity;
using MVCAssignment2.Models;
using System.Threading.Tasks;

namespace MVCAssignment2.Repositories
{
    public interface IAccountRepository
    {
        Task<IdentityResult> CreateUserAsync(SignUpUserModel signupmodel);
        Task<SignInResult> PasswordSignInAsync(LoginUserModel loginuser);
        Task SignOutAsync();
    }
}