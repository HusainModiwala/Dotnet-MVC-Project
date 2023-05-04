using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MVCAssignment2.Services
{
    public class UserService : IUserService
    {
        private readonly IHttpContextAccessor _accessor;
        public UserService(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }
        public string GetUserId()
        {
            var user = _accessor.HttpContext.User;
            if (user != null)
            {
                 return user.FindFirst(ClaimTypes.NameIdentifier).ToString();
            }
            return null;
        }
        public string GetUserEmail()
        {
            var user = _accessor.HttpContext.User;
            if (user != null)
            {
                return user.Identity.Name.ToString();
            }
            return null;
        }
        public bool IsAuthenticated()
        {
            return _accessor.HttpContext.User.Identity.IsAuthenticated;
        }
    }
}
