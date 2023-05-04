using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using MVCAssignment2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MVCAssignment2.Helper
{
    public class ApplicationUserClaimsPrincipalFactory: UserClaimsPrincipalFactory<ApplicationUser, IdentityRole>
    {
        public ApplicationUserClaimsPrincipalFactory(UserManager<ApplicationUser> userManager, 
            RoleManager<IdentityRole> roleManager, IOptions<IdentityOptions> options):base(userManager, roleManager, options)
        {

        }

        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(ApplicationUser user)
        {
            var identity = await base.GenerateClaimsAsync(user);
            identity.AddClaim(new Claim("UserName", user.FullName));
            identity.AddClaim(new Claim("UserEmail", user.Email));
            return identity;
        }

    }
}
